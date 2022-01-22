using Graphql.PoC.Server.HotChocolate.Resolvers.Bases;
using Graphql.PoC.Server.HotChocolate.Root;
using Graphql.PoC.Server.Infra.Context;
using Graphql.PoC.Server.Infra.Entities;

namespace Graphql.PoC.Server.HotChocolate.Resolvers.Persons
{
    [ExtendObjectType(typeof(Query))]
    public class PersonQueryResolver : PagingResolver<Person>
    {
        /// <summary>
        /// Busca todas as pessoas.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        [GraphQLName("persons")]
        public override IEnumerable<Person> GetAll([ScopedService] InMemoryContext dbContext) =>
            base.GetAll(dbContext);

        /// <summary>
        /// Busca uma pessoa por ID.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        [GraphQLName("person")]
        public override IEnumerable<Person> FindOne([ScopedService] InMemoryContext dbContext) =>
            base.FindOne(dbContext);
    }
}
