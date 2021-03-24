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
        public string Ip { get; set; }
        public string Country { get; set; }
        public string Country_name { get; set; }
        public string Postal { get; set; }
        public string Region { get; set; }
        public string Timezone { get; set; }
        public string Continent_code { get; set; }
        public int Country_area { get; set; }
        public string Country_calling_code { get; set; }
        public string Country_capital { get; set; }
        public string Country_code { get; set; }
        public int Country_population { get; set; }
        public string Currency { get; set; }
        public string Languages { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.AddHours(1);
    }
}
