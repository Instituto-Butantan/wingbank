using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Individuals.Entities
{
    [Table("LandmarkAnnotation")]
    public class LandmarkAnnotation : CommonEntityWithKey
    {
        public int WingImageId { get; set; }
        public string Description { get; set; }
    }
}
