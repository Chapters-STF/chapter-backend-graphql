using ChapterBackendGraphQL.Models;
using ChapterBackendGraphQL.Resolvers;

namespace ChapterBackendGraphQL.Types
{
    public class PokemonGQLType : ObjectType<Pokemon>
    {
        protected override void Configure(IObjectTypeDescriptor<Pokemon> descriptor)
        {
            descriptor.Description("A Pokémon");

            descriptor.Field(p => p.Types)
            .ResolveWith<PokemonTypeResolver>(p => p.GetTypes(default!))
            .UseDbContext<AppDbContext>();
        }
    }
}
