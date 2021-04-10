using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Classifications.Entities
{
    [Table("AreaType")]
    public class AreaType : CommonEntityWithKey
    {
        public string Name { get; set; }
    }
}
