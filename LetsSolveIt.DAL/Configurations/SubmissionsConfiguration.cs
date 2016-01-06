using System.Data.Entity.ModelConfiguration;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.DAL.Configurations
{
    public class SubmissionsConfiguration : EntityTypeConfiguration<Submissions>
    {
        public SubmissionsConfiguration()
        {
            //Property(p => p.Text).HasMaxLength(250);
        }
    }
}
