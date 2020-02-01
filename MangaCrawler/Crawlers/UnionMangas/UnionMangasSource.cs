using System;

namespace MangaCrawler
{
	public class UnionMangasSource : ISource
	{
		public string GetMangasAscendingOrderUrl()
		{
			return @"https://unionleitor.top/lista-mangas/a-z";
		}

		public string GetMangasVisualizationOrderUrl()
		{
			return @"https://unionleitor.top/lista-mangas/visualizacoes";
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
	}
}
