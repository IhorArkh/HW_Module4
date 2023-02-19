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
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.ProjectId);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Budget).HasColumnType("money");
            builder.Property(x => x.StartedDate).HasColumnType("date");
            builder.HasOne(x => x.Client).WithMany(x => x.Projects).HasForeignKey(x => x.ClientId);
            builder.HasData(new Project { ProjectId = 1, Budget = 1100, ClientId = 1, Name = "Proj1", StartedDate = new DateTime(2023, 1, 1) });
            builder.HasData(new Project { ProjectId = 2, Budget = 1200, ClientId = 5, Name = "Proj2", StartedDate = new DateTime(2022, 1, 1) });
            builder.HasData(new Project { ProjectId = 3, Budget = 1300, ClientId = 4, Name = "Proj3", StartedDate = new DateTime(2021, 1, 1) });
            builder.HasData(new Project { ProjectId = 4, Budget = 1400, ClientId = 3, Name = "Proj4", StartedDate = new DateTime(2020, 1, 1) });
            builder.HasData(new Project { ProjectId = 5, Budget = 11000, ClientId = 2, Name = "Proj5", StartedDate = new DateTime(2019, 1, 1) });
        }
    }
}
