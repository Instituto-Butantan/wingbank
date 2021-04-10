using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Individuals.Entities
{
    [Table("WingImage")]
    public class WingImage : CommonEntityWithKey
    {
        public char? WingSide { get; private set; }
        public string ImageFile { get; private set; }
        public string ImageExtension { get; private set; }
        public int? ImageZoom { get; private set; }
        public string ImageDimension { get; private set; }
        public int? ImageDpi { get; private set; }
        public string AcquirementEquipment { get; private set; }
        public string FileName { get; private set; }
        public string TempLabCode { get; private set; }
        public string TempId { get; private set; }
        public string TempWingSide { get; private set; }
        public string TempGender { get; private set; }
        public string AccessionCode { get; private set; }
    }
}
