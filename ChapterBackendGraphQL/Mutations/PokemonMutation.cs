using ChapterBackendGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ChapterBackendGraphQL.Mutations
{
    public class PokemonMutation
    {
        private readonly AppDbContext _context;
        public PokemonMutation(IDbContextFactory<AppDbContext> factory) 
        {
            _context = factory.CreateDbContext();
        }

        public async Task<Pokemon> AddPokemon(PokemonInput input)
        {
            var types = input.Types.Select(x => new PokemonType { Name = x.Name, PokemonId = input.Id }).ToList();

            var pokemon = new Pokemon
            {
                Id = input.Id,
                Identifier = input.Identifier,
                BaseExperience = input.BaseExperience,
                Height = input.Height,
                Weight = input.Weight,
                SpeciesId = input.SpeciesId,
                Types = types
            };

            await _context.AddAsync(pokemon);
            await _context.SaveChangesAsync();
            return pokemon;
        }
    }
}


public class PokemonInput
{
    public int Id { get; set; }
    public string Identifier { get; set; } = string.Empty;
    public int SpeciesId { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public int BaseExperience { get; set; }
    public virtual List<TypeInput> Types { get; set; } = new();
}

public class TypeInput
{
    public string Name { get; set; } = string.Empty;
}