using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turniri.Data.Models;

namespace Turniri.Data
{
    public class TurniriContext: DbContext
    {
        public TurniriContext() : base()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
    }
}
