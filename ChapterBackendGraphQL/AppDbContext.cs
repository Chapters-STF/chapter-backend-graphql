using ChapterBackendGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace ChapterBackendGraphQL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonType> Types { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
              .HasMany(p => p.Types)
              .WithOne(t => t.Pokemon)
              .HasForeignKey(t => t.PokemonId);

            modelBuilder.Entity<PokemonType>()
              .HasOne(t => t.Pokemon)
              .WithMany(p => p.Types)
              .HasForeignKey(t => t.PokemonId);
        }
    }
}
