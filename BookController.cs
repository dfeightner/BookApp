
using BooksApp.Data;
using BooksApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Controllers
{
    public class BookController : Controller
    {
        private BooksDBContext _context;//variable that will hold a reference to the DBContext object

        public BookController(BooksDBContext context) //connects to database
        {
            _context = context;
        }


        public IActionResult Index()//read operation, it will list the books
        {
            var bookslist = _context.books.ToList();//ToList fetches a list of books from the books table under the database

            return View(bookslist);
        }

        [HttpGet]//optional
        public IActionResult Create() //http get request
        {
        
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book bookObj) //http post //Overloaded method //need to bring in namespace
        {
        
            _context.books.Add(bookObj); //adds the object to be added
            _context.SaveChanges(); //runs all the pending commands

            return RedirectToAction("Index", "Book");
       
        }

        public IActionResult Details(int id)
        {
            //talk to the Books table in the database and fetch the book with the specific ID that has been provided through the URL
           Book myBook = _context.books.Find(id); //fetches the book and saves it in a variable

           return View(myBook);

           
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //fetch the book from the books table

            Book myBook = _context.books.Find(id);
            
            return View(myBook);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("BookId,Title,Author,Description,DatePublished,Price,Genre")] Book myBook)
        {
            if(ModelState.IsValid)
            {
                //save changes to the database

                _context.books.Update(myBook);
                _context.SaveChanges(true);
            }
            return RedirectToAction("Index", "Book");
        }


    }
}
