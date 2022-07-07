using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceBookApp.Models;

namespace FaceBookApp.ViewModels
{
    public class UserFreindsPostsViewModel
    {
        public User user { get; set; }
        public List<UserPostsViewModel> FreindsAndPosts { get; set; }

    }
}