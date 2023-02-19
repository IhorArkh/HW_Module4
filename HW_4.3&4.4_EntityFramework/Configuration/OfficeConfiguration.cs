using HW_4._3_CreatingDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4._3_CreatingDB.Configuration
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(x => x.OfficeId);
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Location).HasMaxLength(100);
        }
    }
}
