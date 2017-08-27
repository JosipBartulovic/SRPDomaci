using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turniri.Data.Models;

namespace Turniri.Data
{
    class DatabaseInitializer: DropCreateDatabaseIfModelChanges<TurniriContext>
    {
        protected override void Seed(TurniriContext context)
        {

            var Golubovi = new Team()
            {
                Name = "Golubovi",
                TournamentsWon = 3,
                LastTurnamentWonDate = new DateTime(1991, 12, 12),
                Players = new List<Player>()
            };

            var P1 = new Player()
            {
                FirstName = "Marko",
                LastName = "Markic",
                Email = "MarkoMarkic@gmail.com",
                PhoneNumber = 09169696,
                Team = Golubovi
            };

            var P2 = new Player()
            {
                FirstName = "Mirko",
                LastName = "Mirkic",
                Email = "MirkoMirkic@gmail.com",
                PhoneNumber = 09868686,
                Team = Golubovi
            };

            var P3 = new Player()
            {
                FirstName = "Ante",
                LastName = "Antic",
                Email = "AnteAntic@gmail.com",
                PhoneNumber = 0996556,
                Team = Golubovi
            };

            var P4 = new Player()
            {
                FirstName = "Murko",
                LastName = "Murkic",
                Email = "JaSamOnajKojiJesam@gmail.com",
                PhoneNumber = 098666666,
                Team = Golubovi
            };

            context.Players.Add(P1);
            context.Players.Add(P2);
            context.Players.Add(P3);
            context.Players.Add(P4);
            context.Teams.Add(Golubovi);

            context.SaveChanges();
            base.Seed(context);

        }
    }
}
