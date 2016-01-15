using System.Collections.Generic;
using System.Web.Http;
using LetsSolveIt.BLL;
using LetsSolveIt.DAL;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.WebService.Controllers
{
    public class VoteController : ApiController
    {
        private static readonly LetsSolveItContext _context = new LetsSolveItContext();
        private readonly UserVoteLogic _bll = new UserVoteLogic(_context);

        public List<UserVotes> Get()
        {
            return _bll.Get();
        }

        public UserVotes Get(int id)
        {
            return _bll.Get(id);
        }

        public void Post([FromBody]UserVotes value)
        {
            _bll.Add(value);
        }

        public void Put(int id, [FromBody]UserVotes value)
        {
            _bll.Add(value);
        }

        public void Delete(int id)
        {
            _bll.Delete(id);
        }
    }
}
