using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit;
using Xunit.Sdk;

namespace FaceBookApp.Models
{
    public class User
    {

        public int id { get; set; }

       
        [Required, StringLength(10)]
        [Display(Name = "First Name")]
        public string firstName{ get; set; }


        [Required ]
        [StringLength(10)]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }


        [Display(Name = "Profile Picture")]
        public string profileImage { get; set; }


        [Required]
        [StringLength(15)]
        [Display(Name = "Country")]
        public string country { get; set; }


        [Required]
        [StringLength(15)]
        [Display(Name = "City")]
        public string city { get; set; }


        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter a Valid Phone Number.")]
        [Display(Name = "Mobile Number")]
        public int mobileNo { get; set; }


        [EmailAddress]
        [Required]
        [Display(Name = "Email Address")]
        public string email { get; set; }

      
        [RegularExpression(@"(?=.*\d)(?=.*[A-Za-z]).{5,}", 
         ErrorMessage = "Your password must be at least 5 characters long and contain at least 1 letter and 1 number.")]
        [Display(Name = "Password")]
        [Required]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "The password fields do not match.")]
        [Display(Name = "Confirm Password")]
        public string confirmPassWord { get; set; }


        public List<Post> posts { get; set; } 
    }
}