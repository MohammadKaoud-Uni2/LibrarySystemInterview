using Library.Service.Interfaces;
using LibraryDAL.Models;
using LibrarySystem.Models;
using LibrarySystem.Presentation.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Security.Claims;

namespace LibrarySystem.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(GlobalActionFilter))]
    public class BorrowingController : Controller
    {
        private readonly IBorrowingService _borrowingService;
        private readonly ILogger<BorrowingController> _logger;
        private readonly IBookService _bookService;
        public BorrowingController(IBorrowingService borrowingService,ILogger<BorrowingController> logger,IBookService bookService)
        {
            _borrowingService = borrowingService;
            _logger = logger;
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<IActionResult> Borrow([FromQuery] Guid bookId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
             await _borrowingService.BorrowBook(userId, bookId);
                var AllBook=await _bookService.GetAllCurrentBooks();
                return RedirectToAction("Index","Home",AllBook);
            
          

        }
        [HttpGet]
        public async Task<IActionResult> BorrowedBooks()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
           
                var result = await _borrowingService.GetBorrowedBook(userId);
               return   result != null ? View("BorrowedBooks",result):View("BorrowedBooks", null);
             
           
          
        }
        [HttpGet]
        public async Task<IActionResult> ReturnBook(Guid bookId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var updateReturnResult = await _borrowingService.ReturnBook(userId, bookId);

            if (updateReturnResult != "Success")
            {
                _logger.LogError("Failed while updating return in DB");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            var result = await _borrowingService.GetBorrowedBook(userId);
            return View("BorrowedBooks", result);

        }

    }
}
