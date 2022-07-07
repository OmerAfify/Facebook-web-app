using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceBookApp.Models
{
    public class Post
    {
        public int id { get; set; }
        public string content { get; set; }
        public bool hidden { get; set; }
        public int likesNumber { get; set; }
        public List<Like> likes { get; set; }
        public int commentsNumber { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public List<Comment> comments { get; set; }
    }
}