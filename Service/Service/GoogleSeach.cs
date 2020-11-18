using Google.Apis.Services;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class GoogleSeach : ControllerBase, IGoogleSeach
    {
        public GoogleSeach()
        {

        }
        public async Task<IActionResult> Search(string busca)
        {
            string body = "",pagina = $"https://google-search3.p.rapidapi.com/api/v1/search/q="+ busca+"&num=10";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(pagina),
                Headers =
                            {
                                { "x-rapidapi-key", "fa2bb285a6msh9f47e7925b1a897p1adef7jsnd2643f5f0dbb" },
                                { "x-rapidapi-host", "google-search3.p.rapidapi.com" },
                            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }
            return Ok(body);
        }
    }
}
