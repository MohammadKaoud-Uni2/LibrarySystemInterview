
using Library.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Interfaces
{
    public  interface IBorrowingService
    {
        public Task<bool>BorrowBook(string userId,Guid bookId);
        public Task<List<GetBorrowedBookDto>> GetBorrowedBook(string userId);
        public Task<string> ReturnBook(string userId, Guid bookId);
        public Task<int> GetCountofBorrowedBook(string userId);
    }
}
