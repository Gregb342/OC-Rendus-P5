using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpressVoitures.Models;

namespace ExpressVoitures.Data
{
    public class ExpressVoituresContext : DbContext
    {
        public ExpressVoituresContext (DbContextOptions<ExpressVoituresContext> options)
            : base(options)
        {
        }

        public DbSet<ExpressVoitures.Models.Car> Car { get; set; } = default!;
    }
}
