using LibraryDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using Microsoft.Extensions.Configuration;
using LibraryDAL.Models;
namespace LibraryDAL.Implementation
{
    public  class UserReposiory:IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public UserReposiory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<User> Login(string userName, string password)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("Sp_LoginUser", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new User
                        {
                            UserId = reader["UserId"] != DBNull.Value ? (Guid)reader["UserId"]:Guid.Empty,
                            UserName = reader["UserName"] != DBNull.Value ? (string)reader["UserName"] : null,
                            Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : null
                        };
                    }
                }
            }
            return null;
        }

        public async Task<bool> Register(string UserName, string Email, string Password)
        {

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_RegisterUser", conn))

            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", UserName);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password); 

                conn.Open();
                try
                {
                   await  cmd.ExecuteReaderAsync();
                    return true;
                }
                catch (SqlException ex)
                {
                  
                    return false;
                }
            }
        }
    }
}
