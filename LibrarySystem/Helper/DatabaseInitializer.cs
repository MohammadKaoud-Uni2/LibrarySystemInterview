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
        public  async Task<bool> DatabaseExistsAsync(string dbName)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var builder = new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = "master"
            };

            var query = "SELECT COUNT(*) FROM sys.databases WHERE name = @DbName";

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DbName", dbName);
                    var count = (int)await cmd.ExecuteScalarAsync();
                    return count > 0;
                }
            }
        }


        public async Task InitializeDatabaseAsync()
        {
            var scriptPath = Path.Combine(_environment.ContentRootPath, "Scripts", "script2.sql");

      
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

            using (SqlConnection conn = new SqlConnection(masterBuilder.ConnectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(createDbScript, conn))
                {
                    await cmd.ExecuteNonQueryAsync();
                }
            }

        
            var libraryConnStr = connectionString;
            var schemaScript = await File.ReadAllTextAsync(scriptPath);

            var commands = Regex.Split(schemaScript, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            using (SqlConnection conn = new SqlConnection(libraryConnStr))
            {
                await conn.OpenAsync();
                foreach (var commandText in commands)
                {
                    if (!string.IsNullOrWhiteSpace(commandText))
                    {
                        using (SqlCommand cmd = new SqlCommand(commandText, conn))
                        {
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                }
            }

            Console.WriteLine("Done");
        }
    }
}
