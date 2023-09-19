using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kovacs_Adela_Licenta.Models;


namespace Kovacs_Adela_Licenta.Data
{
    public class Kovacs_Adela_LicentaContext : DbContext
    {
        public Kovacs_Adela_LicentaContext (DbContextOptions<Kovacs_Adela_LicentaContext> options)
            : base(options)
        {
        }
        public DbSet<Kovacs_Adela_Licenta.Models.Cafea>? Cafea { get; set; }
        public DbSet<Kovacs_Adela_Licenta.Models.TipAroma>? TipAroma { get; set; }
        public DbSet<Kovacs_Adela_Licenta.Models.TipBoabe>? TipBoabe { get; set; }
        public DbSet<Kovacs_Adela_Licenta.Models.TipCafea>? TipCafea { get; set; }
        public DbSet<Kovacs_Adela_Licenta.Models.TipLapte>? TipLapte { get; set; }
        public DbSet<Kovacs_Adela_Licenta.Models.TipTopping>? TipTopping { get; set; }
        public DbSet<Kovacs_Adela_Licenta.Models.Poveste>? Poveste { get; set; }
        public DbSet<Kovacs_Adela_Licenta.Models.Client>? Client { get; set; }
        public DbSet<Kovacs_Adela_Licenta.Models.CafeaClient>? CafeaClient { get; set; }
        public DbSet<Kovacs_Adela_Licenta.Models.Marime>? Marime { get; set; }

    }
}
