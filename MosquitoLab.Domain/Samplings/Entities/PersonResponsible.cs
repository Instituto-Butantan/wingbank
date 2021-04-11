using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Samplings.Entities
{
    [Table("PersonResponsible")]
    public class PersonResponsible : CommonEntityWithKey
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
