using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace LibrarySystem.Helper
{
    public class DatabaseInitializer
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public DatabaseInitializer(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public async Task<bool> DatabaseExistsAsync(string dbName)
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                var builder = new SqlConnectionStringBuilder(connectionString)
                {
                    InitialCatalog = "master"
                };

                var query = "SELECT COUNT(*) FROM sys.databases WHERE name = @DbName";

                using var conn = new SqlConnection(builder.ConnectionString);
                await conn.OpenAsync();

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DbName", dbName);
                var count = (int)await cmd.ExecuteScalarAsync();

                return count > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($" database  Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"unexpected Error: {ex.Message}");
                return false;
            }
        }

        public async Task InitializeDatabaseAsync()
        {
            try
            {
                var scriptPath = Path.Combine(_environment.ContentRootPath, "Scripts", "LibrarySystemUpdated.sql");
                if (!File.Exists(scriptPath))
                {
                    Console.WriteLine(" file not found.");
                    return;
                }

                var connectionString = _configuration.GetConnectionString("DefaultConnection");

                var masterBuilder = new SqlConnectionStringBuilder(connectionString)
                {
                    InitialCatalog = "master"
                };

                var createDbScript = @"
                    IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Library')
                    BEGIN
                        CREATE DATABASE Library;
                    END";

                using (var conn = new SqlConnection(masterBuilder.ConnectionString))
                {
                    await conn.OpenAsync();
                    using var cmd = new SqlCommand(createDbScript, conn);
                    await cmd.ExecuteNonQueryAsync();
                }

                var commands = Regex.Split(await File.ReadAllTextAsync(scriptPath), @"^\s*GO\s*$", RegexOptions.Multiline);

                using var libraryConn = new SqlConnection(connectionString);
                await libraryConn.OpenAsync();

                foreach (var commandText in commands)
                {
                    if (!string.IsNullOrWhiteSpace(commandText))
                    {
                        using var cmd = new SqlCommand(commandText, libraryConn);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                Console.WriteLine(" Database initialized successfully.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($" database  error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Init error: {ex.Message}");
            }
        }
    }
}
