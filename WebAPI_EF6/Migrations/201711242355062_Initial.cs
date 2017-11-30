namespace WebAPI_EF6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Credits = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Dept = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        InstructorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instructors", t => t.InstructorId, cascadeDelete: true)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "InstructorId", "dbo.Instructors");
            DropIndex("dbo.Courses", new[] { "InstructorId" });
            DropTable("dbo.Instructors");
            DropTable("dbo.Courses");
        }
    }
}
