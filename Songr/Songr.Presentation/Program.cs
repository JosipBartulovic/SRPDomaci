using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Songr.Data;
using Songr.Domain;

namespace Songr.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1) GetSongsByAuthor");
                Console.WriteLine("2) GetAllAuthors");
                Console.WriteLine("3) GetAllSongs");
                Console.WriteLine();
                Console.WriteLine("Choose 1) 2) or 3)");

                var input = Console.ReadLine();
                
                if(input == "1)")
                {
                    Console.Clear();
                    Console.WriteLine("Enter AuthorName:");
                    var name = Console.ReadLine();
                    SongrData.PrintSongByAuthor(name);
                }else if(input == "2)")
                {
                    Console.Clear();
                    SongrData.PrintAllAuthors();
                }else if(input == "3)")
                {
                    Console.Clear();
                    SongrData.PrintAllSongs();
                }
            }
        }
    }
}
