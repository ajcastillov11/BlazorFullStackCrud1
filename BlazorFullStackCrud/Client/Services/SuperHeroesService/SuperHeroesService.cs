using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.SuperHeroesService
{
    public class SuperHeroesService : ISuperHeroesService
    {
        private readonly HttpClient _http;

        public SuperHeroesService(HttpClient httpClient)
        {
            _http = httpClient;
        }


        public List<SuperHero> Heroes { get; set; } = new();
        public List<Comic> Comics { get; set; } = new();

        public async Task CreateHero(SuperHero entity)
        {
            var result = await _http.PostAsJsonAsync("api/SuperHero", entity);
            var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
        }

        public Task DeleteHero(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetComics()
        {
            var result = await _http.GetFromJsonAsync<List<Comic>>("api/SuperHero/comics");
            if (result != null)
                Comics = result;
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var result = await _http.GetFromJsonAsync<SuperHero>($"api/SuperHero/{id}");
            if (result != null)
                return result;
            throw new Exception("No encontrado!"); 

        }

        public async Task GetSuperHeroes()
        {
            var result = await _http.GetFromJsonAsync<List<SuperHero>>("api/SuperHero");
            if (result != null)
                Heroes = result;
        }

        public Task UpdateHero(SuperHero entity)
        {
            throw new NotImplementedException();
        }
    }
}
