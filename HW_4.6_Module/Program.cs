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
                var sgs = dbContext.ArtistSongs
                    .AsNoTracking()
                    .Include(s => s.Song)
                    .ThenInclude(s => s.Genre)
                    .Include(s => s.Artist)
                    .GroupBy(s => s.Song.Title);

                foreach (var item in sgs)
                {
                    if (item.All(x => x.Artist.DateOfDeath == null))
                    {
                        Console.WriteLine($"{item.Key}");
                    }
                }
                //cant display on console artist and genre, but works correctly

                //var songs = dbContext.ArtistSongs
                //    .AsNoTracking()
                //    .Include(s => s.Song)
                //    .ThenInclude(s => s.Genre)
                //    .Include(s => s.Artist)
                //    .Where(s => s.Song.GenreId != null && s.Artist.DateOfDeath == null);

                //Console.WriteLine("Song which has genre and artist is alive:");
                //foreach (var song in songs)
                //{
                //    Console.WriteLine($"{song.Song.Title} - {song.Artist.Name} - {song.Song.Genre.Title}");
                //}
            }

            using (var dbContext = new DataBaseContext())
            {
                //Вывести кол-во песен в каждом жанре
                var numOfSongsInGenre = dbContext.Songs
                    .AsNoTracking()
                    .GroupBy(s => s.Genre.Title);

                Console.WriteLine("\nNumber of songs in each genre:");
                foreach (var item in numOfSongsInGenre)
                {
                    Console.WriteLine($"{item.Key}  - {item.Count()}");
                }
                Console.WriteLine();
            }

            using(var dbContext = new DataBaseContext())
            {
                //Вывести песни, которые были написаны (ReleasedDate) до рождения самого молодого исполнителя.
                var youngestArtistBirth = dbContext.Artists
                    .AsNoTracking()
                    .Max(a => a.DateOfBirth);

                var songs = dbContext.Songs
                    .AsNoTracking()
                    .Where(s => s.RealeasedDate < youngestArtistBirth);

                Console.WriteLine($"Songs released before youngest artist was born ({youngestArtistBirth.ToShortDateString()}):");
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Title);
                }
            }
        }
    }
}