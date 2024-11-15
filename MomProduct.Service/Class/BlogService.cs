using Dapper;
using Microsoft.Extensions.Configuration;
using MomProduct.Model;
using System.Data;
using System.Data.SqlClient;


namespace MomProduct.Service.Class
{
    public class BlogService: IBlogService
    {
        private readonly string _connectionString;

        public BlogService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            const string query = "SELECT * FROM BlogType";
            using var connection = CreateConnection();
            return await connection.QueryAsync<Blog>(query);
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            const string query = "SELECT * FROM Blogs WHERE Id = @Id";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Blog>(query, new { Id = id });
        }

        public async Task<int> AddAsync(Blog blog)
        {
            const string query = "INSERT INTO Blogs (Name) VALUES (@Name)";
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(query, blog);
        }

        public async Task<int> UpdateAsync(Blog blog)
        {
            const string query = "UPDATE Blogs SET Name = @Name WHERE Id = @Id";
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(query, blog);
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string query = "DELETE FROM Blogs WHERE Id = @Id";
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
