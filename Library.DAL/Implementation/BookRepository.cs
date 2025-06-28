
using LibraryDAL.Interfaces;
using LibraryDAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Implementation
{
    public class BookRepository : IBookRepoistory
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public BookRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Book>> GetAllBook()
        {
            var ListofBook = new List<Book>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetAllBooks", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync()) 
                            {
                                ListofBook.Add(new Book()
                                {
                                    Author = reader["Author"] != DBNull.Value ? (string)reader["Author"] : null,
                                    Title = reader["Title"] != DBNull.Value ? (string)reader["Title"] : null,
                                    ISBN = reader["ISBN"] != DBNull.Value ? (string)reader["ISBN"] : null,
                                    BookId = reader["BookId"] != DBNull.Value ? (Guid)reader["BookId"] : Guid.Empty,
                                    ISAvailable = reader["ISAvailable"] != DBNull.Value ? (bool)reader["ISAvailable"] : true
                                });
                            }
                        }
                    }
                }
                return ListofBook;
            }
            catch (SqlException ex)
            {
              
                throw new ApplicationException("Database error occurred while fetching books", ex);
            }
            catch (Exception ex)
            {
               
                throw new ApplicationException("An unexpected error occurred", ex);
            }
        }

        public async Task<List<Book>> GetFilteredBook(string query)
        {
            var ListofBook = new List<Book>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SearchBooks", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Query", query);
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                ListofBook.Add(new Book()
                                {
                                    Author = reader["Author"] != DBNull.Value ? (string)reader["Author"] : null,
                                    Title = reader["Title"] != DBNull.Value ? (string)reader["Title"] : null,
                                    ISBN = reader["ISBN"] != DBNull.Value ? (string)reader["ISBN"] : null,
                                    BookId = reader["BookId"] != DBNull.Value ? (Guid)reader["BookId"] : Guid.Empty,
                                    ISAvailable = reader["ISAvailable"] != DBNull.Value ? (bool)reader["ISAvailable"] : true
                                });
                            }
                        }
                    }
                }
                return ListofBook;
            }
            catch (SqlException ex)
            {

                throw new ApplicationException("Database error occurred while fetching books", ex);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("An unexpected error occurred", ex);
            }
        }

        public async Task<string> SeedDummyDataIfNull()
        {
            var  resultofInserting = "";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SeedDummyBooks", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        try
                        {
                         
                            if (await reader.ReadAsync())
                            {


                                resultofInserting = reader["Result"] != DBNull.Value ? (string)reader["Result"] : null;

                            }

                        }
                        catch (SqlException ex)
                        {
                            return null;
                        }

                    }
                    return resultofInserting;
                }

            }
        }
    }
}
