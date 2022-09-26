using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetBooks();
        public Book GetBook(int id);
    }
}
