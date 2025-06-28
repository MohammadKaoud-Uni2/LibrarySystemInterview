
using LibraryDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Interfaces
{
    public  interface IBookRepoistory
    {
        public Task<string> SeedDummyDataIfNull();
        public Task<List<Book>> GetAllBook();
        public Task<List<Book>> GetFilteredBook(string query);
    }
}
