using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceBookApp.Models
{
    public class Comment
    {
        public int id { get; set; }
         public string text { get; set; }
        
        public virtual int userId { get; set; }
        public virtual User User { get; set; }
      
        public int postId { get; set; }
        public Post post { get; set; }

    }
}