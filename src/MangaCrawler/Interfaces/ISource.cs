namespace MangaCrawler
{
	public interface ISource
	{
		public string GetMangasAscendingOrderUrl();
		public string GetMangasVisualizationOrderUrl();
		public string GetChapterListPath();
		public string GetChapterPagesPath();
		public string GetMangaListPath();
		public string GetMangaListPath(int i);
		public string GetSearchUrl();
	}
}
