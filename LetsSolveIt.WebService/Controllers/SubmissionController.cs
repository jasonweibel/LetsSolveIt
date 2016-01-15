using System.Collections.Generic;
using System.Web.Http;
using LetsSolveIt.BLL;
using LetsSolveIt.DAL;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.WebService.Controllers
{
    [Authorize]
    public class SubmissionController : ApiController
    {
        private static readonly LetsSolveItContext _context = new LetsSolveItContext();
        private readonly SubmissionLogic _bll = new SubmissionLogic(_context);

        public List<Submissions> Get()
        {
            return _bll.Get();
        }

        public Submissions Get(int id)
        {
            return _bll.Get(id);
        }

        [Route("api/Submission/campaign/{campaignid}")]
        [HttpGet]
        public List<Submissions> GetSubmissionsForCampaign([FromUri] int campaignid)
        {
            return _bll.GetForCampaign(campaignid);
        }

        public void Post([FromBody]Submissions value)
        {
            _bll.Save(value);
        }

        public void Put(int id, [FromBody]Submissions value)
        {
            _bll.Save(value);
        }

        public void Delete(int id)
        {
            _bll.Delete(id);
        }
    }
}
