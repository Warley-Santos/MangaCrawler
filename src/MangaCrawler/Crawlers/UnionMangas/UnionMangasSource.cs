using System;

namespace MangaCrawler
{
	public class UnionMangasSource : ISource
	{
		public string GetAscendingOrderUrl()
		{
			return @"https://unionleitor.top/lista-mangas/a-z";
		}

		public string GetVisualizationOrderUrl()
		{
			return @"https://unionleitor.top/lista-mangas/visualizacoes";
		}

		public string GetMangaNamePath()
		{
			return "/html/body/div[1]/div[1]/div[1]/div[1]/div/h2";
		}
		public string GetChapterListPath()
		{
			return "//div[@class = ('row lancamento-linha')]" +
					"/div[@class = ('col-xs-6 col-md-6')]";
		}

		public string GetChapterPagesPath()
		{
			return "//body/article[@class = ('container backTop')]" +
					"/div[@class = ('row')]" +
					"/div[@class = ('col-sm-12 text-center')]" +
					"/img";
		}

		public string GetMangaListPath()
		{
			return "//body/div[@class = ('container')]" +
					"/div[@class = ('row')]" +
					"/div[@class = ('col-md-8 tamanho-bloco-perfil')]" +
					"/div[@class = ('row')]" +
					"/div[@class = ('col-md-3 col-xs-6 text-center bloco-manga')]";
		}

		public string GetMangaListPath(int index)
		{
			return GetMangaListPath() + String.Concat("[", index, "]");
		}

		public string GetSearchUrl()
		{
			return @"https://unionleitor.top/assets/busca.php?q=";
		}
		
		public string GetBaseUrlTitle()
		{
			return @"https://unionleitor.top/perfil-manga/";
		}
	}
}
