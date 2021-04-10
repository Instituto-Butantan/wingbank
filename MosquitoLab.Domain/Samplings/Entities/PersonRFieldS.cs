using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLab.Domain.Samplings.Entities
{
    [Table("PersonRFieldS")]
    public class PersonRFieldS
    {
        public int PersonResponsibleId { get; set; }
        public int FieldSamplingId { get; set; }
    }
}
