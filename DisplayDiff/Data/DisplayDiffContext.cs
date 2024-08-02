using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DisplayDiff.Models;

namespace DisplayDiff.Data
{
    public class DisplayDiffContext : DbContext
    {
        public DisplayDiffContext (DbContextOptions<DisplayDiffContext> options)
            : base(options)
        {
        }

        public DbSet<DisplayDiff.Models.Display> Display { get; set; } = default!;
    }
}
