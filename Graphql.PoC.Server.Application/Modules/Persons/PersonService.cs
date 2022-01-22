using Graphql.PoC.Server.Infra.Context;
using Graphql.PoC.Server.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Graphql.PoC.Server.Application.Modules.Persons
{
    public class PersonService
    {
        private readonly InMemoryContext _inMemoryContext;

        public PersonService(IDbContextFactory<InMemoryContext> dbContextFactory)
        {
            _inMemoryContext = dbContextFactory.CreateDbContext();
        }

        public async Task<Person> CreatePerson(CreatePersonInput createPersonInput)
        {
            var personType = await _inMemoryContext.Set<PersonType>().FirstOrDefaultAsync(x => x.Id == createPersonInput.PersonTypeId);
            if (personType is null)
            {
                throw new ArgumentNullException(nameof(personType));
            }

            var dependents = createPersonInput.Dependents?.Select(x => new Dependent
            {
                Name = x.Name,
                Document = x.Document
            }).ToList();

            var person = new Person
            {
                FullName = createPersonInput.FullName,
                BirthDate = createPersonInput.BirthDate,
                PersonType = personType,
                Dependents = dependents!
            };
            var entry = await _inMemoryContext.Set<Person>().AddAsync(person);
            await _inMemoryContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<PersonType> CreatePersonType(string name)
        {
            var newType = new PersonType
            {
                Name = name,
            };
            var entry = await _inMemoryContext.Set<PersonType>().AddAsync(newType);
            await _inMemoryContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}