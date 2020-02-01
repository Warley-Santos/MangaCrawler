namespace MangaCrawler.Model
{
	public class Page
	{
		private int _pageNumber;
		private string _pageUrl;

		public Page(int pageNumber, string pageUrl)
		{
			_pageNumber = pageNumber;
			_pageUrl = pageUrl;
		}

		public int PageNumber { get => _pageNumber; set => _pageNumber = value; }
		public string PageUrl { get => _pageUrl; set => _pageUrl = value; }
	}
}
