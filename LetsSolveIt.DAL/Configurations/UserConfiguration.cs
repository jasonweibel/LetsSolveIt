using System.Data.Entity.ModelConfiguration;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.DAL.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<Users>
    {
        public UserConfiguration()
        {
            Property(p => p.UserName).IsRequired();
            Property(p => p.UserName).IsRequired().HasMaxLength(250);
        }
    }
}
