using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<Comic> comics = new()
        {
            new Comic { Id = 1,Name = "Marvel"},
            new Comic { Id = 1,Name = "DC"}
        };


        public static List<SuperHero> superHeroes = new()
        {
            new SuperHero { 
                Id= 1,
                FirstName = "Peter", 
                LastName="Parker",
                ComicID=1,
                HeroName="Spiderman",
                Comic = comics[0]
            },
             new SuperHero {
                Id= 2,
                FirstName = "Bruce",
                LastName="Wayne",
                ComicID=2,
                HeroName="Batman",
                Comic = comics[1]
            }
        };


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperHero>>> GetSuperHeroes()
        {
            return await Task.FromResult(Ok(superHeroes));
        }


        /// <summary>
        /// Gets the single hero.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int Id)
        {
            var hero = superHeroes.FirstOrDefault(x => x.Id.Equals(Id));

            if (hero == null)
            {
                return NotFound("Not found");
            }

            return await Task.FromResult(Ok(hero));
        }

    }
}
