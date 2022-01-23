using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CricBuffet.Areas.Media.Models
{
    public class MediaDetailDTO
    {
        private readonly CricDbContext cricDbContext;

        public MediaDetailDTO(CricDbContext cricDbContext1)
        {
            cricDbContext = cricDbContext1;
        }

        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        public int MediaTag { get; set; }

        public string MediaTitle { get; set; }

        public string MediaDescription { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EditDate { get; set; }

        [ForeignKey("Buddy")]
        public int BuddyId { get; set; }

        public int IsActive { get; set; }
    }
}