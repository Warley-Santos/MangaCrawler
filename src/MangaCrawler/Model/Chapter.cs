using System;
using System.Collections.Generic;
using System.Text;

namespace MangaCrawler.Model
{
	public class Chapter
	{
		private string _name;
		private string _releaseDate;
		private string _url;

		public Chapter(string name, string releaseDate, string url)
		{
			_name = name;
			_releaseDate = releaseDate;
			_url = url;
		}

		public string Name { get => _name; set => _name = value; }
		public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
		public string ChapterUrl { get => _url; set => _url = value; }
	}
}
