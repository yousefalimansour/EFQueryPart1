using EF_Migration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Migration.Data.Config
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //builder.Property(x => x.CourseName).HasMaxLength(255); ==> NVarchar!!? 
            builder.Property(x => x.SectionName)
                .IsRequired()
                .HasColumnType("VARCHAR")//=> varchar
                .HasMaxLength(255);

            builder.HasOne(s=>s.course)
                .WithMany(s=>s.Sections)
                .HasForeignKey(s=>s.CourseId)
                .IsRequired();

            builder.HasOne(s => s.instructor)
               .WithMany(s => s.Sections)
               .HasForeignKey(s => s.InstructorId)
               .IsRequired(false);

            builder.OwnsOne(s => s.TimeSlot, ts =>
            { 
                ts.Property(x=>x.StartTime).HasColumnType("time").HasColumnName("StartTime");
                ts.Property(x=>x.StartTime).HasColumnType("time").HasColumnName("EndTime");
            });

            builder.HasOne(x => x.schedule)
                .WithMany(s => s.Sections)
                .HasForeignKey(s => s.ScheduleId)
                .IsRequired();
                                

            builder.HasMany(x => x.Particpants)
               .WithMany(x => x.Sections)
               .UsingEntity<Enrollment>();
               


            builder.ToTable("Sections");

       

        }


       
    }


}
