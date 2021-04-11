using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLab.Domain.Samplings.Entities
{
    [Table("PersonRColony")]
    public class PersonRColony
    {
        [Key]
        public int PersonResponsibleId { get; set; }
        public int ColonyId { get; set; }
    }
}
