﻿using MangaCrawler.Model;
using System.Collections.Generic;

namespace MangaCrawler
{
	public interface IWebCrawler
	{
		List<Manga> GetMangas(string sortingUrl);
		List<Manga> GetMangasAscendingOrder(int page);
		List<Manga> GetMangasVisualizationOrder(int page);
		MangaProfile GetMangaById(string mangaId);
		MangaProfile GetMangaByUrl(string mangaUrl);
		List<Page> GetPages(string url);
		List<MangaResultSearch> Search(string param);
	}
}