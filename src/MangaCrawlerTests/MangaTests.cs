using MangaCrawler;
using Microsoft.Extensions.Caching.Memory;
using Xunit;

namespace MangaCrawlerTests
{
	public class MangaTests
	{
		private IWebCrawler _crawler;
		private ISource _source;

		public MangaTests()
		{
			var memoryCache = new MemoryCache(new MemoryCacheOptions());
			
			_source = new UnionMangasSource();
			_crawler = new UnionMangasCrawler(_source, memoryCache);
		}

		[Fact]
		public void GetMangasAscendingOrderTest()
		{
			var page = 1;
			var titles = _crawler.GetMangasAscendingOrder(page);

			Assert.True(!string.IsNullOrEmpty(titles[0].MangaCoverUrl));
			Assert.True(!string.IsNullOrEmpty(titles[0].MangaName));
			Assert.True(!string.IsNullOrEmpty(titles[0].MangaUrl));
		}

		[Fact]
		public void GetMangasVisualizationOrderTest()
		{
			var page = 1;
			var titles = _crawler.GetMangasVisualizationOrder(page);

			Assert.True(!string.IsNullOrEmpty(titles[0].MangaCoverUrl));
			Assert.True(!string.IsNullOrEmpty(titles[0].MangaName));
			Assert.True(!string.IsNullOrEmpty(titles[0].MangaUrl));
		}

		[Fact]
		public void GetMangaByIdTest()
		{
			var manga = _crawler.GetMangaById("solo-leveling");

			Assert.Equal("Cap. 00", manga.Chapters[0].Name);
			Assert.Equal("26/11/2018", manga.Chapters[0].ReleaseDate);
			Assert.Equal(@"https://unionleitor.top/leitor/Solo_Leveling/00", manga.Chapters[0].ChapterUrl);
		}

		[Fact]
		public void GetMangaByUrlTest()
		{
			var manga = _crawler.GetMangaByUrl(@"https://unionleitor.top/manga/solo-leveling");

			Assert.Equal("Cap. 00", manga.Chapters[0].Name);
			Assert.Equal("26/11/2018", manga.Chapters[0].ReleaseDate);
			Assert.Equal(@"https://unionleitor.top/leitor/Solo_Leveling/00", manga.Chapters[0].ChapterUrl);
		}
		
		[Fact]
		public void GetPagesTest()
		{
			var pages = _crawler.GetPages(@"http://unionmangas.top/leitor/Solo_Leveling/00");

			Assert.NotNull(pages);
			Assert.True(!string.IsNullOrEmpty(pages[0].PageUrl));
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
