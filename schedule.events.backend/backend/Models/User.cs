using Newtonsoft.Json;
using System.Collections.Generic;

namespace backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [JsonIgnore]
        public byte[] Hash { get; set; }
        [JsonIgnore]
        public byte[] Salt { get; set; }
        [JsonIgnore]
        public bool IsApproved => true;
        public string Role { get; set; } = "User";


        //EF Relations
        public List<Post> Posts { get; set; }
    }
}