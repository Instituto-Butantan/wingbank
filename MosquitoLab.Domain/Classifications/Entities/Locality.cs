using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLab.Domain.Classifications.Entities
{
    [Table("Locality")]
    public class Locality
    {
        [Key]
        public int FieldSamplingId { get; private set;  }
        public string Country { get; private set;  }
        public string ContryCode { get; private set;  }
        public string StateOrProvince { get; private set;  }
        public string StateOrProvinceCode { get; private set;  }
        public string City { get; private set;  }
        public string CityCode { get; private set;  }
        public string Neighborhood { get; private set;  }
        public int? Number { get; private set;  }
        public int? Zipcode { get; private set;  }
        public string Latitude { get; private set;  }
        public string Logitude { get; private set;  }
        public string Datum { get; private set;  }
        public int Altitude { get; private set;  }
    }
}
