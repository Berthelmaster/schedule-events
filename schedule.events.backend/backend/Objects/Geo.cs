using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Objects
{
    public class Geo
    {
        public string Country { get; set; }
        public string City { get; set; }
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }
    }
}
