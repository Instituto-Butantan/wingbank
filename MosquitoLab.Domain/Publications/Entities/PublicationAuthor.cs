using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLab.Domain.Publications.Entities
{
    [Table("PublicationAuthor")]
    public class PublicationAuthor
    {
        public string PublicationTitle { get; set; }
        public int PublicationYear { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
