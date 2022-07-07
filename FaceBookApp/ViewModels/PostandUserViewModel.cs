using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FaceBookApp.Models;

namespace FaceBookApp.ViewModels
{
    public class PostandUserViewModel
    {
        public User user { get; set; }
        public Post post { get; set; }
    }
}