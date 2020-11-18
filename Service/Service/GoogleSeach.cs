using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Dto;
using Microsoft.AspNetCore.Http;

namespace Service.Service
{
    public class GoogleSeach : ControllerBase, IGoogleSeach
    {
        public GoogleSeach()
        {

        }
        public async Task<IActionResult> Search(string busca)
        {
            try
            {
                string body = "", pagina = $"https://google-search3.p.rapidapi.com/api/v1/search/q=" + busca + "&num=10";
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(pagina),
                    Headers =
                            {
                                { "x-rapidapi-key", "fa2bb285a6msh9f47e7925b1aaUoMUyT56MQukAn6oZKLfo7SN3aJTvb" },
                                { "x-rapidapi-host", "google-search3.p.rapidapi.com" },
                            },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    body = await response.Content.ReadAsStringAsync();
                }
                var jsonString = JsonSerializer.Deserialize<ResultadosGoogle>(body);
                return Ok(jsonString);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest);
            }         
        }
    }
}
