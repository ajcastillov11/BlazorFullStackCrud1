namespace BlazorFullStackCrud.Client.Services.SuperHeroesService
{
    public interface ISuperHeroesService
    {
        List<SuperHero> Heroes { get; set; }
        List<Comic> comics { get; set; }

        Task GetComics();
        Task GetSuperHeroes();
        Task<SuperHero> GetSingleHero(int id);
    
            

    }
}
