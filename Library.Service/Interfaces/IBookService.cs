
using Library.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Interfaces
{
    public  interface IBookService
    {
        public Task<string> SeedBookDummyDataifNull();
        public Task<List<GetBookDto>> GetAllCurrentBooks();
        public Task<List<GetBookDto>> GetFilteredBooks(string query);
    }
}
