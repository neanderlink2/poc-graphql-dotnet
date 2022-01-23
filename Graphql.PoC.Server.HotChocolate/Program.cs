using Graphql.PoC.Server.Application.Modules.Persons;
using Graphql.PoC.Server.HotChocolate.Root;
using Graphql.PoC.Server.Infra.Context;
using HotChocolate.Execution.Configuration;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPooledDbContextFactory<InMemoryContext>(options =>
{
   options.UseInMemoryDatabase("db_teste");

    var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder
        .AddConsole((options) => { })
        .AddFilter((category, level) =>
            category == DbLoggerCategory.Database.Command.Name
            && level == LogLevel.Information);
    });
    options.UseLoggerFactory(loggerFactory)
        .EnableSensitiveDataLogging(true)
        .LogTo(Console.WriteLine);

});

builder.Services.AddControllers();
var graphqlBuilder = builder.Services
       .AddGraphQLServer()
       .AddQueryType<Query>()
       .AddMutationType<Mutation>()
       .AddInstrumentation()
       //.AddTypeExtension<PersonQueryResolver>()
       .AddMutationConventions()
       .AddProjections()
       .AddFiltering()
       .AddSorting();
RegisterAllResolvers(graphqlBuilder, Assembly.GetExecutingAssembly());

builder.Services.AddScoped<PersonService>();

builder.Services.AddOpenTelemetryTracing(
    b =>
    {
        b.AddHttpClientInstrumentation();
        b.AddAspNetCoreInstrumentation();
        b.AddHotChocolateInstrumentation();
        b.AddJaegerExporter(options =>
        {
            options.AgentHost = "localhost";
            options.AgentPort = 6831;
        });
    });

builder.Logging.AddOpenTelemetry(
    b =>
    {
        b.IncludeFormattedMessage = true;
        b.IncludeScopes = true;
        b.ParseStateValues = true;
        b.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("Demo"));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

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
                                      (c.GetCustomAttribute<ExtendObjectTypeAttribute>()!.ExtendsType == typeof(Query) ||
                                      c.GetCustomAttribute<ExtendObjectTypeAttribute>()!.ExtendsType == typeof(Mutation)));

    foreach (var type in types)
        graphqlBuilder.AddTypeExtension(type);
}