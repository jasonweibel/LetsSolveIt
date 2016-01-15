namespace LetsSolveIt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCampaignToUserLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaigns", "User_Id", c => c.Int());
            CreateIndex("dbo.Campaigns", "User_Id");
            AddForeignKey("dbo.Campaigns", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Campaigns", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Campaigns", "UserName", c => c.String());
            DropForeignKey("dbo.Campaigns", "User_Id", "dbo.Users");
            DropIndex("dbo.Campaigns", new[] { "User_Id" });
            DropColumn("dbo.Campaigns", "User_Id");
        }
    }
}
