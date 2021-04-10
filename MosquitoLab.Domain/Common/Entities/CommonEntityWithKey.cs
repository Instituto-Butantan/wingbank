using System.ComponentModel.DataAnnotations;

namespace MosquitoLab.Domain.Common.Entities
{
    public class CommonEntityWithKey 
    {
        [Key]
        public int Id { get; private set; }
        //public bool IsExcluded { get; set; } = false;
        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        //public DateTime? ModifiedAt { get; set; }
        //public DateTime? DeletedAt { get; set; }
    }
}
