using Microsoft.EntityFrameworkCore;

namespace HW_4._3_CreatingDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var dbContext = new EmployeesContext())
            {
                var clients = dbContext.Clients.ToList();
                var projects = dbContext.Projects.ToList();
            }
        }
    }
}