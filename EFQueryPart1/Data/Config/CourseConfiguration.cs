using EF_Migration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Migration.Data.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();

            //builder.Property(x => x.CourseName).HasMaxLength(255); ==> NVarchar!!? 
            builder.Property(x => x.CourseName)
                .IsRequired()
                .HasColumnType("VARCHAR")//=> varchar
                .HasMaxLength(255);

            builder.Property(x => x.Price)
                .HasPrecision(15, 2);



            builder.ToTable("Courses");

           

        }


     
    }
}
