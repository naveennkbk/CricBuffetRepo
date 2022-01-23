using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricBuffet.Areas.Admin.Models
{
    public class Buddy
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter Buddy Name...")]
        [DisplayName("Buddy Name")]
        public string BuddyName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EditDate { get; set; }

        public int IsActive { get; set; }

        public string BuddyPicture { get; set; }
    }
}