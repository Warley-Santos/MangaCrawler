using System.Collections.Generic;
using MangaCrawler.Model;

namespace MangaCrawler
{
	public interface IWebCrawler
	{
		List<Manga> GetMangas(string sortingUrl);
		List<Manga> GetMangasNextPage(string sortingUrl);
		List<Manga> GetMangasPreviousPage(string sortingUrl);
		List<Manga> GetMangasAscendingOrder(bool next);
		List<Manga> GetMangasVisualizationOrder(bool next);
		List<Chapter> GetChapters(string url);
		List<Page> GetPages(string url);
		List<MangaResultSearch> Search(string param);
	}
}