using Library.Service.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Presentation.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace LibrarySystem.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(GlobalActionFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
        private readonly IBorrowingService _borrowingService;
        public HomeController(IBookService bookService,ILogger<HomeController> logger,IBorrowingService borrowingService)
        {
            _bookService = bookService;
            _logger = logger;
            _borrowingService = borrowingService;
            
        }
        

        public async Task<IActionResult> Index()
        {
             var books = await _bookService.GetAllCurrentBooks();
                return View(books);

            
           
        }
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery]string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction("Index", "Home");
            }
           
               var result=await  _bookService.GetFilteredBooks(query);
            return result != null ? View("Index", result) : View("Index", null);
             
                
            
         
        }
      

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
