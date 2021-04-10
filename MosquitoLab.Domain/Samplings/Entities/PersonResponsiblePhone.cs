using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLab.Domain.Samplings.Entities
{
    [Table("PersonResponsiblePhone")]
    public class PersonResponsiblePhone
    {
        public int PersonResponsibleId { get; set; }
        public string PhoneNumber { get; set; }

    }
}
