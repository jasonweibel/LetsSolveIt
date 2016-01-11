using System.Data.Entity.ModelConfiguration;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.DAL.Configurations
{
    public class CommentsConfiguration : EntityTypeConfiguration<Comments>
    {
        public CommentsConfiguration()
        {
            //Property(p => p.UserName).HasMaxLength(250);
        }
    }
}
