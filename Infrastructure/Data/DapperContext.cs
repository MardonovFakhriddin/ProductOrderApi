using Npgsql;

namespace Infrastructure.Data;

public interface IContext
{
    NpgsqlConnection Connection();
}

public class DapperContext : IContext
{
    private readonly string connectionString =
        "Server=localhost; Port = 5432; Database = SimpleShop; User Id = postgres; Password = LMard1909;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}