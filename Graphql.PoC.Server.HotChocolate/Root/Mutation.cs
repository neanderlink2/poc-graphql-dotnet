using Graphql.PoC.Server.Application.Modules.Persons;
using Graphql.PoC.Server.Infra.Entities;

namespace Graphql.PoC.Server.HotChocolate.Root
{
    public class Mutation
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
