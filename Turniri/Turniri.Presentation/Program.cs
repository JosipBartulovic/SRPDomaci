using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turniri.Data;
using Turniri.Data.Models;
using Turniri.Domain;

namespace Turniri.Presentation
{
    class Program
    {
        static void Main(string[] args) {

            Console.WriteLine("Hello User:");
            Console.WriteLine("-----------");

            Console.WriteLine();

            while (true)
            {
       
                Console.WriteLine("1)Print All Players");
                Console.WriteLine("2)Print All Teams");
                Console.WriteLine("3)Create Player");
                Console.WriteLine("4)Add Player To Team");
                Console.WriteLine("5)Create Team");
                Console.WriteLine("6)Create Match");
                Console.WriteLine("7)Create Tournament");
                Console.WriteLine("---------------------");
                Console.WriteLine();
                Console.WriteLine("Choose Option: ");
                var input = Console.ReadLine();
                if(input == "1)")
                {
                    Console.Clear();
                    Console.WriteLine(TurniriRepository.PrintAllPlayers());
                }else if(input == "2)")
                {
                    Console.Clear();
                    Console.WriteLine(TurniriRepository.PrintAllTeams());
                }
                else if (input == "3)")
                {
                    Console.Clear();
                    Console.WriteLine("First Name: ");
                    var firstName = Console.ReadLine();
                    Console.WriteLine("Last Name: ");
                    var lastName = Console.ReadLine();
                    Console.WriteLine("Email: ");
                    var email = Console.ReadLine();
                    Console.WriteLine("Phone Number: ");
                    var phoneNumber = int.Parse(Console.ReadLine());
                    TurniriRepository.AddPlayer(firstName, lastName, phoneNumber, email);
                    Console.WriteLine();
                }
                else if (input == "4)")
                {
                    Console.WriteLine();
                    Console.WriteLine("First Name: ");
                    var firstName = Console.ReadLine();
                    Console.WriteLine("Last Name: ");
                    var lastName = Console.ReadLine();
                    Console.WriteLine("Team Name: ");
                    var teamName = Console.ReadLine();
                    TurniriRepository.AddPlayerToTeam(firstName, lastName, teamName);
                    Console.WriteLine();
                }
                else if (input == "5)")
                {
                    Console.WriteLine();
                    Console.WriteLine("Team Name: ");
                    var teamName = Console.ReadLine();
                    Console.WriteLine("Animal Logo Name: ");
                    var logoName = Console.ReadLine();
                    TurniriRepository.CreateTeam(teamName, logoName);
                    Console.WriteLine();
                }
                else if (input == "6)")
                {
                    Console.WriteLine();
                    Console.WriteLine("First Team Name: ");
                    var firstTeam = TurniriRepository.GetTeamByName(Console.ReadLine());
                    Console.WriteLine("Second Team Name: ");
                    var secondTeam = TurniriRepository.GetTeamByName(Console.ReadLine());
                    Console.WriteLine("Match Name: ");
                    var matchName = Console.ReadLine();
                    TurniriRepository.CreateMatch(firstTeam, secondTeam, matchName);
                    Console.WriteLine();
                }
                else if (input == "7)")
                {
                    Console.WriteLine();
                    Console.WriteLine("Name: ");
                    var name = Console.ReadLine();
                    Console.WriteLine("Starting Year: ");
                    var startingYear = int.Parse(Console.ReadLine());
                    Console.WriteLine("Starting Month: ");
                    var startingMonth = int.Parse(Console.ReadLine());
                    Console.WriteLine("Starting Day: ");
                    var startingDay = int.Parse(Console.ReadLine());
                    var startingDate = new DateTime(startingYear, startingMonth, startingDay);
                    Console.WriteLine("Ending Year: ");
                    var endingYear = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ending Month: ");
                    var endingMonth = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ending Day: ");
                    var endingDay = int.Parse(Console.ReadLine());
                    var endingDate = new DateTime(endingYear, endingMonth, endingDay);
                    Console.WriteLine("First Team");
                    var team1 = TurniriRepository.GetTeamByName(Console.ReadLine());
                    Console.WriteLine("Second Team");
                    var team2 = TurniriRepository.GetTeamByName(Console.ReadLine());
                    Console.WriteLine("Third Team");
                    var team3 = TurniriRepository.GetTeamByName(Console.ReadLine());
                    Console.WriteLine("Fourth Team");
                    var team4 = TurniriRepository.GetTeamByName(Console.ReadLine());
                    var teams = new List<Team>();
                    teams.Add(team1);
                    teams.Add(team2);
                    teams.Add(team3);
                    teams.Add(team4);
                    TurniriRepository.CreateTournament(name, startingDate, endingDate, teams);
                }
            }
        }
        
    }
}
