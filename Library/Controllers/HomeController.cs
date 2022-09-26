using Library.Binders;
using Library.Models;
using Library.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("Home/")] // attribut route
    public class HomeController : Controller
    {
        /* private IInterface _interface;
         public HomeController(IEnumerable<IInterface> interfaces)
         {
             _interface = interfaces.Where(x => x.Type == "First").FirstOrDefault();
         }
         */

        private PublisherUrl publisherUrl;

        private IScoped scoped;
        private IScoped secondscoped;
        private ISingleton singleton;
        private ISingleton secondsingleton;
        private ITransient transient;
        private ITransient secondtransient;

        public HomeController(IScoped _scoped,IScoped _secondscoped,ISingleton _singleton,ISingleton _secondsingleton,ITransient _transient,ITransient _secondtransient)
        {
            scoped = _scoped;
            secondscoped = _secondscoped;
            singleton = _singleton;
            secondsingleton = _secondsingleton;
            transient = _transient;
            secondtransient = _secondtransient;

        }


        public string Name { get; set; }
        [BindProperty(Name= "Country",SupportsGet=true)]
        public string Country { get; set; }
        public IBookRepository bookRepository1;  
        public string GetApplicationName()
        {
            return "The name of application is Library management";
        }
        [Route("/")]  // attribute route
        [Route("Index")]
        [Authorize]
        public ViewResult Index()
        {
            IBookRepository bookRepository = new BookRepository();
            var books = bookRepository.GetBooks();
            return View(books);

        }
        [Route ("Login")]
        [HttpGet]
        public IActionResult Login(String ReturnUrl)
        {
            return View();
        }

        [Route("AboutUs")]
        public ViewResult AboutUs()
        {
            ViewBag.scoped = scoped.GetData();
            ViewBag.transient = transient.GetData();
            ViewBag.singleton = singleton.GetData();

            ViewBag.secondscoped = secondscoped.GetData();
            ViewBag.secondtransient = secondtransient.GetData();
            ViewBag.secondsingleton = secondsingleton.GetData();
            
            return View();
        }
        [Route("DependentOnBook")]
        public Book DependentOnBook([FromServices] IBookRepository bookRepository) // DI using inject using method
        {
            return bookRepository.GetBook(3);
        }

        [Route ("GetString/{name?}/{country?}")]
        public string GetString(TestClass testClass)  // model binding
        {
            return testClass.name;
        }
       
        /* public string GetString([ModelBinder(typeof(CustomCapsBinder))]string name)  // model binder
         {
             return name;
         }
       */

      /*    [Route("GetString/{ID?}/{name?}")]
         public User GetString(User user)  // model binder
          {
              return user;
          }
        */
    }
}
