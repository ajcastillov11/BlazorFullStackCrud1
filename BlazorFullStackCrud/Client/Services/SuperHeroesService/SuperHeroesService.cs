using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.SuperHeroesService
{
    public class SuperHeroesService : ISuperHeroesService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public SuperHeroesService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _http = httpClient;
            _navigationManager = navigationManager;
        }


        public List<SuperHero> Heroes { get; set; } = new();
        public List<Comic> Comics { get; set; } = new();

        public async Task CreateHero(SuperHero entity)
        {
            var result = await _http.PostAsJsonAsync("api/SuperHero", entity);
            await SetHeroes(result);
        }

        public async Task DeleteHero(int id)
        {
            var result = await _http.DeleteAsync($"api/SuperHero/{id}");
            await SetHeroes(result);
        }

        private async Task SetHeroes(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            Heroes = response;
            _navigationManager.NavigateTo("superheroes");
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

        public async Task UpdateHero(SuperHero entity)
        {
            var result = await _http.PutAsJsonAsync($"api/SuperHero/{entity.Id}", entity);
            await SetHeroes(result);
        }
    }
}
