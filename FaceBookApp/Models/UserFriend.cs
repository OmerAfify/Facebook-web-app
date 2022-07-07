using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceBookApp.Models
{
    public class UserFriend
    {
        public int userId { get; set; }
        public User user { get; set; }
        public int friendId { get; set; }
        public User friend { get; set; }
    }
}