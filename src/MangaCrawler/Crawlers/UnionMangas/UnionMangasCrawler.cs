﻿using HtmlAgilityPack;
using MangaCrawler.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MangaCrawler
{
	public class UnionMangasCrawler : IWebCrawler
	{
		public ISource Source;

		public UnionMangasCrawler(ISource source)
		{
			this.Source = source;
		}

		public List<Manga> GetMangasAscendingOrder()
		{
			return GetMangas(Source.GetMangasAscendingOrderUrl());
		}

		public List<Manga> GetMangasVisualizationOrder()
		{
			return GetMangas(Source.GetMangasVisualizationOrderUrl());
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
	}
}