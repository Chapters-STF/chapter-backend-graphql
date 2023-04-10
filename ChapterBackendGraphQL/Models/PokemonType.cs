using System.ComponentModel.DataAnnotations;

namespace ChapterBackendGraphQL.Models
{
    public class PokemonType
    {
        [Key]
        public int Id { get; set; }
        [GraphQLDescription("The Name of the Pokémon Type")]
        public string Name { get; set; } = string.Empty;
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; } = new();
    }
}
