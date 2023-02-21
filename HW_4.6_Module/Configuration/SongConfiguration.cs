using HW_4._6_Module.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4._6_Module.Configuration
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RealeasedDate).HasColumnType("date");
            builder.HasOne(x => x.Genre).WithMany(x => x.Songs);

            Song candyShop = new Song
            {
                Duration = "3:12",
                GenreId = 1,
                RealeasedDate = new DateTime(2005, 2, 8),
                Title = "Candy Shop",
                Id = 1
            };
            Song inDaClub = new Song
            {
                Duration = "3:25",
                GenreId = 1,
                RealeasedDate = new DateTime(2003, 2, 8),
                Title = "In Da Club",
                Id = 2
            };
            Song cuffIt = new Song
            {
                Duration = "3:45",
                GenreId = 3,
                RealeasedDate = new DateTime(2022, 5, 5),
                Title = "CUFF IT",
                Id = 3
            };
            Song smackThat = new Song
            {
                Duration = "3:31",
                GenreId = 1,
                RealeasedDate = new DateTime(2006, 2, 1),
                Title = "Smack That",
                Id = 4
            };
            Song ceora = new Song
            {
                Duration = "6:23",
                GenreId = 4,
                RealeasedDate = new DateTime(1967, 6, 6),
                Title = "Ceora",
                Id = 5
            };

            builder.HasData(candyShop, inDaClub, cuffIt, smackThat, ceora);
        }
    }
}
