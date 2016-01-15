using System.Collections.Generic;
using System.Web.Http;
using LetsSolveIt.BLL;
using LetsSolveIt.DAL;
using LetsSolveIt.DomainModel;

namespace LetsSolveIt.WebService.Controllers
{
    public class UserController : ApiController
    {
        private static readonly LetsSolveItContext _context = new LetsSolveItContext();
        private readonly UserLogic _bll = new UserLogic(_context);

        public List<Users> Get()
        {
            return _bll.Get();
        }

        public Users Get(int id)
        {
            return _bll.Get(id);
        }

        public void Post([FromBody]Users value)
        {
            _bll.Save(value);
        }

        public void Put(int id, [FromBody]Users value)
        {
            _bll.Save(value);
        }

        public void Delete(int id)
        {
            _bll.Delete(id);
        }
    }
}
