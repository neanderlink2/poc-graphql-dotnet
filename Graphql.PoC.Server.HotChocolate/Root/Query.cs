using Graphql.PoC.Server.Application.Modules.Persons;
using Graphql.PoC.Server.Infra.Context;
using Graphql.PoC.Server.Infra.Entities;

namespace Graphql.PoC.Server.HotChocolate.Root
{
    public class Query
    {       
        ///// <summary>
        ///// Busca todos os tipos de pessoa.
        ///// </summary>
        ///// <param name="dbContext"></param>
        ///// <returns></returns>
        //[UseDbContext(typeof(InMemoryContext))]
        //[UseProjection]
        //[UseFiltering]
        //[UseSorting]
        //public IEnumerable<PersonType> GetPersonTypes([ScopedService] InMemoryContext dbContext) =>
        //    dbContext.Set<PersonType>();

        ///// <summary>
        ///// Busca um tipo de pessoa.
        ///// </summary>
        ///// <param name="dbContext"></param>
        ///// <returns></returns>
        //[UseDbContext(typeof(InMemoryContext))]
        //[UseFirstOrDefault]
        //[UseProjection]
        //[UseFiltering]
        //public IEnumerable<PersonType> GetPersonType([ScopedService] InMemoryContext dbContext) =>
        //    dbContext.Set<PersonType>();


        ///// <summary>
        ///// Busca todos os dependentes.
        ///// </summary>
        ///// <param name="dbContext"></param>
        ///// <returns></returns>
        //[UseDbContext(typeof(InMemoryContext))]
        //[UseProjection]
        //[UseFiltering]
        //[UseSorting]
        //public IEnumerable<Dependent> GetDependents([ScopedService] InMemoryContext dbContext) =>
        //    dbContext.Set<Dependent>();

        ///// <summary>
        ///// Busca um dependente.
        ///// </summary>
        ///// <param name="dbContext"></param>
        ///// <returns></returns>
        //[UseDbContext(typeof(InMemoryContext))]
        //[UseFirstOrDefault]
        //[UseProjection]
        //[UseFiltering]
        //public IEnumerable<Dependent> GetDependent([ScopedService] InMemoryContext dbContext) =>
        //    dbContext.Set<Dependent>();
    }
}
