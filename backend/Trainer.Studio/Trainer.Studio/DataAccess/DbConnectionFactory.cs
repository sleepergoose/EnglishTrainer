using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Trainer.Studio.DataAccess
{
    public class DbConnectionFactory
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("TrainerDbConnection");
        }

        public IDbConnection GetConnection()
        {
            if (_sqlConnection == null)
                _sqlConnection = new SqlConnection(_connectionString);

            return _sqlConnection;
        }
    }
}
