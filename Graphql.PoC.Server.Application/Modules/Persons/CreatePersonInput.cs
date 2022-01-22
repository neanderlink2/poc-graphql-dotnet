namespace Graphql.PoC.Server.Application.Modules.Persons
{
    public class CreatePersonInput
    {
        /// <summary>
        /// Nome completo
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Data de nascimento
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// ID do tipo de pessoa.
        /// </summary>
        public long PersonTypeId { get; set; }

        /// <summary>
        /// Dependentes da pessoa.
        /// </summary>
        public CreateDependentInput[] Dependents { get; set; }
    }
}
