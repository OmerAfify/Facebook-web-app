using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceBookApp.Models;

namespace FaceBookApp.ViewModels
{
    public class UserPostsViewModel
    {
        public User user { get; set; }
        public List<Post> posts { get; set; }
        public List<Comment> comments { get; set; }

    }
}