using Library.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DBContext
{
    public class LibraryManagementContext: DbContext
    {
        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options):base (options)
        {

        }
        DbSet<Book> Book { get; set; }
        DbSet<User> User { get; set; }
    }
}
