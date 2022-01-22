using Graphql.PoC.Server.Application.Modules.Persons;
using Graphql.PoC.Server.HotChocolate.Resolvers;
using Graphql.PoC.Server.HotChocolate.Resolvers.Persons;
using Graphql.PoC.Server.HotChocolate.Root;
using Graphql.PoC.Server.Infra.Context;
using Graphql.PoC.Server.Infra.Entities.Bases;
using HotChocolate.Execution.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPooledDbContextFactory<InMemoryContext>(options =>
{
   options.UseInMemoryDatabase("db_teste");
});

builder.Services.AddControllers();
var graphqlBuilder = builder.Services
       .AddGraphQLServer()
       .AddQueryType<Query>()
       .AddMutationType<Mutation>()
       //.AddTypeExtension<PersonQueryResolver>()
       .AddMutationConventions()
       .AddProjections()
       .AddFiltering()
       .AddSorting();
RegisterAllResolvers(graphqlBuilder, Assembly.GetExecutingAssembly());

builder.Services.AddScoped<PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });

app.Run();





static void RegisterAllResolvers(IRequestExecutorBuilder graphqlBuilder, params Assembly[] assemblies)
{
    var types = assemblies.SelectMany(a => a.GetExportedTypes())
                          .Where(c => c.IsClass && 
                                      !c.IsAbstract && 
                                      c.IsPublic && 
                                      c.GetCustomAttribute<ExtendObjectTypeAttribute>() is not null &&
                                      c.GetCustomAttribute<ExtendObjectTypeAttribute>()!.ExtendsType == typeof(Query));

    foreach (var type in types)
        graphqlBuilder.AddTypeExtension(type);
}