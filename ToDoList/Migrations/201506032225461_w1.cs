namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class w1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "TaskCategory_Id", "dbo.Categories");
            DropIndex("dbo.Tasks", new[] { "TaskCategory_Id" });
            RenameColumn(table: "dbo.Tasks", name: "TaskCategory_Id", newName: "CategoryId");
            AddForeignKey("dbo.Tasks", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            CreateIndex("dbo.Tasks", "CategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tasks", new[] { "CategoryId" });
            DropForeignKey("dbo.Tasks", "CategoryId", "dbo.Categories");
            RenameColumn(table: "dbo.Tasks", name: "CategoryId", newName: "TaskCategory_Id");
            CreateIndex("dbo.Tasks", "TaskCategory_Id");
            AddForeignKey("dbo.Tasks", "TaskCategory_Id", "dbo.Categories", "Id");
        }
    }
}
