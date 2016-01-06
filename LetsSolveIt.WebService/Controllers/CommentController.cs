using System.Collections.Generic;
using System.Web.Http;
using Ideas.DAL;
using LetsSolveIt.BLL;
using LetsSolveIt.DomainModel;

namespace Ideas.WebService.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        private static readonly LetsSolveItContext _context = new LetsSolveItContext();
        private readonly CommentLogic _bll = new CommentLogic(_context);

        public List<Comments> Get()
        {
            return _bll.Get();
        }

        public Comments Get(int id)
        {
            return _bll.Get(id);
        }

        public void Post([FromBody]Comments value)
        {
            _bll.Save(value);
        }

        public void Put(int id, [FromBody]Comments value)
        {
            _bll.Save(value);
        }

        public void Delete(int id)
        {
            _bll.Delete(id);
        }
    }
}
