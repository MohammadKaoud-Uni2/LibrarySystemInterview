
using AutoMapper;
using Library.Service.Dtos;
using Library.Service.Interfaces;
using LibraryDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Implementation
{
    public  class BorrowingService:IBorrowingService
    {
        private readonly IBorrowingRepository _borrowingRepository;
        private readonly IMapper _mapper;
        public BorrowingService(IBorrowingRepository borrowingRepository,IMapper mapper)
        {
            _borrowingRepository = borrowingRepository;
            _mapper = mapper;
        }

        public async Task<bool> BorrowBook(string userId, Guid bookId)
        {
            if (bookId == Guid.Empty) throw new ArgumentException("Book ID cannot be empty", nameof(bookId));
            return await _borrowingRepository.BorrowBook(userId, bookId);
            
        }

        public async Task<List<GetBorrowedBookDto>> GetBorrowedBook(string userId)
        {
           var result=await _borrowingRepository.GetBorrowedBooksByUser(userId);
            return result.FirstOrDefault(x => x.Title == "No books borrowed by you") != null ? new List<GetBorrowedBookDto>()
                :_mapper.Map<List<GetBorrowedBookDto>>(result);
        }

        public  async Task<int> GetCountofBorrowedBook(string userId)
        {
            var result = await _borrowingRepository.GetBorrowedBooksByUser(userId);
            return result?.Count ?? 0;
        }

        public  async Task<string> ReturnBook(string userId, Guid bookId)
        {
           var result=await _borrowingRepository.ReturnBook(userId, bookId);
            return result == "No active borrowing record found" ? "noUpdate" : "Success";
            
        }
    }
}
