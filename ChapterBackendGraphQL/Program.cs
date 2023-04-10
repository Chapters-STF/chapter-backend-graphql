using ChapterBackendGraphQL;
using ChapterBackendGraphQL.Mutations;
using ChapterBackendGraphQL.Queries;
using ChapterBackendGraphQL.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
var dbpath = System.IO.Path.Join(path, "pkmn.db");
var connectionString = $"Data Source={dbpath}";
builder.Services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlite(connectionString));

builder.Services
    .AddGraphQLServer()
    .AddType<PokemonGQLType>()
    .AddType<TypeGQLType>()
    .AddQueryType<PokemonQuery>()
    .AddMutationType<PokemonMutation>()
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

var app = builder.Build();

app.MapGraphQL();

app.Run();