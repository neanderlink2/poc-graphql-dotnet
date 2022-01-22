using Graphql.PoC.Server.HotChocolate.Resolvers.Bases;
using Graphql.PoC.Server.HotChocolate.Root;
using Graphql.PoC.Server.Infra.Context;
using Graphql.PoC.Server.Infra.Entities;

namespace Graphql.PoC.Server.HotChocolate.Resolvers.Dependents
{
    [ExtendObjectType(typeof(Query))]
    public class DependentsQueryResolver : PagingResolver<Dependent>
    {
        /// <summary>
        /// Busca todos os dependentes.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        [GraphQLName("dependents")]
        public override IEnumerable<Dependent> GetAll([ScopedService] InMemoryContext dbContext) =>
            base.GetAll(dbContext);

        /// <summary>
        /// Busca um dependente.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        [GraphQLName("dependent")]
        public override IEnumerable<Dependent> FindOne([ScopedService] InMemoryContext dbContext) =>
            base.FindOne(dbContext);
    }
}
