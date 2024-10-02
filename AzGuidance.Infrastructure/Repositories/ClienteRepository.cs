using AzGuidance.Domain.Entities;
using AzGuidance.Domain.Interfaces;
using System.Data.SqlClient;

namespace AzGuidance.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly string _connectionString;

    public ClienteRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Cliente> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var query = "SELECT * FROM Clientes WHERE ClienteID = @ClienteID";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ClienteID", id);

        using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new Cliente
            {
                ClienteID = (int)reader["ClienteID"],
                Nome = (string)reader["Nome"],
                Email = (string)reader["Email"],
                Permitido = (bool)reader["Permitido"],
                TipoEmailID = (int)reader["TipoEmailID"],
                EnviarParaID = (int)reader["EnviarParaID"],
                FormaEnvioID = (int)reader["FormaEnvioID"]
            };
        }
        return null;
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        var clientes = new List<Cliente>();
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var query = "SELECT * FROM Clientes";
        using var command = new SqlCommand(query, connection);
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            clientes.Add(new Cliente
            {
                ClienteID = (int)reader["ClienteID"],
                Nome = (string)reader["Nome"],
                Email = (string)reader["Email"],
                Permitido = (bool)reader["Permitido"],
                TipoEmailID = (int)reader["TipoEmailID"],
                EnviarParaID = (int)reader["EnviarParaID"],
                FormaEnvioID = (int)reader["FormaEnvioID"]
            });
        }
        return clientes;
    }

    public async Task AddAsync(Cliente entity)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var query = "INSERT INTO Clientes (Nome, Email, Permitido, TipoEmailID, EnviarParaID, FormaEnvioID) " +
                    "VALUES (@Nome, @Email, @Permitido, @TipoEmailID, @EnviarParaID, @FormaEnvioID)";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Nome", entity.Nome);
        command.Parameters.AddWithValue("@Email", entity.Email);
        command.Parameters.AddWithValue("@Permitido", entity.Permitido);
        command.Parameters.AddWithValue("@TipoEmailID", entity.TipoEmailID);
        command.Parameters.AddWithValue("@EnviarParaID", entity.EnviarParaID);
        command.Parameters.AddWithValue("@FormaEnvioID", entity.FormaEnvioID);

        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(Cliente entity)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var query = "UPDATE Clientes SET Nome = @Nome, Email = @Email, Permitido = @Permitido, " +
                    "TipoEmailID = @TipoEmailID, EnviarParaID = @EnviarParaID, FormaEnvioID = @FormaEnvioID " +
                    "WHERE ClienteID = @ClienteID";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ClienteID", entity.ClienteID);
        command.Parameters.AddWithValue("@Nome", entity.Nome);
        command.Parameters.AddWithValue("@Email", entity.Email);
        command.Parameters.AddWithValue("@Permitido", entity.Permitido);
        command.Parameters.AddWithValue("@TipoEmailID", entity.TipoEmailID);
        command.Parameters.AddWithValue("@EnviarParaID", entity.EnviarParaID);
        command.Parameters.AddWithValue("@FormaEnvioID", entity.FormaEnvioID);

        await command.ExecuteNonQueryAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var query = "DELETE FROM Clientes WHERE ClienteID = @ClienteID";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ClienteID", id);

        await command.ExecuteNonQueryAsync();
    }
}
