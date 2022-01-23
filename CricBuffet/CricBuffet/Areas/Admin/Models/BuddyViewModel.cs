using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricBuffet.Areas.Admin.Models
{
    public class BuddyViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter Buddy Name...")]
        [DisplayName("Buddy Name")]
        public string BuddyName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EditDate { get; set; }

        public int IsActive { get; set; }

        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }

        public string BuddyPicture { get; set; }
    }
}