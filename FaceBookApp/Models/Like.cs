using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceBookApp.Models
{
    public class Like
    {
        public virtual int userId { get; set; }
        public virtual User user { get; set; }
        public virtual int postId { get; set; }
        public virtual Post post { get; set; }   
        


    }
}