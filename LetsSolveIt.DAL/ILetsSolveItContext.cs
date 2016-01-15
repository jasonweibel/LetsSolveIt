using System.Data.Entity;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.DAL
{
    public interface ILetsSolveItContext
    {
        IDbSet<CampaignResources> CampaignResources { get; set; }
        IDbSet<Campaigns> Campaigns { get; set; }
        IDbSet<Categories> Categories { get; set; }
        IDbSet<Comments> Comments { get; set; }
        IDbSet<Resources> Resources { get; set; }
        IDbSet<Submissions> Submissions { get; set; }
        IDbSet<UserRoles> UserRoles { get; set; }
        IDbSet<Users> Users { get; set; }
        IDbSet<UserVotes> UserVotes { get; set; }

        int SaveChanges();

    }
}