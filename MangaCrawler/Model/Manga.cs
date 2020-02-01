namespace MangaCrawler.Model
{
	public class Manga
	{
		private string _mangaName;
		private string _mangaCoverUrl;
		private string _mangaUrl;

		public Manga(string MangaName, string MangaCoverUrl, string MangaUrl)
		{
			this.MangaName = MangaName;
			this.MangaCoverUrl = MangaCoverUrl;
			this.MangaUrl = MangaUrl;
		}

		public string MangaName { get => _mangaName; set => _mangaName = value; }
		public string MangaCoverUrl { get => _mangaCoverUrl; set => _mangaCoverUrl = value; }
		public string MangaUrl { get => _mangaUrl; set => _mangaUrl = value; }
	}
}
