using System.Collections.Generic;

namespace backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }
}