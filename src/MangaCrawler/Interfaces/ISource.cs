namespace MangaCrawler
{
	public interface ISource
	{
		string GetAscendingOrderUrl();
		string GetVisualizationOrderUrl();
		string GetChapterListPath();
		string GetChapterPagesPath();
		string GetMangaListPath();
		string GetMangaListPath(int i);
		string GetSearchUrl();
	}
}
