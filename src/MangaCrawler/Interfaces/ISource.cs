namespace MangaCrawler
{
	public interface ISource
	{
		string GetMangasAscendingOrderUrl();
		string GetMangasVisualizationOrderUrl();
		string GetChapterListPath();
		string GetChapterPagesPath();
		string GetMangaListPath();
		string GetMangaListPath(int i);
		string GetSearchUrl();
	}
}
