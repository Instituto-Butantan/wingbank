using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Institutions.Entities
{
    [Table("Institution")]
    public class Institution : CommonEntityWithKey
    {
        public int? ParentInstitution { get; set; }
        public string NameOriginalLanguage { get; set; }
        public string NameInEnglish { get; set; }
        public string Abbreviation { get; set; }
    }
}
