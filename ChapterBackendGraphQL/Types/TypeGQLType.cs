using ChapterBackendGraphQL.Models;

namespace ChapterBackendGraphQL.Types
{
    public class TypeGQLType : ObjectType<PokemonType>
    {
        protected override void Configure(IObjectTypeDescriptor<PokemonType> descriptor)
        {
            descriptor.Description("A Pokémon Type");
            descriptor.Field(p => p.Id).Ignore();
            descriptor.Field(p => p.PokemonId).Ignore();
            descriptor.Field(p => p.Pokemon).Ignore();
        }
    }
}
