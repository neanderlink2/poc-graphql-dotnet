using Graphql.PoC.Server.Application.Modules.Persons;
using Graphql.PoC.Server.HotChocolate.Root;
using Graphql.PoC.Server.Infra.Entities;

namespace Graphql.PoC.Server.HotChocolate.Resolvers.PersonTypes
{
    [ExtendObjectType(typeof(Mutation))]
    public class PersonTypeMutationResolver
    {
        /// <summary>
        /// Cria um novo tipo de pessoa.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="name">Nome/Descrição do novo tipo de pessoa.</param>
        /// <returns></returns>
        [UseMutationConvention]
        public async Task<PersonType> CreatePersonType(
            [Service] PersonService service,
            string name)
        {
            var result = await service.CreatePersonType(name);
            return result;
        }
    }
}
