using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{

    public class BookRepository : IBookRepository
    {
        private List<Book> _dataSource;
        public BookRepository()
        {
            _dataSource = new List<Book>();
            FillDataSource();
        }
        public Book GetBook(int id)
        {
            return _dataSource.Find(x => x.ID == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _dataSource;
        }
        private void FillDataSource()
        {
            _dataSource.Add(new Book {ID=1,Name="MVC",Author="Ram",Publication="ABC" });
            _dataSource.Add(new Book { ID = 2, Name = "C Sharp", Author = "Sham", Publication = "ABC" });
            _dataSource.Add(new Book { ID = 3, Name = "SQL", Author = "Raj", Publication = "ABC" });
            _dataSource.Add(new Book { ID = 4, Name = "DotNet", Author = "Ram ", Publication = "ABC" });
            _dataSource.Add(new Book { ID = 5, Name = "Java", Author = "XYZ", Publication = "ABC" });

        }
    }
}
