using System;

namespace backend.Objects.DTO
{
    public class PostDTO
    {
        public PostDTO()
        {
            
        }
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public string Starts { get; set; }
        public string Ends { get; set; }
        public bool IsPublic { get; set; }
        public bool IsPublished { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
    }
}