using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Turniri.Data.Models;
using Turniri.Data;
using System.Data.Entity;

namespace Turniri.Domain
{
    public static class TurniriRepository
    {
        public static bool AddPlayer(string firstName, string lastName, int phoneNumber, string email)
        {
            using(var context = new TurniriContext())
            {
                if(!context.Players.Any(x => x.FirstName == firstName && x.LastName == lastName))
                {
                    var player = new Player()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        PhoneNumber = phoneNumber,
                        Email = email,
                        Team = null
                    };
                    context.Players.Add(player);
                    context.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        
        public static Team CreateTeam(string name, string logoAnimalName)
        {
            var team = new Team()
            {
                Name = name,
                LogoAnimalName = logoAnimalName,
                LastTurnamentWonDate = null,
                TournamentsWon = 0
            };
            using (var context = new TurniriContext())
            {
                if(!context.Teams.Any(x=> x.Name == name || x.LogoAnimalName == logoAnimalName))
                {
                    context.Teams.Add(team);
                    context.SaveChanges();
                    return team;
                }
                return null;
            }
        }

        public static string PrintAllPlayersWithoutTeam()
        {
            using(var context = new TurniriContext())
            {
                string return_value = "";
                context.Players.ToList().Where(x => x.Team == null).Select(x => x.FirstName + " " + x.LastName + "\n").ToList().ForEach(x => return_value += x);
                return "\n"+return_value;
            }
        }

        public static string PrintAllTeams()
        {
            using(var context = new TurniriContext())
            {
                string return_value = "";
                context.Teams.ToList().Select(x => x.Name + "\n").ToList().ForEach(x => return_value += x);
                return "\n"+return_value;
            }
        }

        public static string PrintAllPlayers()
        {
            using (var context = new TurniriContext())
            {
                string return_value = "";
                context.Players.ToList().Select(x => x.FirstName + " " + x.LastName + "\n").ToList().ForEach(x => return_value += x);
                return "\n" + return_value;
            }
        }

        public static List<Player> GetAllPlayersWithoutTeam()
        {
            using (var context = new TurniriContext())
            {
                return context.Players.ToList().Where(x => x.Team == null).ToList();
            }
        }

        public static Player GetPlayerByName(string firstName, string lastName)
        {
            using (var context = new TurniriContext())
            {
                var players = context.Players.Include(x => x.Team);
                return players.ToList().FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            }
        }

        public static Team GetTeamByName(string name)
        {
            using (var context = new TurniriContext())
            {
                var teams = context.Teams.Include(x => x.Players).ToList();
                return teams.ToList().FirstOrDefault(x => x.Name == name);
            }
        }

        public static bool AddPlayerToTeam(string playerFistName, string playerLastName, string teamName)
        {
            using (var context = new TurniriContext())
            {
                var player = GetPlayerByName(playerFistName, playerLastName);
                player = GetAllPlayersWithoutTeam().FirstOrDefault(x => x.FirstName == player.FirstName && x.LastName == player.LastName);
                var team = GetTeamByName(teamName);
                Console.WriteLine(player.FirstName);
                Console.WriteLine(player.LastName);
                Console.WriteLine(team.Name);

                if (player != null && team != null && team.Players.Count()<5)
                {
                    context.Entry(player).State = EntityState.Modified;
                    context.Entry(team).State = EntityState.Modified;
                    team.Players.Add(player);
                    player.Team = team;
                    context.SaveChanges();
                    context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public static bool KickPlayerOutOfTeam(string playerFistName, string playerLastName, string teamName)
        {
            using(var context = new TurniriContext())
            {
                var team = GetTeamByName(teamName);
                var player = team.Players.ToList().FirstOrDefault();
                if(team != null && player != null)
                {
                    context.Entry(team).State = EntityState.Modified;
                    team.Players.Remove(player);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        private static List<Match> GenerateMatchesForTournament(List<Team> teams, string tournamentName)
        {
            List<Match> matchesList = new List<Match>();
            Random rnd = new Random();

            while (teams.Count() > 0)
            {
                int team1 = rnd.Next(0, teams.Count());
                int team2 = rnd.Next(0, (teams.Count()-1));
                Team team_1 = teams[team1];
                teams.RemoveAt(team1);
                Team team_2 = teams[team2];
                teams.RemoveAt(team2);
                team_1.roundsWon = 0;
                team_2.roundsWon = 0;
                Match match = new Match()
                {
                    Name = tournamentName,
                    IsTournamentMach = true,
                    Round = Rounds.Prva,
                    Team1 = team_1,
                    Team2 = team_2,
                };

                using (var context = new TurniriContext())
                {
                    context.Matches.Add(match);
                    context.SaveChanges();
                }

                matchesList.Add(match);
            }
            return matchesList;
        }

        
        public static Match CreateMatch(Team team1, Team team2, string name)
        {
            Match match = new Match()
            {
                Name = name,
                IsTournamentMach = true,
                Round = Rounds.Prva,
                Team1 = team1,
                Team2 = team2,
            };

            using(var context = new TurniriContext())
            {
                context.Matches.Add(match);
                context.SaveChanges();
            }
            return match;
        }

        public static Team ProceedMatch(Match match, Team winningTeam)
        {
            using (var context = new TurniriContext())
            {
                context.Entry(match).State = EntityState.Modified;
                context.Entry(winningTeam).State = EntityState.Modified;
                var nextRound = match.Round + 1;
                winningTeam.roundsWon++;
                if (nextRound == Rounds.Finale)
                {
                    return (match.Team1.roundsWon > match.Team2.roundsWon) ? match.Team1 : match.Team2;
                }
                else
                {
                    match.Round = nextRound;
                    return null;
                }
            }
        }

        public static Tournament CreateTournament(string name, DateTime startDate, DateTime endDate, List<Team> teamsList)
        {
            var tournament = new Tournament()
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                ListOfMatches = GenerateMatchesForTournament(teamsList, name)
            };
            using(var context = new TurniriContext())
            {
                context.Tournaments.Add(tournament);
                context.SaveChanges();
            }
            return tournament;
        }


    }
}
