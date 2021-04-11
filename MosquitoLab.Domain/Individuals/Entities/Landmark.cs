using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLab.Domain.Individuals.Entities
{
    [Table("Landmark")]
    public class Landmark
    {
        public int LandmarkAnnotationId { get; set; }
        public decimal HorizontalCoordinate { get; set; }
        public decimal VerticalCoordinate { get; set; }
    }
}
