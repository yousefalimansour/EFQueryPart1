using EF_Migration.Entities;
using EF_Migration.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Migration.Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //builder.Property(x => x.CourseName).HasMaxLength(255); ==> NVarchar!!? 
            builder.Property(x => x.Title)
                .HasConversion(
                     x => x.ToString(),
                     x => (SchduleEnum)Enum.Parse(typeof(SchduleEnum), x)
                );


            builder.ToTable("Schedules");

          

        }


       
    }

}
