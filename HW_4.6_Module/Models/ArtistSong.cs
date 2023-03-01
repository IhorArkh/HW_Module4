using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4._6_Module.Models
{
    public class ArtistSong
    {
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
    }
}
