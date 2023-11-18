using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapicruddatabase.Dtos;
using webapicruddatabase.Models;
using webapicruddatabase.Repository;

namespace webapicruddatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksrepoController : ControllerBase
    {
        private readonly IBookRepo _repo;

        public BooksrepoController(IBookRepo repo)
        {
            this._repo = repo;
        }
        [HttpGet("GetBooks")]
        public List<Books> GetBooks()
        {
            return _repo.GetBooks();
        }
        [HttpPost("PostBook")]
        public void PostBook(Books book)
        {
            _repo.PostBook(book);
        }
    }
}
