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
        public List<Comic> comics { get; set; } = new();

        public Task<List<SuperHero>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetComics()
        {
            throw new NotImplementedException();
        }

        public Task<SuperHero> GetSingleHero(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetSuperHeroes()
        {
            var result = await _http.GetFromJsonAsync<List<SuperHero>>("api/SuperHero");
            if (result != null)
                Heroes = result;
        }
    }
}
