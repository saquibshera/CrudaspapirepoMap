using webapicruddatabase.Models;

namespace webapicruddatabase.Repository
{
    public interface IBookRepo
    {
        void PostBook(Books book);
        List<Books> GetBooks();

        void DeleteBook(int id);
    }
}
