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
    internal class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.HasKey(x => x.EmployeeProjectId);
            builder.Property(x => x.Rate).HasColumnType("money");
            builder.HasOne(x => x.Project).WithMany(x => x.EmployeeProject);
            builder.HasOne(x => x.Employee).WithMany(x => x.EmployeeProject);
        }
    }
}
