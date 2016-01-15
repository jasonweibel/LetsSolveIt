using System.Data.Entity.Migrations;

namespace LetsSolveIt.DAL.Migrations
{
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CampaignResources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Campaign_Id = c.Int(),
                        Comment_Id = c.Int(),
                        Resource_Id = c.Int(),
                        Submission_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_Id)
                .ForeignKey("dbo.Comments", t => t.Comment_Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .ForeignKey("dbo.Submissions", t => t.Submission_Id)
                .Index(t => t.Campaign_Id)
                .Index(t => t.Comment_Id)
                .Index(t => t.Resource_Id)
                .Index(t => t.Submission_Id);
            
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        State = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Campaigns_Id = c.Int(),
                        Submissions_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.Campaigns_Id)
                .ForeignKey("dbo.Submissions", t => t.Submissions_Id)
                .Index(t => t.Campaigns_Id)
                .Index(t => t.Submissions_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 250),
                        Text = c.String(),
                        Votes = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Votes = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                        Campaign_Id = c.Int(),
                        Category_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Campaign_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserVotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment_Id = c.Int(),
                        Submission_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.Comment_Id)
                .ForeignKey("dbo.Submissions", t => t.Submission_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Comment_Id)
                .Index(t => t.Submission_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserVotes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserVotes", "Submission_Id", "dbo.Submissions");
            DropForeignKey("dbo.UserVotes", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CampaignResources", "Submission_Id", "dbo.Submissions");
            DropForeignKey("dbo.Submissions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Submissions_Id", "dbo.Submissions");
            DropForeignKey("dbo.Submissions", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Submissions", "Campaign_Id", "dbo.Campaigns");
            DropForeignKey("dbo.CampaignResources", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.CampaignResources", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.CampaignResources", "Campaign_Id", "dbo.Campaigns");
            DropForeignKey("dbo.Users", "Campaigns_Id", "dbo.Campaigns");
            DropForeignKey("dbo.Campaigns", "Category_Id", "dbo.Categories");
            DropIndex("dbo.UserVotes", new[] { "User_Id" });
            DropIndex("dbo.UserVotes", new[] { "Submission_Id" });
            DropIndex("dbo.UserVotes", new[] { "Comment_Id" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.Submissions", new[] { "User_Id" });
            DropIndex("dbo.Submissions", new[] { "Category_Id" });
            DropIndex("dbo.Submissions", new[] { "Campaign_Id" });
            DropIndex("dbo.Users", new[] { "Submissions_Id" });
            DropIndex("dbo.Users", new[] { "Campaigns_Id" });
            DropIndex("dbo.Campaigns", new[] { "Category_Id" });
            DropIndex("dbo.CampaignResources", new[] { "Submission_Id" });
            DropIndex("dbo.CampaignResources", new[] { "Resource_Id" });
            DropIndex("dbo.CampaignResources", new[] { "Comment_Id" });
            DropIndex("dbo.CampaignResources", new[] { "Campaign_Id" });
            DropTable("dbo.UserVotes");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Submissions");
            DropTable("dbo.Resources");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            DropTable("dbo.Campaigns");
            DropTable("dbo.CampaignResources");
        }
    }
}
