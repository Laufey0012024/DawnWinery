using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Winery.Models;

namespace Winery.Data
{
    public class WineryContext : DbContext
    {
        public WineryContext (DbContextOptions<WineryContext> options)
            : base(options)
        {
        }

        public DbSet<Winery.Models.Wine> Wine { get; set; } = default!;
    }
}
