using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IP_Sniffer.Models
{
    public class GeoLocation
    {
        public GeoLocation()
        {

        }

        public int Id { get; set; }
        public string Query { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Region { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public string Timezone { get; set; }
        public string Isp { get; set; }
        public string Org { get; set; }
        public string As { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.AddHours(1);
    }
}
