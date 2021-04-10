using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLab.Domain.Individuals.Entities
{
    [Table("WingPublication")]
    public class WingPublication 
    {
        public int WingImageId { get; set; }
        public string PublicationTitle { get; set; }
        public int PublicationYear { get; set; }
    }
}
