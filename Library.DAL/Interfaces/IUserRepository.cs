
using LibraryDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> Register(string UserName,string Email,string Password);
        public Task<User> Login(string UserName,string Password); 

    }
}
