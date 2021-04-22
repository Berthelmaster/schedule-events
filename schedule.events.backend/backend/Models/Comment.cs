using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date => DateTime.UtcNow.AddHours(2);
        public string WrittenBy { get; set; }

        // EF Core Relations
        public User User { get; set; }
        public int UserId { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}
