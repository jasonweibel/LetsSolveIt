namespace Ideas.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserVotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaigns", "MaxNumberOfUserVotes", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "CommentText", c => c.String());
            AddColumn("dbo.Submissions", "Suggestion", c => c.String());
            AddColumn("dbo.UserVotes", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.Comments", "Text");
            DropColumn("dbo.Submissions", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submissions", "Text", c => c.String());
            AddColumn("dbo.Comments", "Text", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            DropColumn("dbo.UserVotes", "CreatedDate");
            DropColumn("dbo.Submissions", "Suggestion");
            DropColumn("dbo.Comments", "CommentText");
            DropColumn("dbo.Users", "CreatedDate");
            DropColumn("dbo.Campaigns", "MaxNumberOfUserVotes");
        }
    }
}
