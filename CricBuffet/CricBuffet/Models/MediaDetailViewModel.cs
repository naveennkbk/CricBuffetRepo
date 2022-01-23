using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricBuffet.Models
{
    public class MediaDetailViewModel
    {
        public int ID { get; set; }

        public int MediaTag { get; set; }

        public string MediaTitle { get; set; }

        public string MediaDescription { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EditDate { get; set; }

        public int BuddyId { get; set; }

        public int IsActive { get; set; }
    }
}