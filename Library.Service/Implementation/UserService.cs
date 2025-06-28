using Library.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDAL.Interfaces;
using Library.Service.Dtos;
using AutoMapper;

namespace Library.Service.Implementation
{
    public  class UserService:IUserService
    {
        private  readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;   
        }

        public async  Task<LoginResponseDto> Login(string username, string password)
        {
            if (username==null ||password==null) throw new ArgumentNullException();
           
           var result=await _userRepository.Login(username, password);
            return _mapper.Map<LoginResponseDto>(result);
        }

        public async Task<bool> Register(string username, string email, string password)
        {
            if (username == null || password == null||email==null) throw new ArgumentNullException();
            return await _userRepository.Register(username,email,password);
        }
    }
}
