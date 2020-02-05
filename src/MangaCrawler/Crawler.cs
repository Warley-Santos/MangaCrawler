using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MangaCrawler
{
	class Crawler
	{

		static void Main(string[] args)
		{

			var t = Task.Run(() => GetURI(new Uri("https://unionleitor.top/assets/busca.php?q=solo")));
			t.Wait();

			Console.WriteLine(t.Result);
			Console.ReadLine();
		}

		static async Task<string> GetURI(Uri u)
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
