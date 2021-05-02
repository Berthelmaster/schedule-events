using System;
using System.Collections.Generic;

namespace backend.Models
{
    public class Post
    {
        public Post()
        {

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Starts { get; set; }
        public string Ends { get; set; }
        public bool IsPublic { get; set; }
        public bool IsPublished { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Image { get; set; }


        //EF Relations
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
