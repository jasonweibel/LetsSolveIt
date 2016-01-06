using System.Collections.Generic;
using System.Web.Http;
using Ideas.DAL;
using LetsSolveIt.BLL;
using LetsSolveIt.DomainModel;

namespace Ideas.WebService.Controllers
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
