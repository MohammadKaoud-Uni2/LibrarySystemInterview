using LibraryDAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDAL.Models;

namespace LibraryDAL.Implementation
{
    public class BorrowingRepository:IBorrowingRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public BorrowingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> BorrowBook(string userId, Guid bookId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("BorrowBook", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@BookId", bookId);

                        await conn.OpenAsync();
                        var result = await cmd.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
             

                throw new ApplicationException("A database error occurred while borrowing the book.", sqlEx);
            }
            catch (InvalidOperationException invOpEx)
            {
                throw new ApplicationException("A connection-related error occurred while borrowing the book.", invOpEx);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while borrowing the book.", ex);
            }
        }

        public  async Task<List<Borrowing>> GetBorrowedBooksByUser(string UserId)
        {
            var ListofBorrwedBook = new List<Borrowing>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetBooksBorrowedByUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", UserId);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                ListofBorrwedBook.Add(new Borrowing()
                                {
                                    Author = reader["Author"] != DBNull.Value ? (string)reader["Author"] : null,
                                    Title = reader["Title"] != DBNull.Value ? (string)reader["Title"] : null,
                                    ISBN = reader["ISBN"] != DBNull.Value ? (string)reader["ISBN"] : null,
                                    BookId = reader["BookId"] != DBNull.Value ? (Guid)reader["BookId"] : Guid.Empty,
                                    BorrowDate = reader["BorrowDate"] != DBNull.Value ? (DateTime)reader["BorrowDate"] : DateTime.Now,
                                });
                            }
                        }
                    }
                }
                return ListofBorrwedBook;
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

        public async Task<string> ReturnBook(string userId, Guid bookId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("ReturnBook", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", Guid.Parse(userId));
                        cmd.Parameters.AddWithValue("@BookId", bookId);

                  
                        SqlParameter outputParam = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        return outputParam.Value?.ToString() ?? "EMPTY:(";
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Database error occurred while returning the book", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred", ex);
            }
        }
    }
}
