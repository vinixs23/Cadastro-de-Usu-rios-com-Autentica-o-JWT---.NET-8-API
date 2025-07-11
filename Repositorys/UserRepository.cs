using System.Data.SqlClient;
using CadastroDeUsuario.Models;
using Dapper;

public class UserRepository
{
    private readonly string _connectionString;

    public UserRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<User> GetByEmail(string email)
    {
        using var conn = new SqlConnection(_connectionString);
        var sql = "SELECT * FROM Users WHERE Email = @Email";
        return await conn.QueryFirstOrDefaultAsync<User>(sql, new { Email = email });
    }

    public async Task<User> GetById(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        var sql = "SELECT * FROM Users WHERE Id = @Id";
        return await conn.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
    }

    public async Task<int> Create(User user)
    {
        using var conn = new SqlConnection(_connectionString);
        var sql = @"INSERT INTO Users (Nome, Email, SenhaHash, DataCriacao)
                    VALUES (@Nome, @Email, @SenhaHash, @DataCriacao);
                    SELECT CAST(SCOPE_IDENTITY() as int)";
        return await conn.ExecuteScalarAsync<int>(sql, user);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        using var conn = new SqlConnection(_connectionString);
        var sql = "SELECT * FROM Users";
        return await conn.QueryAsync<User>(sql);
    }

    public async Task Update(User user)
    {
        using var conn = new SqlConnection(_connectionString);
        var sql = @"UPDATE Users SET Nome = @Nome, Email = @Email WHERE Id = @Id";
        await conn.ExecuteAsync(sql, user);
    }

    public async Task Delete(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        var sql = "DELETE FROM Users WHERE Id = @Id";
        await conn.ExecuteAsync(sql, new { Id = id });
    }
}