namespace Ideas.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserNameToUsersObject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "User_Id", c => c.Int());
            CreateIndex("dbo.Comments", "User_Id");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Comments", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "UserName", c => c.String(maxLength: 250));
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropColumn("dbo.Comments", "User_Id");
        }
    }
}
