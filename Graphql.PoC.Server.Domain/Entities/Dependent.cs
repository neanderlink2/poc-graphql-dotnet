using Graphql.PoC.Server.Infra.Entities.Bases;
using System.ComponentModel.DataAnnotations;

namespace Graphql.PoC.Server.Infra.Entities
{
    /// <summary>
    /// Classe que descreve um dependente. Um dependente será registrado a partir de uma Pessoa e estará vinculado a ela.
    /// </summary>
    public class Dependent : Entity
    {
        /// <summary>
        /// Nome do dependente
        /// </summary>
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Documento do dependente
        /// </summary>
        [MaxLength(20)]
        [Required]
        public string Document { get; set; }

        /// <summary>
        /// Pessoa responsável do dependente
        /// </summary>
        public Person Responsible { get; set; }
    }
}
