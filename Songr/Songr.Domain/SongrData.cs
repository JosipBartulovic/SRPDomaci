using Songr.Data;
using Songr.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Songr.Data;

namespace Songr.Domain
{
    public static class SongrData
    {
        public static void PrintSongByAuthor(string authorFullName)
        {
            Console.WriteLine();
            Console.WriteLine(authorFullName);
            using (var context = new SongrDbEntities())
            {
                var author = context.Authors.ToList().FirstOrDefault(x => x.FullName == authorFullName);
                if (author != null)
                {
                    DTOConverter.AuthorMapper(author).Songs.ForEach(x => Console.WriteLine(x.NameAndDuration));
                }
                else
                {
                    Console.WriteLine("Author doesn't exist");
                }
            }
            Console.WriteLine();
        }

        public static void PrintAllSongs()
        {
            Console.WriteLine();
            using(var context = new SongrDbEntities())
            {
                context.Songs.ToList().ForEach(x=> Console.WriteLine(DTOConverter.SongMapper(x).NameAndDuration));
            }
            Console.WriteLine();
        }

        public static void PrintAllAuthors()
        {
            Console.WriteLine();
            using (var context = new SongrDbEntities())
            {
                context.Authors.ToList().ForEach(x => Console.WriteLine(DTOConverter.AuthorMapper(x).FullName));
            }
            Console.WriteLine();
        }
    }
}
