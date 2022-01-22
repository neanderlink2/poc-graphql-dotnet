namespace Graphql.PoC.Server.Application.Modules.Persons
{
    public class CreateDependentInput
    {
        /// <summary>
        /// Nome completo
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Número do documento (CPF ou RG).
        /// </summary>
        public string Document { get; set; }
    }
}
