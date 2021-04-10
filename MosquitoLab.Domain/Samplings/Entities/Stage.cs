using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Samplings.Entities
{
    [Table("Stage")]
    public class Stage : CommonEntityWithKey
    {
        public string Name { get; set; }
    }
}
