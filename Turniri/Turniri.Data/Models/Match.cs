using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Rounds {Prva, Polufinale, Finale};

namespace Turniri.Data.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Rounds Round { get; set; }
        public bool IsTournamentMach { get; set; }

        public virtual Team Team1 { get; set; }
        public virtual Team Team2 { get; set; }
    }
}
