using System.Data.SqlClient;
using YourProject.Infrastructure.Data;

public class DatabaseInitializer
{
    private readonly DatabaseConnection _databaseConnection;

    public DatabaseInitializer(DatabaseConnection databaseConnection)
    {
        _databaseConnection = databaseConnection;
    }

    public async Task InitializeAsync()
    {
        using (var connection = _databaseConnection.CreateConnection())
        {
            await connection.OpenAsync();

            var createTableScript = await File.ReadAllTextAsync("Infrastructure/Data/Scripts/CreateTables.sql");

            using (var command = new SqlCommand(createTableScript, connection))
            {
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
