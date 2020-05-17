namespace MangaCrawler
{
	public interface ISource
	{
		string GetAscendingOrderUrl();
		string GetVisualizationOrderUrl();
		string GetMangaNamePath();
		string GetChapterListPath();
		string GetChapterPagesPath();
		string GetMangaListPath();
		string GetMangaListPath(int i);
		string GetSearchUrl();
		string GetBaseUrlTitle();
	}
}
