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
		[HttpGet("Ascending")]
		public IEnumerable<Manga> GetMangasAscendingOrder()
		{
			var source = new UnionMangasSource();
			var crawler = new UnionMangasCrawler(source);

			return crawler.GetMangasAscendingOrder();
		}

		[HttpGet("Visualization")]
		public IEnumerable<Manga> GetMangasVisualizationOrder()
		{
			var source = new UnionMangasSource();
			var crawler = new UnionMangasCrawler(source);

			return crawler.GetMangasVisualizationOrder();
		}

		[HttpGet("Chapter/{mangaUrl}")]
		public IEnumerable<Chapter> GetChapters(string mangaUrl)
		{
			var source = new UnionMangasSource();
			var crawler = new UnionMangasCrawler(source);

			return crawler.GetChapters(HttpUtility.UrlDecode(mangaUrl));
		}

		[HttpGet("Chapter/Pages/{chapterUrl}")]
		public IEnumerable<Page> GetPages(string chapterUrl)
		{
			var source = new UnionMangasSource();
			var crawler = new UnionMangasCrawler(source);

			return crawler.GetPages(HttpUtility.UrlDecode(chapterUrl));
		}
		
	}
}