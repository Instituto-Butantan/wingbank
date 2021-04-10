using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Samplings.Entities
{
    [Table("Method")]
    public class Method :  CommonEntityWithKey
    {
        public string Name { get; set; }
    }
}
