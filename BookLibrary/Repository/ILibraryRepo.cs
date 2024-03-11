using BookLibrary.Models;

namespace BookLibrary.Repository
{
    public interface ILibraryRepo
    {
        public IEnumerable<Library> GetBooks();
         IEnumerable<Library> GetBookByTitle(string name);
        public Library GetBookByID(int id);
       
        public int AddBook(Library library);
        public int DeleteBook(int id);
    }
}
