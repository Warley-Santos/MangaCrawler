using System;
using System.Collections.Generic;
using System.Text;

namespace MangaCrawler.Model
{
	
	public class MangaProfile
	{
		public string MangaName { get; set; }
		public List<Chapter> Chapters { get; set; }

		public MangaProfile()
		{
			this.Chapters = new List<Chapter>();
		}
	}
		
	public class Chapter
	{
		private string _chapterName;
		private string _releaseDate;
		private string _url;

		public Chapter(string chapterName, string releaseDate, string url)
		{
			_chapterName = chapterName;
			_releaseDate = releaseDate;
			_url = url;
		}

		public string Name { get => _chapterName; set => _chapterName = value; }
		public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
		public string ChapterUrl { get => _url; set => _url = value; }
	}
}
