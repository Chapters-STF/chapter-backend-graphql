using ChapterBackendGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace ChapterBackendGraphQL.Resolvers
{
    public class PokemonTypeResolver
    {
        private readonly AppDbContext _context;
        public PokemonTypeResolver(IDbContextFactory<AppDbContext> factory) 
        { 
            _context = factory.CreateDbContext();
        }

        public IQueryable<PokemonType> GetTypes([Parent] Pokemon pokemon)
        {
            return _context.Types.Where(p => p.PokemonId == pokemon.Id);
        }
    }
}
