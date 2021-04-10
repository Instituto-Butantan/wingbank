using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Classifications.Entities
{
    [Table("Colony")]
    public class Colony : CommonEntityWithKey
    {
        public string TemperatureControl { get; set; }
        public string RelativeHumidity { get; set; }
        public string PhotoPeriod { get; set; }
        public string Strain { get; set; }
        public string Note { get; set; }
        public string TempLabCode { get; set; }
    }
}
