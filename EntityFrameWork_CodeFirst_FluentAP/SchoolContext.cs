using EntityFrameWork_CodeFirst_FluentAP;
using EntityFrameWork_CodeFirst_FluentAP.Migrations;
using System;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;


namespace EntityFramework_CodeFirst.FluentAPI
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=SchoolDB2ConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolContext, Configuration>());

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here..
            //Configure default schema
            modelBuilder.HasDefaultSchema("Admin");

            // Moved all Student related configuration to StudentEntityConfiguration class
            modelBuilder.Configurations.Add(new StudentEntityConfiguration());

            modelBuilder.Entity<Grade>()
            .HasMany<Student>(g => g.Students)
            .WithRequired(s => s.Grade)
            .WillCascadeOnDelete();

        }
    }
}
