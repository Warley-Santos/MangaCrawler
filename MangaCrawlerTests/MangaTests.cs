using System;
using Xunit;
using MangaCrawler;

namespace MangaCrawlerTests
{
	public class MangaTests
	{
	
		[Fact]
		public void GetTitulosAscendingTest()
		{
			var source = new UnionMangasSource();
			var crawler = new UnionMangasCrawler(source);

			var titles = crawler.GetMangasAscendingOrder();

			Assert.NotNull(titles[0].MangaCoverUrl);
			Assert.NotNull(titles[0].MangaName);
			Assert.NotNull(titles[0].MangaUrl);
		}

		[Fact]
		public void GetCapitulosUrlTest()
		{
			var source = new UnionMangasSource();
			var crawler = new UnionMangasCrawler(source);

			var chapters = crawler.GetChapters(@"https://unionleitor.top/manga/solo-leveling");

			Assert.Equal("Cap. 00", chapters[0].Name);
			Assert.Equal("26/11/2018", chapters[0].ReleaseDate);
			Assert.Equal(@"http://unionmangas.top/leitor/Solo_Leveling/00", chapters[0].ChapterUrl);
		}
		
		[Fact]
		public void GetPaginasTest()
		{
			var source = new UnionMangasSource();
			var crawler = new UnionMangasCrawler(source);

			var pages = crawler.GetPages(@"http://unionmangas.top/leitor/Solo_Leveling/00");

			Assert.NotNull(pages);
			Assert.NotNull(pages[0].PageUrl);
		}
	}
}
