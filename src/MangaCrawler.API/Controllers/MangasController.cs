using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MangaCrawler.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
		public IEnumerable<Manga> GetMangasAscendingOrder(bool nextPage = true)
		{
			return Crawler.GetMangasAscendingOrder(nextPage);
		}

		[HttpGet("Visualization")]
		public IEnumerable<Manga> GetMangasVisualizationOrder(bool nextPage = true)
		{
			return Crawler.GetMangasVisualizationOrder(nextPage);
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