using AutoMapper;
using Library.Service.Dtos;
using Library.Service.Interfaces;
using LibraryDAL.Implementation;
using LibraryDAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Service.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepoistory _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepoistory bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<GetBookDto>> GetAllCurrentBooks()
        {
            var allBooks = await _bookRepository.GetAllBook();
            return _mapper.Map<List<GetBookDto>>(allBooks);
        }

        public async Task<List<GetBookDto>> GetFilteredBooks(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return await GetAllCurrentBooks();
            }

            var filteredBooks = await _bookRepository.GetFilteredBook(query);

            return filteredBooks?.Count == 1 &&
                   filteredBooks[0].Title == "No matching books found."
                ? new List<GetBookDto>()
                : _mapper.Map<List<GetBookDto>>(filteredBooks);
        }

        public Task<string> SeedBookDummyDataifNull() =>
            _bookRepository.SeedDummyDataIfNull();
    }
}