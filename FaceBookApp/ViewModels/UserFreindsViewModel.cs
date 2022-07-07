using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceBookApp.Models;

namespace FaceBookApp.ViewModels
{
    public class UserFreindsViewModel
    {
        public User   user { get; set; }
        public List<User> friends { get; set; }
    }
}