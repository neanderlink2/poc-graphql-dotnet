using Graphql.PoC.Server.HotChocolate.Resolvers.Bases;
using Graphql.PoC.Server.HotChocolate.Root;
using Graphql.PoC.Server.Infra.Context;
using Graphql.PoC.Server.Infra.Entities;

namespace Graphql.PoC.Server.HotChocolate.Resolvers.PersonTypes
{
    [ExtendObjectType(typeof(Query))]
    public class PersonTypeQueryResolver : SimpleResolver<PersonType>
    {
        /// <summary>
        /// Busca todos os tipos de pessoa.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        [GraphQLName("personTypes")]
        public override IEnumerable<PersonType> GetAll([ScopedService] InMemoryContext dbContext) =>
            base.GetAll(dbContext);

        /// <summary>
        /// Busca um tipo de pessoa.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        [GraphQLName("personType")]
        public override IEnumerable<PersonType> FindOne([ScopedService] InMemoryContext dbContext) =>
            base.FindOne(dbContext);
    }
}
