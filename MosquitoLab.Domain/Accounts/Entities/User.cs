using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Accounts.Entities
{
    [Table("User")]
    public class User : CommonHistoricalEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IdentificationDocument { get; set; }
        public string Password { get; set; }
    }
}
