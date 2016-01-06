using System.Collections.Generic;
using System.Web.Http;
using Ideas.DAL;
using LetsSolveIt.BLL;
using LetsSolveIt.DomainModel;

namespace Ideas.WebService.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        private static readonly LetsSolveItContext _context = new LetsSolveItContext();
        private readonly CategoryLogic _bll = new CategoryLogic(_context);

        public List<Categories> Get()
        {
            return _bll.Get();
        }

        public Categories Get(int id)
        {
            return _bll.Get(id);
        }

        public void Post([FromBody]Categories value)
        {
            _bll.Save(value);
        }

        public void Put(int id, [FromBody]Categories value)
        {
            _bll.Save(value);
        }

        public void Delete(int id)
        {
            _bll.Delete(id);
        }
    }
}
