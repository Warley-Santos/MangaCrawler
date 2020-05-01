using MangaCrawler.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web;

namespace MangaCrawler.API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class MangasController : ControllerBase
    {
		private IWebCrawler Crawler;

		public MangasController()
		{
			var source = new UnionMangasSource();
			Crawler = new UnionMangasCrawler(source);
		}

		[HttpGet("Ascending")]
		public IEnumerable<Manga> GetMangasAscendingOrder(int page = 1)
		{
			return Crawler.GetMangasAscendingOrder(page);
		}

		[HttpGet("Visualization")]
		public IEnumerable<Manga> GetMangasVisualizationOrder(int page = 1)
		{
			return Crawler.GetMangasVisualizationOrder(page);
		}

		[HttpGet("Chapter/{mangaUrl}")]
		public IEnumerable<Chapter> GetChapters(string mangaUrl)
		{
			return Crawler.GetChapters(HttpUtility.UrlDecode(mangaUrl));
		}

		[HttpGet("Chapter/Pages/{chapterUrl}")]
		public IEnumerable<Page> GetPages(string chapterUrl)
		{
			return Crawler.GetPages(HttpUtility.UrlDecode(chapterUrl));
		}

		[HttpGet("Search/{param}")]
		public IEnumerable<MangaResultSearch> Search(string param)
		{
			return Crawler.Search(param);
		}
	}
}