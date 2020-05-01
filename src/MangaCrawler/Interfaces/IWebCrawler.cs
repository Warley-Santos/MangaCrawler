using MangaCrawler.Model;
using System.Collections.Generic;

namespace MangaCrawler
{
	public interface IWebCrawler
	{
		List<Manga> GetMangas(string sortingUrl);
		List<Manga> GetMangasAscendingOrder(int page);
		List<Manga> GetMangasVisualizationOrder(int page);
		List<Chapter> GetChapters(string url, bool isId);
		List<Page> GetPages(string url);
		List<MangaResultSearch> Search(string param);
	}
}