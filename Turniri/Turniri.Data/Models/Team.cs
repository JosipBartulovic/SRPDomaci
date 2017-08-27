using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turniri.Data.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TournamentsWon { get; set; }
        public DateTime? LastTurnamentWonDate { get; set; }
        public string LogoAnimalName { get; set; }

        public virtual ICollection<Player> Players { get; set; }
        public virtual Match Match { get; set; }
        public int roundsWon { get; set; }
    }
}
