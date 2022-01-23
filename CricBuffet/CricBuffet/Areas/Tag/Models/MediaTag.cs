using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricBuffet.Areas.Tag.Models
{
    public class MediaTag
    {
        [Key]
        public int ID { get; set; }

        public string TagName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EditDate { get; set; }

        public int IsActive { get; set; }
    }
}