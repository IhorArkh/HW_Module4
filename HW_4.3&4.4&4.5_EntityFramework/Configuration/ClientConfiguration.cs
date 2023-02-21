using HW_4._3_CreatingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4._3_CreatingDB.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.ClientId);
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.Country).HasMaxLength(30);
            builder.Property(x => x.StartedDate).HasColumnType("date");
            builder.Property(x => x.EndedDate).HasColumnType("date");
            builder.HasData(new Client { ClientId = 1, Name = "Adam", Country = "Ukraine", StartedDate = new DateTime(2022, 12, 12) });
            builder.HasData(new Client { ClientId = 2, Name = "John", Country = "USA", StartedDate = new DateTime(2021, 1, 2) });
            builder.HasData(new Client { ClientId = 3, Name = "Elena", Country = "China", StartedDate = new DateTime(2015, 5, 17), EndedDate = new DateTime(2022, 5, 6) });
            builder.HasData(new Client { ClientId = 4, Name = "Eva", Country = "Sweden", StartedDate = new DateTime(2020, 11, 11) });
            builder.HasData(new Client { ClientId = 5, Name = "Vlad", Country = "Canada", StartedDate = new DateTime(2010, 8, 28), EndedDate = new DateTime(2017, 8, 1) });
        }
    }
}
