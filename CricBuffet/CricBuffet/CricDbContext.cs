using CricBuffet.Areas.Admin.Models;
using CricBuffet.Areas.Media.Models;
using CricBuffet.Areas.Menu.Models;
using CricBuffet.Areas.Tag.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricBuffet
{
    public class CricDbContext : DbContext
    {
        public CricDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Buddy> Buddy { get; set; }

        public DbSet<MediaMenu> MediaMenu { get; set; }

        public DbSet<MediaDetail> MediaDetail { get; set; }

        public DbSet<MediaTag> MediaTag { get; set; }
    }
}