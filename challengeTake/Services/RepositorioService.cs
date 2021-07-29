using challengeTake.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace challengeTake.Services
{
    public class RepositorioService : IRepositorioService
    {
        private readonly HttpClient _httpClient;

        public RepositorioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<object> GetRepositorios()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "orgs/takenet/repos");

            var response = _httpClient.SendAsync(request).GetAwaiter().GetResult();

            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStringAsync();

            var content = JsonConvert.DeserializeObject<List<Repositorio>>(responseStream);

            var repositorios = content.Where(r => r.language == "C#").Take(5).ToList();

            var repositoriosFormatados = new
            {
                repositorio1 = repositorios[0].full_name,
                description1 = repositorios[0].description,
                repositorio2 = repositorios[1].full_name,
                description2 = repositorios[1].description,
                repositorio3 = repositorios[2].full_name,
                description3 = repositorios[2].description,
                repositorio4 = repositorios[3].full_name,
                description4 = repositorios[3].description,
                repositorio5 = repositorios[4].full_name,
                description5 = repositorios[4].description,
            };

            return repositoriosFormatados;
        }
    }
}
