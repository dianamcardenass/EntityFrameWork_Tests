namespace EntityFrameWork_CodeFirst_FluentAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db_v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Admin.StudentData", "Diana", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Admin.StudentData", "Diana");
        }
    }
}
