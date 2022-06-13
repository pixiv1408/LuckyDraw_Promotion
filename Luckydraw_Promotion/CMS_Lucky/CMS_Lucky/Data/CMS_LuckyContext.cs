using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Datactx.Models;

namespace CMS_Lucky.Data
{
    public class CMS_LuckyContext : DbContext
    {
        public CMS_LuckyContext (DbContextOptions<CMS_LuckyContext> options)
            : base(options)
        {
        }

        public DbSet<Datactx.Models.Position>? Position { get; set; }

        public DbSet<Datactx.Models.Campaign>? Campaign { get; set; }
    }
}
