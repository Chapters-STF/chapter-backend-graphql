using System.ComponentModel.DataAnnotations;

namespace ChapterBackendGraphQL.Models
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public int SpeciesId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int BaseExperience { get; set; }
        public virtual List<PokemonType> Types { get; set; } = new();
    }
}
