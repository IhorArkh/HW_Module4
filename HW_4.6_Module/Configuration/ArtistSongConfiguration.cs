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
    public class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.HasKey(x => new { x.ArtistId, x.SongId });
            builder.HasOne(x => x.Artist).WithMany(x => x.ArtistSongs);
            builder.HasOne(x => x.Song).WithMany(x => x.ArtistSongs);
            builder.HasData(
                new ArtistSong
                {
                    ArtistId = 1,
                    SongId = 1
                },
                new ArtistSong
                {
                    ArtistId = 1,
                    SongId = 2
                },
                new ArtistSong
                {
                    ArtistId = 2,
                    SongId = 3
                },
                new ArtistSong
                {
                    ArtistId = 3,
                    SongId = 4
                },
                new ArtistSong
                {
                    ArtistId = 4,
                    SongId = 4
                },
                new ArtistSong
                {
                    ArtistId = 5,
                    SongId = 5
                });
        }
    }
}
