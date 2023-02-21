﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4._6_Module.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public DateTime RealeasedDate { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        //public virtual List<Artist> Artists { get; set; } = new List<Artist>();
        public virtual List<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();
    }
}
