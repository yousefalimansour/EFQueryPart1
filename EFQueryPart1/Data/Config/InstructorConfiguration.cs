using EF_Migration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Migration.Data.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //builder.Property(x => x.CourseName).HasMaxLength(255); ==> NVarchar!!? 
            builder.Property(x => x.FName)
                .IsRequired()
                .HasColumnType("VARCHAR")//=> varchar
                .HasMaxLength(55);
            builder.Property(x => x.LName)
               .IsRequired()
               .HasColumnType("VARCHAR")//=> varchar
               .HasMaxLength(55);

            builder.HasOne(e => e.office)
                   .WithOne(i => i.Instructor)
                   .HasForeignKey<Instructor>(e => e.OfficeId)
                   .IsRequired(false);

            builder.ToTable("Instructors");
           
        }
     
    }
}
