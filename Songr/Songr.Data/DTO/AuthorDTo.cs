using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songr.Data.DTO
{
    public class AuthorDTO
    {
        public string FullName { get; set; }
        public List<SongDTO> Songs { get; set; }
    }
}
