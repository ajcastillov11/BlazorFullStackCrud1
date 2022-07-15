namespace BlazorFullStackCrud.Server.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comic>().HasData(
                new Comic { Id = 1, Name = "Marvel" },
                new Comic { Id = 2, Name = "DC" }
            );
            modelBuilder.Entity<SuperHero>().HasData(
                 new SuperHero
                 {
                     Id = 1,
                     FirstName = "Peter",
                     LastName = "Parker",
                     ComicID = 1,
                     HeroName = "Spiderman"
                 },
                 new SuperHero
                 {
                     Id = 2,
                     FirstName = "Bruce",
                     LastName = "Wayne",
                     ComicID = 2,
                     HeroName = "Batman"
                 }
                );
        }


        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Comic> Comics { get; set; }

    }
}
