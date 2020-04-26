using HtmlAgilityPack;
using MangaCrawler.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaCrawler
{
	public class UnionMangasCrawler : IWebCrawler
	{
		public ISource Source;
		private static int _page = 0;

		public UnionMangasCrawler(ISource source)
		{
			this.Source = source;
		}

		public List<Manga> GetMangasAscendingOrder(bool next)
		{
			if (next)
				return GetMangasNextPage(Source.GetMangasAscendingOrderUrl());
			else
				return GetMangasPreviousPage(Source.GetMangasAscendingOrderUrl());
		}

		public List<Manga> GetMangasVisualizationOrder(bool next)
		{
			if (next)
				return GetMangasNextPage(Source.GetMangasVisualizationOrderUrl());
			else
				return GetMangasPreviousPage(Source.GetMangasVisualizationOrderUrl());
		}

		public List<Manga> GetMangasNextPage(string sortingUrl)
		{
			_page++;
			return GetMangas(sortingUrl + "/" + _page.ToString());
		}
		public List<Manga> GetMangasPreviousPage(string sortingUrl)
		{
			if (_page > 1)
				_page--;
			else if (_page == 0)
				_page = 1;

			return GetMangas(sortingUrl + "/" + _page.ToString());
		}

		public List<Manga> GetMangas(string sortingUrl)
		{
			List<Manga> mangasList = new List<Manga>();

			HtmlDocument htmlDoc = HtmlUtils.LoadUrl(sortingUrl);
			HtmlNodeCollection mangaNodes = HtmlUtils.GetHtmlNodes(htmlDoc, Source.GetMangaListPath());

			for (var i = 0; i < mangaNodes.Count; i++)
			{
				// TODO: melhorar a forma de buscar os nodes
				var coverUrl = mangaNodes[i].SelectSingleNode(Source.GetMangaListPath(i + 1) + "/a[1]/img").GetAttributeValue("src", "");
				var titleUrl = mangaNodes[i].SelectSingleNode(Source.GetMangaListPath(i + 1) + "/a[2]").GetAttributeValue("href", "");
				var titleName = mangaNodes[i].SelectSingleNode(Source.GetMangaListPath(i + 1) + "/a[2]").InnerHtml.Trim();

				mangasList.Add(new Manga(titleName, coverUrl, titleUrl));
			}

			return mangasList;
		}

		public List<Chapter> GetChapters(string url)
		{
			List<Chapter> chaptersList = new List<Chapter>();

			HtmlDocument mangaPage;

			mangaPage = HtmlUtils.LoadUrl(url);

			var chapterNodes = HtmlUtils.GetHtmlNodes(mangaPage, Source.GetChapterListPath());

			for (var i = chapterNodes.Count - 1; i >= 0; i--)
			{
				var name = chapterNodes[i].ChildNodes[3].InnerHtml;
				var chapterUrl = chapterNodes[i].ChildNodes[3].GetAttributeValue("href", "");
				var releaseDate = chapterNodes[i].ChildNodes[5].InnerHtml.Replace("(", "").Replace(")", "");

				chaptersList.Add(new Chapter(name, releaseDate, chapterUrl));
			}

			return chaptersList;
		}

		public List<Page> GetPages(string url)
		{
			List<Page> pagesList = new List<Page>();

			HtmlDocument chapterPages;

			chapterPages = HtmlUtils.LoadUrl(url);

			var pageNodes = HtmlUtils.GetHtmlNodes(chapterPages, Source.GetChapterPagesPath());

			int pageNumber = 0;

			foreach (var n in pageNodes)
			{
				var pageUrl = n.GetAttributeValue("src", "");
				pageNumber++;

				pagesList.Add(new Page(pageNumber, pageUrl));
			}

			return pagesList;
		}

		public List<MangaResultSearch> Search(string param)
		{
			var t = Task.Run(() => HttpUtils.GetURI(new Uri(Source.GetSearchUrl() + param)));
			t.Wait();

			string result = t.Result.Replace(@"\", "");

			MangaResultList mangas = JsonConvert.DeserializeObject<MangaResultList>(result);

			return mangas.items;
		}
	}
}
