using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4._3_CreatingDB.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }
        public virtual List<EmployeeProject> EmployeeProject { get; set; } = new List<EmployeeProject>();
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
