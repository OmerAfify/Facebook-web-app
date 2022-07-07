using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceBookApp.Models
{
    public class UserRequest
    {
        public int userId { get; set; }
        public User user { get; set; }
        public int requestId { get; set; }
        public User request { get; set; }
    }
}