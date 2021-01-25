namespace EntityFrameWork_CodeFirst_FluentAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Admin.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                        Section = c.String(),
                    })
                .PrimaryKey(t => t.GradeId);
            
            CreateTable(
                "Admin.StudentData",
                c => new
                    {
                        DoB = c.DateTime(precision: 7, storeType: "datetime2"),
                        Guid = c.Guid(nullable: false),
                        StudentName = c.String(maxLength: 50),
                        Photo = c.Binary(),
                        Height = c.Decimal(precision: 18, scale: 2),
                        Weight = c.Single(nullable: false),
                        Row = c.Int(nullable: false, identity: true),
                        CurrentGradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("Admin.Grades", t => t.CurrentGradeId, cascadeDelete: true)
                .Index(t => t.CurrentGradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Admin.StudentData", "CurrentGradeId", "Admin.Grades");
            DropIndex("Admin.StudentData", new[] { "CurrentGradeId" });
            DropTable("Admin.StudentData");
            DropTable("Admin.Grades");
        }
    }
}
