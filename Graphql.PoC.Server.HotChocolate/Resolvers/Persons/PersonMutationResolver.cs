using Graphql.PoC.Server.Application.Modules.Persons;
using Graphql.PoC.Server.HotChocolate.Root;
using Graphql.PoC.Server.Infra.Entities;

namespace Graphql.PoC.Server.HotChocolate.Resolvers.Persons
{
    [ExtendObjectType(typeof(Mutation))]
    public class PersonMutationResolver
    {
        /// <summary>
        /// Cria uma nova pessoa.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="input">Input com as informações do usuário</param>
        /// <returns></returns>
        [UseMutationConvention]
        public async Task<Person> CreatePerson(
            [Service] PersonService service,
            CreatePersonInput input)
        {
            var result = await service.CreatePerson(input);
            return result;
        }
    }
}
