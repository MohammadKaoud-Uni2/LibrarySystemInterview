
using LibraryDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Interfaces
{
    public  interface IBorrowingRepository
    {
        public Task<bool> BorrowBook(string userId, Guid bookId);
        public Task<List<Borrowing>> GetBorrowedBooksByUser(string UserId);
        public Task<string> ReturnBook(string userId, Guid bookId);

    }
}
