using Graphql.PoC.Server.Infra.Entities.Bases;
using System.ComponentModel.DataAnnotations;

namespace Graphql.PoC.Server.Infra.Entities
{
    /// <summary>
    /// Classe que descreve um tipo de Pessoa. Esse tipo informará se o usuário é Pessoa Física ou Jurídica, por exemplo.
    /// </summary>
    public class PersonType : Entity
    {
        /// <summary>
        /// Nome do tipo de pessoa
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Pessoas que são desse tipo
        /// </summary>
        public ICollection<Person> PersonsOfThisType { get; set; }
    }
}
