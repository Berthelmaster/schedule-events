using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Attendee
    {
        public int Id { get; set; }
        public string Identifier => Guid.NewGuid().ToString();
        public string Type { get; set; }
        public DateTime Date => DateTime.UtcNow.AddHours(2);
    }
}
