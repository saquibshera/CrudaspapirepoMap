using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using webapicruddatabase.Data;
using webapicruddatabase.Dtos;
using webapicruddatabase.Models;

namespace webapicruddatabase.Repository
{
    public class BookRepo : IBookRepo
    {
        private readonly BooksContext _con;
        private readonly IMapper _mapper;

        public BookRepo(BooksContext con,IMapper mapper)
        {
            this._con = con;
            this._mapper = mapper;
        }
        public void DeleteBook(int id)
        {
            var book=_con.TableBooks.Where(x => x.Id == id).FirstOrDefault();
            _con.TableBooks.Remove(book);
            _con.SaveChanges();
        }

        public List<Books> GetBooks()
        {

            var bookslist= _con.TableBooks.ToList();
           var booklists= _mapper.Map<List<Books>>(bookslist);
            return booklists;
           
        }

      

        public void PostBook(Books book)
        {
            //var bookk = new BookDTO { BookName = book.BookName,
            //    BookDescription=book.BookDescription,
            //    Published=book.Published };
            var bookk=_mapper.Map<BookDTO>(book);
            _con.TableBooks.Add(bookk);
            _con.SaveChanges();
        }
    }
}
