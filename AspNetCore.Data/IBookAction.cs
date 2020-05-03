using AspNetCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Data
{
    public interface IBookAction
    {
        IEnumerable<Book> GetList();
        Book GetById(int id);
        Book Update(Book updatedBook);
        Book Add(Book newBook);
        Book Delete(int id);
        int Commit();

        int GetCountOfBooks();
    }
}
