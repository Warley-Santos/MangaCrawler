using MangaCrawler.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web;

namespace MangaCrawler.API.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	[Produces("application/json")]
	public class MangasController : ControllerBase
    {
		private readonly IWebCrawler _crawler;

		public MangasController(IWebCrawler crawler)
		{
			_crawler = crawler;
		}

		[HttpGet("Ascending")]
		public IEnumerable<Manga> GetMangasAscendingOrder(int page = 1)
		{
			return _crawler.GetMangasAscendingOrder(page);
		}

		[HttpGet("Visualization")]
		public IEnumerable<Manga> GetMangasVisualizationOrder(int page = 1)
		{
			return _crawler.GetMangasVisualizationOrder(page);
		}

		[HttpGet("ChaptersById/{mangaId}")]
		public IEnumerable<Chapter> GetChaptersById(string mangaId)
		{
			return _crawler.GetChaptersById(mangaId);
		}

		[HttpGet("Chapters/{mangaUrl}")]
		public IEnumerable<Chapter> GetChapters(string mangaUrl)
		{
			return _crawler.GetChapters(mangaUrl);
		}

		[HttpGet("Chapter/Pages/{chapterUrl}")]
		public IEnumerable<Page> GetPages(string chapterUrl)
		{
			return _crawler.GetPages(HttpUtility.UrlDecode(chapterUrl));
		}

		[HttpGet("Search/{param}")]
		public IEnumerable<MangaResultSearch> Search(string param)
		{
			return _crawler.Search(param);
		}
	}
}