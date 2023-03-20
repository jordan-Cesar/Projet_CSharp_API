using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PROJET_C.Models;

namespace PROJET_C.Data
{
    public class PROJET_CContext : DbContext
    {
        public PROJET_CContext (DbContextOptions<PROJET_CContext> options)
            : base(options)
        {
        }

        public DbSet<PROJET_C.Models.Continent> Continent { get; set; } = default!;

        public DbSet<PROJET_C.Models.Pay> Pay { get; set; }

        public DbSet<PROJET_C.Models.Population> Population { get; set; }

        internal object Include(string v)
        {
            throw new NotImplementedException();
        }
    }
}
