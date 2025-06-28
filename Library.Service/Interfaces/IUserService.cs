
using Library.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Interface
{
    public  interface IUserService
    {
        public  Task<LoginResponseDto> Login(string email, string password);
        public Task<bool> Register(string username, string email, string password);
    }
}
