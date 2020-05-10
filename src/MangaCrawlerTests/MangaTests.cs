using MangaCrawler;
using Microsoft.Extensions.Caching.Memory;
using Xunit;

namespace MangaCrawlerTests
{
	public class MangaTests
	{
		private IWebCrawler _crawler;

		public MangaTests()
		{
			var memoryCache = new MemoryCache(new MemoryCacheOptions());
			var source = new UnionMangasSource();
			
			_crawler = new UnionMangasCrawler(source, memoryCache);
		}

		[Fact]
		public void GetTitulosAscendingTest()
		{
			var titles = _crawler.GetMangasAscendingOrder(1);

			Assert.NotNull(titles[0].MangaCoverUrl);
			Assert.NotNull(titles[0].MangaName);
			Assert.NotNull(titles[0].MangaUrl);
		}

		[Fact]
		public void GetMangasVisualizationOrderTest()
		{
			var titles = _crawler.GetMangasVisualizationOrder(1);

			Assert.NotNull(titles[0].MangaCoverUrl);
			Assert.NotNull(titles[0].MangaName);
			Assert.NotNull(titles[0].MangaUrl);
		}

		[Fact]
		public void GetCapitulosUrlTest()
		{
			var chapters = _crawler.GetChapters(@"https://unionleitor.top/manga/solo-leveling", false);

			Assert.Equal("Cap. 00", chapters[0].Name);
			Assert.Equal("26/11/2018", chapters[0].ReleaseDate);
			Assert.Equal(@"https://unionleitor.top/leitor/Solo_Leveling/00", chapters[0].ChapterUrl);
		}
		
		[Fact]
		public void GetPaginasTest()
		{
			var pages = _crawler.GetPages(@"http://unionmangas.top/leitor/Solo_Leveling/00");

			Assert.NotNull(pages);
			Assert.NotNull(pages[0].PageUrl);
		}

		[Fact]
		public void SearchTest()
		{
			var mangas = _crawler.Search("Solo Leveling");

			Assert.Equal("Solo Leveling", mangas[0].Titulo);
			Assert.Equal("Solo Leveling (Novel)", mangas[1].Titulo);
		}

	}
}
