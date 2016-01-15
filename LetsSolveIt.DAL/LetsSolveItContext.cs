using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.DAL
{

    public class LetsSolveItContext : DbContext, ILetsSolveItContext
    {

        public IDbSet<CampaignResources> CampaignResources { get; set; }
        public IDbSet<Campaigns> Campaigns { get; set; }
        public IDbSet<Categories> Categories { get; set; }
        public IDbSet<Comments> Comments { get; set; }
        public IDbSet<Resources> Resources { get; set; }
        public IDbSet<Submissions> Submissions { get; set; }
        public IDbSet<UserRoles> UserRoles { get; set; }
        public IDbSet<Users> Users { get; set; }
        public IDbSet<UserVotes> UserVotes { get; set; }

        public LetsSolveItContext()
            : base("name=IdeasAppContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            new DbModelConfigurationBuilder().LoadConfigurations<LetsSolveItContext>(modelBuilder);
        }

        // DbEntityValidationException Approach via: http://stackoverflow.com/questions/15820505/dbentityvalidationexception-how-can-i-easily-tell-what-caused-the-error
        public override int SaveChanges()
        {
            //this.ApplyRules();

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }


    }

}