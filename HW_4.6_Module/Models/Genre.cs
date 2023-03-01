﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4._6_Module.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<Song> Songs { get; set; } = new List<Song>();
    }
}
