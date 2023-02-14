﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4._3_CreatingDB.Models
{
    internal class Client
    {
        public int ClientId { get; set; }
        public List<Project> Projects { get; set; }
        public string Name { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime? EndedDate { get; set; }
        public string Country { get; set; }
    }
}
