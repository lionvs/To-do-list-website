namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TaskName = c.String(),
                        IsFinished = c.Boolean(nullable: false),
                        TaskCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.TaskCategory_Id)
                .Index(t => t.TaskCategory_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(nullable: false),
                        SubName = c.String(),
                        IsFinished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SubTasks", new[] { "TaskId" });
            DropIndex("dbo.Tasks", new[] { "TaskCategory_Id" });
            DropForeignKey("dbo.SubTasks", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "TaskCategory_Id", "dbo.Categories");
            DropTable("dbo.SubTasks");
            DropTable("dbo.Categories");
            DropTable("dbo.Tasks");
        }
    }
}
