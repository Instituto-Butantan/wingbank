using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Samplings.Entities
{
    [Table("StageMethod")]
    public class StageMethod : CommonEntityWithKey
    {
        public int StageId { get; set; }
        public int MethodId { get; set; }
    }
}
