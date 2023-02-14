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
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.EmployeeId);
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.DateOfBirth).HasColumnType("date");
            builder.HasOne(x => x.Office).WithMany(x => x.Employee).HasForeignKey(x => x.OfficeId);
            builder.HasOne(x => x.Title).WithMany(x => x.Employee).HasForeignKey(x => x.TitleId); 
        }
    }
}
