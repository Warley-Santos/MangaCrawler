using Xunit;
using MangaCrawler;

namespace MangaCrawlerTests
{
	public class MangaTests
	{
		private IWebCrawler Crawler;

		public MangaTests()
		{
			var source = new UnionMangasSource();
			Crawler = new UnionMangasCrawler(source);
		}

		[Fact]
		public void GetTitulosAscendingTest()
		{
			var titles = Crawler.GetMangasAscendingOrder(true);

			Assert.NotNull(titles[0].MangaCoverUrl);
			Assert.NotNull(titles[0].MangaName);
			Assert.NotNull(titles[0].MangaUrl);
		}

		[Fact]
		public void GetMangasVisualizationOrderTest()
		{
			var titles = Crawler.GetMangasVisualizationOrder(true);

			Assert.NotNull(titles[0].MangaCoverUrl);
			Assert.NotNull(titles[0].MangaName);
			Assert.NotNull(titles[0].MangaUrl);
		}

		[Fact]
		public void GetCapitulosUrlTest()
		{
			var chapters = Crawler.GetChapters(@"https://unionleitor.top/manga/solo-leveling");

			Assert.Equal("Cap. 00", chapters[0].Name);
			Assert.Equal("26/11/2018", chapters[0].ReleaseDate);
			Assert.Equal(@"https://unionleitor.top/leitor/Solo_Leveling/00", chapters[0].ChapterUrl);
		}
		
		[Fact]
		public void GetPaginasTest()
		{
			var pages = Crawler.GetPages(@"http://unionmangas.top/leitor/Solo_Leveling/00");

			Assert.NotNull(pages);
			Assert.NotNull(pages[0].PageUrl);
		}

		[Fact]
		public void SearchTest()
		{
			var mangas = Crawler.Search("Solo Leveling");

			Assert.Equal("Solo Leveling", mangas[0].Titulo);
			Assert.Equal("Solo Leveling (Novel)", mangas[1].Titulo);
		}

	}
}
