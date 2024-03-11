using BookLibrary.Models;
using BookLibrary.Repository;

namespace BookLibrary.Service
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepo repo;
        public LibraryService(ILibraryRepo repo)
        {
            this.repo = repo;
        }
        public int AddBook(Library library)
        {
            return repo.AddBook(library);
        }

        public int DeleteBook(int id)
        {
            return repo.DeleteBook(id);
        }

        public Library GetBookByID(int id)
        {
          return repo.GetBookByID(id);
        }

        public IEnumerable<Library> GetBookByTitle(string name)
        {
            return repo.GetBookByTitle(name);
        }




        public IEnumerable<Library> GetBooks()
        {
            return repo.GetBooks();
        }
    }
}
