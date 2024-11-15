using Dapper;
using Microsoft.Extensions.Configuration;
using MomProduct.Model;
using MomProduct.Service.Interface;
using System.Data;
using System.Data.SqlClient;

namespace MomProduct.Service.Class
{
    public class BlogTemplateService : IBlogTemplateService
    {
        private readonly string _connectionString;

        public BlogTemplateService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<BlogTemplate>> GetAllAsync()
        {
            const string query = "SELECT * FROM BlogTemplates";
            using var connection = CreateConnection();
            return await connection.QueryAsync<BlogTemplate>(query);
        }

        public async Task<BlogTemplate?> GetByIdAsync(int id)
        {
            const string query = "SELECT * FROM BlogTemplates WHERE Id = @Id";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<BlogTemplate>(query, new { Id = id });
        }

        public async Task<int> AddAsync(BlogTemplate blogTemplate)
        {
            const string query = @"
                INSERT INTO BlogTemplates (BlogTitle, BlogDescription, BlogContent, CreatedDate, CreatedBy) 
                VALUES (@BlogTitle, @BlogDescription, @BlogContent, @CreatedDate, @CreatedBy)";
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(query, blogTemplate);
        }

        public async Task<int> UpdateAsync(BlogTemplate blogTemplate)
        {
            const string query = @"
                UPDATE BlogTemplates 
                SET BlogTitle = @BlogTitle, 
                    BlogDescription = @BlogDescription, 
                    BlogContent = @BlogContent, 
                    ModifyDate = @ModifyDate, 
                    ModifyBy = @ModifyBy 
                WHERE Id = @Id";
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(query, blogTemplate);
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string query = "DELETE FROM BlogTemplates WHERE Id = @Id";
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
