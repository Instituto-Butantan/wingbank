namespace MosquitoLab.Domain.Common.Entities
{
    public class CommonHistoricalEntity : CommonEntityWithKey
    {
        public int? UserWhoCreated { get; set; }
        public int? UserWhoModified { get; set; }
        public int? UserWhoDeleted { get; set; }
    }
}
