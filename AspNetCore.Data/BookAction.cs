using AspNetCore.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace AspNetCore.Data
{
    public class BookAction : IBookAction
    {
        private readonly AspNetCoreDbContext db;

        public BookAction(AspNetCoreDbContext db)
        {
            this.db = db;
        }

        public Book Add(Book newBook)
        {
            db.Add(newBook);
            return newBook;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Book Delete(int id)
        {
            Book deleteBook = GetById(id);
            if (deleteBook != null)
                db.Remove(deleteBook);
            return deleteBook;
        }

        public Book GetById(int id)
        {
            Book book = db.Books.Find(id);
            return book;
        }

        public int GetCountOfBooks()
        {
            return db.Books.Count();
        }

        public IEnumerable<Book> GetList()
        {
            return db.Books;
        }

        public Book Update(Book updatedBook)
        {
            var entity = db.Books.Attach(updatedBook);
            entity.State = EntityState.Modified;
            return updatedBook;
        }
    }
}
