using HW_4._3_CreatingDB.Models;
using HW_4._6_Module.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HW_4._6_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var dbContext = new DataBaseContext())
            {
                //Вывести название песни, имя исполнителя, название жанра песни.
                //Вывести только песни у которых есть жанр и которые поет существующий(alive) исполнитель.
                var firstQuery = dbContext.ArtistSongs
                    .AsNoTracking()
                    .Include(s => s.Song)
                    .ThenInclude(s => s.Genre)
                    .Include(s => s.Artist)
                    .Where(s => s.Song.GenreId != null && s.Artist.DateOfDeath == null)
                    .Select(x => new
                    {
                        SongName = x.Song.Title,
                        ArtistName = x.Artist.Name,
                        GenreName = x.Song.Genre.Title
                    });

                Console.WriteLine("Song which has genre and artist is alive:");
                foreach (var item in firstQuery)
                {
                    Console.WriteLine($"{item.SongName} - {item.ArtistName} - {item.GenreName}");
                }
            }

            using (var dbContext = new DataBaseContext())
            {
                //Вывести кол-во песен в каждом жанре
                var secongQuery = dbContext.Songs
                    .AsNoTracking()
                    .GroupBy(s => s.Genre.Title)
                    .Select(x => new
                    {
                        Title = x.Key,
                        NumOfSongs = x.Count()
                    });

                Console.WriteLine("\nNumber of songs in each genre:");
                foreach (var item in secongQuery)
                {
                    Console.WriteLine($"{item.Title} - {item.NumOfSongs}");
                }
            }

            using(var dbContext = new DataBaseContext())
            {
                //Вывести песни, которые были написаны (ReleasedDate) до рождения самого молодого исполнителя.
                var thirdQuery = dbContext.Songs
                    .AsNoTracking()
                    .Where(s => s.RealeasedDate < dbContext.Artists.AsNoTracking().Max(a => a.DateOfBirth))
                    .Select(x => new
                    {
                        SongTitle = x.Title
                    });

                Console.WriteLine($"\nSongs released before youngest artist was born:");
                foreach (var item in thirdQuery)
                {
                    Console.WriteLine(item.SongTitle);
                }
            }
        }
    }
}