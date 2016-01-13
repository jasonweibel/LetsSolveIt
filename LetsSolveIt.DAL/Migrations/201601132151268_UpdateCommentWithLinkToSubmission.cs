namespace Ideas.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCommentWithLinkToSubmission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Submission_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Submission_Id");
            AddForeignKey("dbo.Comments", "Submission_Id", "dbo.Submissions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Submission_Id", "dbo.Submissions");
            DropIndex("dbo.Comments", new[] { "Submission_Id" });
            DropColumn("dbo.Comments", "Submission_Id");
        }
    }
}
