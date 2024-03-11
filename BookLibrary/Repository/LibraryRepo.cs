using BookLibrary.Data;
using BookLibrary.Models;

namespace BookLibrary.Repository
{
    public class LibraryRepo : ILibraryRepo
    {
        ApplicationDbContext db;
        public LibraryRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddBook(Library library)
        {
            db.libraries.Add(library);
            int res=db.SaveChanges();
            return res;
        }

        public int DeleteBook(int id)
        {
            int res = 0;
            var result = db.libraries.Where(x => x.Id== id).SingleOrDefault();
            if(result != null)
            {
                db.libraries.Remove(result);
                res = db.SaveChanges();
            }
            return res;
        }

        public Library GetBookByID(int id)
        {
            var result = db.libraries.Where(x=>x.Id==id).SingleOrDefault();
            return result;
        }



        public IEnumerable<Library> GetBookByTitle(string name)
        {
            var model=from b in db.libraries
                      where b.Name.Contains(name)  || b.Author.Contains(name)
                      select b;
            return model;

        }


        public IEnumerable<Library> GetBooks()
        {
          return db.libraries.ToList();
        }
    }
}
