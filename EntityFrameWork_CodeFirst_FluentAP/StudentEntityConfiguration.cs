using EntityFramework_CodeFirst.FluentAPI;
using System;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameWork_CodeFirst_FluentAP
{
    public class StudentEntityConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentEntityConfiguration()
        {
            this.ToTable("StudentData");

            //Configure primary key
            this.HasKey<Guid>(s => s.Guid);

            this.Property(p => p.DateOfBirth)
            .HasColumnName("DoB")
            .HasColumnOrder(3)
            .HasColumnType("datetime2");


            //Configure Null Column
            this.Property(p => p.Height)
                    .IsOptional();

            //Configure NotNull Column
            this.Property(p => p.Weight)
                .IsRequired();

            this.Property(p => p.StudentName)
            .HasMaxLength(50);

            // configures one-to-many relationship
            this.HasRequired<Grade>(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey<int>(s => s.CurrentGradeId);


        }
    }
}
