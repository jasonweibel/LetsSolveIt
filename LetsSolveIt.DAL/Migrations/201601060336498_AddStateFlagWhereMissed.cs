using System.Data.Entity.Migrations;

namespace LetsSolveIt.DAL.Migrations
{
    public partial class AddStateFlagWhereMissed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CampaignResources", "State", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "State", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "State", c => c.Boolean(nullable: false));
            AddColumn("dbo.Resources", "State", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserRoles", "State", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserVotes", "State", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserVotes", "State");
            DropColumn("dbo.UserRoles", "State");
            DropColumn("dbo.Resources", "State");
            DropColumn("dbo.Comments", "State");
            DropColumn("dbo.Users", "State");
            DropColumn("dbo.CampaignResources", "State");
        }
    }
}
