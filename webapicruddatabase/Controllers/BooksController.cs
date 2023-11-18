using Microsoft.AspNetCore.Mvc;
using webapicruddatabase.Data;
using webapicruddatabase.Dtos;
using webapicruddatabase.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapicruddatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksContext _con;

        public BooksController(BooksContext con)  //dependency injection
        {
            this._con = con;
        }
        // GET: api/<BooksController>
        [HttpGet("GetBooks")]
        public List<BookDTO> Get()
        {
            return _con.TableBooks.ToList();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public BookDTO Get(int id)
        {
            return _con.TableBooks.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST api/<BooksController>
        [HttpPost("PostBook")]
        public void Post(BookDTO book)
        {
            if (book != null)
            {
                _con.TableBooks.Add(book);
                _con.SaveChanges();
            }

        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id,[FromQuery] string? bookname,string? bookdescription)
        {
            try
            {
                BookDTO bookupdate = _con.TableBooks.Where(x => x.Id == id).FirstOrDefault();
                if(string.IsNullOrEmpty(bookname))
                {
                    bookupdate.BookName = bookupdate.BookName;
                }
                else
                {
                    bookupdate.BookName = bookname;
                }
                if (string.IsNullOrEmpty(bookdescription))
                {
                    bookupdate.BookDescription = bookupdate.BookDescription;
                }
                else
                {
                    bookupdate.BookDescription = bookdescription;
                }
              
               
               // bookupdate.Published = book.Published;
                _con.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            


        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var book=_con.TableBooks.Where(x => x.Id == id).FirstOrDefault();
            _con.TableBooks.Remove(book);
            _con.SaveChanges();
        }
    }
}
