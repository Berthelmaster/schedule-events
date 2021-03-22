﻿using System;

namespace backend.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool IsPublic { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}