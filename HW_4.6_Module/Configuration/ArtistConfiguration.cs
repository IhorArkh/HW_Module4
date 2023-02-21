using HW_4._3_CreatingDB.Models;
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
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DateOfBirth).HasColumnType("date");
            builder.Property(x => x.DateOfDeath).HasColumnType("date");

            Artist fiftyCent = new Artist
            {
                Id = 1,
                Name = "50 Cent",
                DateOfBirth = new DateTime(1975, 7, 6),
                Email = "50cent@gmail.com",
                InstagramUrl = "www.instagram.com/50cent/",
            };
            Artist beyonce = new Artist
            {
                Id = 2,
                Name = "Beyonce",
                DateOfBirth = new DateTime(1981, 9, 4),
            };
            Artist akon = new Artist
            {
                Id = 3,
                Name = "Akon",
                DateOfBirth = new DateTime(1981, 9, 4),
            };
            Artist eminem = new Artist
            {
                Id = 4,
                Name = "Eminem",
                DateOfBirth = new DateTime(1972, 10, 17),
            };
            Artist liMorgan = new Artist
            {
                Id = 5,
                Name = "Li Morgan",
                DateOfBirth = new DateTime(1938, 7, 10),
                DateOfDeath = new DateTime(1972, 2, 19),
            };

            builder.HasData(fiftyCent, beyonce, akon, eminem, liMorgan);
        }
    }
}
