using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Songr.Data.DTO;
using Songr.Data;

namespace Songr.Data
{
    public static class DTOConverter
    {
        public static SongDTO SongMapper(Song song)
        {
            var songDTO = new SongDTO()
            {
                NameAndDuration = song.Name + " " + song.Duration.Value.Hours.ToString() + " sati " + song.Duration.Value.Minutes.ToString() + " minuta " + song.Duration.Value.Seconds + " sekunda "
            };
            return songDTO;
        }

        public static AuthorDTO AuthorMapper(Author author)
        {
            var songList = new List<SongDTO>();
            author.Songs.ToList().ForEach(x => songList.Add(SongMapper(x)));
            var authorDTO = new AuthorDTO()
            {
                FullName = author.FullName,
                Songs = songList
            };
            return authorDTO;
        }
    }
}

