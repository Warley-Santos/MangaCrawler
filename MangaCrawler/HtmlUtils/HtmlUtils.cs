using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangaCrawler
{
	public class HtmlUtils
	{
		public static HtmlDocument LoadUrl(string url)
		{
			return new HtmlWeb().Load(url);
		}

		public static HtmlNodeCollection GetHtmlNodes(HtmlDocument htmlDoc, string xPath)
		{
			return htmlDoc.DocumentNode.SelectNodes(xPath);
		}
	}
}
