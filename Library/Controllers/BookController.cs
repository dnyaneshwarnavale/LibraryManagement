using Library.Models;
using Library.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
   
    public class BookController : Controller
    {       
        IBookRepository bookRepository;
        public BookController(IBookRepository _bookRepository)  // DI using constructor
        {
            bookRepository = _bookRepository;
        }
        public ViewResult Index()
        {
            return View();
            // return books;
        }
        [HttpGet]
        [ActionName("Add")]
        public ViewResult EditBookPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {
            return RedirectToAction("Add");
        }
        [HttpPut]
        [ActionName ("Put")]
        public IActionResult Update(Book book)
        {
            // update logic
            return RedirectToAction("Add");
        }
        [HttpPatch]
        public IActionResult Patch(Book book)
        {
            // patch logic
            return RedirectToAction("Add");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            // delete logic
            return RedirectToAction("Add");
        }

        [Route("{controller}/{action}/{id}/{name}")]
        public ViewResult Details(int id)
        {
            Book book= bookRepository.GetBook(id);
            return View(book);
        }

        public List <Book> SearchBook(string name, int id)
        {
           var result= bookRepository.GetBooks().ToList().FindAll(x => x.Name.Contains(name) || x.ID < id - 4 || x.ID > id + 4);
            return result;
        }
    }
}
