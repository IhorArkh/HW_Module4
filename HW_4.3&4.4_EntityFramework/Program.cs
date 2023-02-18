using HW_4._3_CreatingDB.Models;
using Microsoft.EntityFrameworkCore;

namespace HW_4._3_CreatingDB
{
    internal class Program
    {

        static void Main(string[] args)
        {
            using(var dbContext = new EmployeesContext())
            {
                //Запрос, который объединяет 3 таблицы и обязательно включает LEFT JOIN
                var joinedTables = from empl in dbContext.Employees
                                   join office in dbContext.Offices
                                   on empl.OfficeId equals office.OfficeId into temp
                                   from res in temp.DefaultIfEmpty()

                                   join title in dbContext.Titles
                                   on empl.TitleId equals title.TitleId into temp2
                                   from res2 in temp2.DefaultIfEmpty()

                                   select new
                                   {
                                       id = empl.EmployeeId,
                                       office = res.Title,
                                       title = res2.Name
                                   };

                //Запрос, который возвращает разницу между HiredDate и сегодня в днях. Фильтрация должна быть выполнена на сервере.
                var employees = dbContext.Employees.AsNoTracking()
                    .Select(i => new { Id = i.EmployeeId, Diff = EF.Functions.DateDiffDay(i.HiredDate, DateTime.Now)});

                //Запрос, который обновляет 2 сущности. Сделать в одной  транзакции
                var transaction = dbContext.Database.BeginTransaction();
                
                try
                {
                    var clients = dbContext.Clients.ToList();
                    clients[1].Name = "ChangedName";
                    dbContext.SaveChanges();

                    var projects = dbContext.Projects.ToList();
                    projects[1].Name = "ChangedName";
                    dbContext.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }

                //Запрос, который добавляет сущность Employee с Title и Office
                var emp = new Employee
                {
                    DateOfBirth = new DateTime(2000, 12, 12),
                    FirstName = "TestName",
                    LastName = "TestSurname",
                    HiredDate = new DateTime(2019, 11, 7),
                    OfficeId = 1,
                    TitleId = 1,
                    Office = new Office
                    {
                        Location = "Location",
                        Title = "Title"
                    },
                    Title = new Title {Name = "Title"}
                };

                dbContext.Add(emp);
                dbContext.SaveChanges();

                //Запрос, который удаляет сущность Employee
                var allEmployees = dbContext.Employees.ToList();
                dbContext.Employees.Remove(allEmployees[0]);
                dbContext.SaveChanges();

                //Запрос, который группирует сотрудников по ролям и возвращает название роли (Title) если оно не содержит ‘a’
                
            }
        }
    }
}