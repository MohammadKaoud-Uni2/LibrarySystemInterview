using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Library.Service.Interfaces;
using System.Security.Claims;

namespace LibrarySystem.Presentation.Filters
{
    public class GlobalActionFilter : IActionFilter
    {
        private readonly ILogger<GlobalActionFilter> _logger;
        private readonly IBorrowingService _borrowingService;
        private readonly IHttpContextAccessor _contextAccessor;
        public GlobalActionFilter(ILogger<GlobalActionFilter> logger,IBorrowingService borrowingService,IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _borrowingService = borrowingService;
            _contextAccessor = httpContextAccessor;


        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                var count = _borrowingService.GetCountofBorrowedBook(userId).Result;
                context.HttpContext.Items["BorrowedCount"] = count;
            }
            var controller = context.Controller.GetType().Name;
            var action = context.ActionDescriptor.DisplayName;
            _logger.LogInformation($" {controller} - {action} at {DateTime.UtcNow}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.Controller.GetType().Name;
            var action = context.ActionDescriptor.DisplayName;

            if (context.Exception != null)
            {
                _logger.LogError(context.Exception, $" Exception in {controller} - {action}");
                context.Result = new ViewResult
                {
                    ViewName = "Error",
                    ViewData = { ["RequestId"] = Activity.Current?.Id ?? context.HttpContext.TraceIdentifier }
                };
                context.ExceptionHandled = true; 
            }
            else
            {
                _logger.LogInformation($"[END] {controller} - {action} at {DateTime.UtcNow}");
            }
        }
    }
}
