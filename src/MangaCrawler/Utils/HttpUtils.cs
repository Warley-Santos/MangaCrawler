using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MangaCrawler
{
	class HttpUtils
	{
		public static async Task<string> GetURI(Uri u)
		{
			var response = string.Empty;
			using (var client = new HttpClient())
			{
				HttpResponseMessage result = await client.GetAsync(u);
				if (result.IsSuccessStatusCode)
				{
					response = await result.Content.ReadAsStringAsync();
				}
			}
			return response;
		}
	}
}
