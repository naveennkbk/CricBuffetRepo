using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricBuffet.Areas.Menu.Models
{
    public class MediaMenu
    {
        [Key]
        public int Id { get; set; }

        public string MediaMenuName { get; set; }

        public int IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EditDate { get; set; }
    }
}