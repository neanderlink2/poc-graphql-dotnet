using System.ComponentModel.DataAnnotations.Schema;

namespace Graphql.PoC.Server.Infra.Entities.Bases
{
    /// <summary>
    /// Entidade base
    /// </summary>
    public class Entity
    {
        protected Entity()
        {
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// ID do registro
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; protected set; }

        /// <summary>
        /// Data de criação do registro na base de dados.
        /// </summary>
        public DateTime CreatedAt { get; protected set; }

        /// <summary>
        /// Data da última atualização do registro na base de dados.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; protected set; }
    }
}
