using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLab.Domain.Publications.Entities
{
    [Table("Publication")]
    public class Publication
    {
        [Key]
        public string Title { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public int? Number { get; set; }
        public int? Volume { get; set; }
        public string Url { get; set; }
        public string Doi { get; set; }
        public string Journal { get; set; }
        public string TempId { get; set; }
    }
}
