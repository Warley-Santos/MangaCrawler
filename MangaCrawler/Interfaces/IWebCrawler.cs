using System.Collections.Generic;
using MangaCrawler.Model;

namespace MangaCrawler
{
	public interface IWebCrawler
	{
		List<Manga> GetMangas(string sortingUrl);
		List<Manga> GetMangasAscendingOrder();
		List<Manga> GetMangasVisualizationOrder();
		List<Chapter> GetChapters(string url);
		List<Page> GetPages(string url);
	}
}