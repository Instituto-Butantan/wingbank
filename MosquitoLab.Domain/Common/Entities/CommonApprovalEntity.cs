using System.Security.Cryptography.X509Certificates;

namespace MosquitoLab.Domain.Common.Entities
{
    public class CommonApprovalEntity : CommonHistoricalEntity
    {
        public bool IsVisible { get; set; }
    }
}
