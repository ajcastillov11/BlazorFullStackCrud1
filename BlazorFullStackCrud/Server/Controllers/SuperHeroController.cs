using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly AppDataContext _context;
        public SuperHeroController(AppDataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperHero>>> GetSuperHeroes()
        {
            var heroes = await _context.SuperHeroes
                .Include(c=>c.Comic)
                .ToListAsync();
            return Ok(heroes);

        }


        //comics
        [HttpGet("comics")]
        public async Task<ActionResult<IEnumerable<Comic>>> GetComics()
        {
            var comics = await _context.Comics.ToListAsync();
            return Ok(comics);
        }

        /// <summary>
        /// Gets the single hero.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int Id)
        {
            var hero = await _context.SuperHeroes
                .Include(x=>x.Comic)
                .FirstOrDefaultAsync(x => x.Id.Equals(Id));

            if (hero == null)
                return NotFound("Not found");


            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero superHero)
        {

            superHero.Comic = null;
            _context.SuperHeroes.Add(superHero);
            await _context.SaveChangesAsync();


            return Ok(await GetDbHeroes());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero superHero, int id)
        {

            var dbHero = await _context.SuperHeroes.FirstOrDefaultAsync(x=>x.Id == id);
            if (dbHero == null) return NotFound("Not found");

            dbHero.FirstName = superHero.FirstName;
            dbHero.LastName = superHero.LastName;
            dbHero.HeroName = superHero.HeroName;
            dbHero.ComicID = superHero.ComicID;

            _context.SuperHeroes.Update(dbHero);
            await _context.SaveChangesAsync();
  

            return Ok(await GetDbHeroes());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {

            var dbHero = await _context.SuperHeroes.FirstOrDefaultAsync(x => x.Id == id);
            if (dbHero == null) return NotFound("Not found");

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();


            return Ok(await GetDbHeroes());
        }

        private async Task<List<SuperHero>> GetDbHeroes() 
            => await _context.SuperHeroes.Include(sh=>sh.Comic).ToListAsync();

    }
}
