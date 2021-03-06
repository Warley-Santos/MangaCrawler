﻿using HtmlAgilityPack;
using MangaCrawler.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using System.Web;

namespace MangaCrawler
{
	public class UnionMangasCrawler : IWebCrawler
	{
		private readonly ISource _source;
		private IMemoryCache _cache;

		public UnionMangasCrawler(ISource source, IMemoryCache memoryCache)
		{
			_source = source;
			_cache = memoryCache;
		}

		public List<Manga> GetMangasAscendingOrder(int page)
		{
			return GetMangasFromCache(_source.GetAscendingOrderUrl() + "/" + page.ToString());
		}

		public List<Manga> GetMangasVisualizationOrder(int page)
		{
			return GetMangasFromCache(_source.GetVisualizationOrderUrl() + "/" + page.ToString());
		}

		public List<Manga> GetMangasFromCache(string sortingUrl)
		{
			var cacheEntry = _cache.GetOrCreate(sortingUrl, entry =>
			{
				entry.SetSlidingExpiration(TimeSpan.FromSeconds(600));
				entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(600);

				return GetMangas(sortingUrl);
			});

			return cacheEntry;
		}	
		
		public List<Manga> GetMangas(string sortingUrl)
		{
			List<Manga> mangasList = new List<Manga>();

			HtmlDocument htmlDoc = HtmlUtils.LoadUrl(sortingUrl);
			HtmlNodeCollection mangaNodes = HtmlUtils.GetHtmlNodes(htmlDoc, _source.GetMangaListPath());

			for (var i = 0; i < mangaNodes.Count; i++)
			{
				// TODO: melhorar a forma de buscar os nodes
				var coverUrl = mangaNodes[i].SelectSingleNode(_source.GetMangaListPath(i + 1) + "/a[1]/img").GetAttributeValue("src", "");
				var titleUrl = mangaNodes[i].SelectSingleNode(_source.GetMangaListPath(i + 1) + "/a[2]").GetAttributeValue("href", "");
				var titleName = mangaNodes[i].SelectSingleNode(_source.GetMangaListPath(i + 1) + "/a[2]").InnerHtml.Trim();

				var mangaId = titleUrl.Split("/")[4];
				mangasList.Add(new Manga(mangaId, titleName, coverUrl, titleUrl));
			}

			return mangasList;
		}

		public MangaProfile GetMangaById(string mangaId)
		{
			return GetMangaByUrl(_source.GetBaseUrlTitle() + mangaId);
		}

		public MangaProfile GetMangaByUrl(string mangaUrl)
		{
			MangaProfile manga = new MangaProfile();

			var mangaPage = HtmlUtils.LoadUrl(HttpUtility.UrlDecode(mangaUrl));
			var mangaName = HtmlUtils.GetHtmlNodes(mangaPage, _source.GetMangaNamePath());
			var chapterNodes = HtmlUtils.GetHtmlNodes(mangaPage, _source.GetChapterListPath());

			manga.MangaName = mangaName[0].InnerText;

			for (var i = chapterNodes.Count - 1; i >= 0; i--)
			{
				var name = chapterNodes[i].ChildNodes[3].InnerHtml;
				var chapterUrl = chapterNodes[i].ChildNodes[3].GetAttributeValue("href", "");
				var releaseDate = chapterNodes[i].ChildNodes[5].InnerHtml.Replace("(", "").Replace(")", "");

				manga.Chapters.Add(new Chapter(name, releaseDate, chapterUrl));
			}

			return manga;
		}

		public List<Page> GetPages(string url)
		{
			List<Page> pagesList = new List<Page>();
			HtmlDocument chapterPages;

			chapterPages = HtmlUtils.LoadUrl(url);

			var pageNodes = HtmlUtils.GetHtmlNodes(chapterPages, _source.GetChapterPagesPath());

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
			var t = Task.Run(() => HttpUtils.GetURI(new Uri(_source.GetSearchUrl() + param)));
			t.Wait();

			string result = t.Result.Replace(@"\", "");

			MangaResultList mangas = JsonConvert.DeserializeObject<MangaResultList>(result);

			return mangas.items;
		}
	}
}
