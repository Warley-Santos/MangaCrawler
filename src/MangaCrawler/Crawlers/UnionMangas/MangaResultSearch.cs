using System;
using System.Collections.Generic;
using System.Text;

namespace MangaCrawler.Model
{

	public class MangaResultList
	{
		public List<MangaResultSearch> items { get; set; }
	}
	public class MangaResultSearch
	{
		public string Imagem { get; set; }
		public string Titulo { get; set; }
		public string Url { get; set; }
		public string Autor { get; set; }
		public string Artista { get; set; }
		public string Capitulo { get; set; }
	}
}
