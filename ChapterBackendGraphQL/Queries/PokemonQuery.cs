using ChapterBackendGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ChapterBackendGraphQL.Queries
{
    public class PokemonQuery
    {
        private readonly AppDbContext _context;
        public PokemonQuery(IDbContextFactory<AppDbContext> factory)
        {
            _context = factory.CreateDbContext();
        }

        [GraphQLDescription("Get All Pokemons")]
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Pokemon> GetPokemons()
        {
            var pokemons = _context.Pokemons;
            return pokemons;
        }

        [GraphQLDescription("Get Pokemon by Name")]
        [UseDbContext(typeof(AppDbContext))]
        public Pokemon? GetPokemon([GraphQLName("name")] string name)
        {
            var pokemon = _context.Pokemons.Where(p => p.Identifier == name).FirstOrDefault();
            return pokemon;
        }

        [GraphQLDescription("Get Pokemon by Number")]
        [UseDbContext(typeof(AppDbContext))]
        public Pokemon? GetPokedex([GraphQLName("id")] int number)
        {
            var pokemon = _context.Pokemons.FirstOrDefault(p => p.Id == number);
            return pokemon;
        }
    }
}
