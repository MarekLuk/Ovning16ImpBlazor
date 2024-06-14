using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ovning16ImpBlazor.Server;

namespace Ovning16ImpBlazor.Server.Data
{
    public class Ovning16ImpBlazorServerContext : DbContext
    {
        public Ovning16ImpBlazorServerContext (DbContextOptions<Ovning16ImpBlazorServerContext> options)
            : base(options)
        {
        }

        public DbSet<Ovning16ImpBlazor.Server.Machine> Machine { get; set; } = default!;
    }
}
