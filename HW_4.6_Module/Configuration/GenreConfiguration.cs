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
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(
                new Genre { Id = 1, Title = "Hip Hop" },
                new Genre { Id = 2, Title = "Rock" },
                new Genre { Id = 3, Title = "R&B" },
                new Genre { Id = 4, Title = "Jazz" },
                new Genre { Id = 5, Title = "Disco" });
        }
    }
}
