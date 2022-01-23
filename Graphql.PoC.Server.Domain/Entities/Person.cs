using Graphql.PoC.Server.Infra.Entities.Bases;
using System.ComponentModel.DataAnnotations;

namespace Graphql.PoC.Server.Infra.Entities
{
    /// <summary>
    /// Classe que descreve uma Pessoa no sistema.
    /// </summary>
    public class Person : Entity
    {
        /// <summary>
        /// Nome completo da pessoa
        /// </summary>
        [MaxLength(150)]
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// Data de nascimento da pessoa
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Dependentes da pessoa
        /// </summary>
        [UseFiltering]
        public ICollection<Dependent> Dependents { get; set; }

        /// <summary>
        /// Tipo de pessoa
        /// </summary>
        public PersonType PersonType { get; set; }
    }
}