using System.Collections.Generic;
using System.Web.Http;
using Ideas.DAL;
using LetsSolveIt.BLL;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.WebService.Controllers
{
    [Authorize]
    public class CampaignController : ApiController
    {
        private static readonly LetsSolveItContext _context = new LetsSolveItContext();
        private readonly CampaignLogic _bll = new CampaignLogic(_context);

        public List<Campaigns> Get()
        {
            return _bll.Get();
        }

        public Campaigns Get(int id)
        {
            return _bll.Get(id);
        }

        public Campaigns Get(string name)
        {
            return _bll.Get(name);
        }

        [Route("{id}/submissions")]
        [HttpGet]
        public List<Submissions> GetSubmissionsForCampaign([FromUri] int id)
        {
            return _bll.GetSubmissionsForCampaign(id);
        }

        [Route("{id}/submissions/ids")]
        [HttpGet]
        public List<int> GetSubmissionIdsForCampaign([FromUri] int id)
        {
            return _bll.GetSubmissionIdsForCampaign(id);
        }

        public void Post([FromBody]Campaigns value)
        {
            _bll.Save(value);
        }

        public void Put(int id, [FromBody]Campaigns value)
        {
            _bll.Save(value);
        }

        public void Delete(int id)
        {
            _bll.Delete(id);
        }
    }
}
