using Microsoft.Data.SqlClient;

namespace OnlineStore.Data.Repositories.Implementations
{
    public class BaseRepository
    {
        private static readonly string DEFAULT_CONNECTION_STRING = "Default";

        private readonly string _databaseConnectionString;

        public BaseRepository(IConfiguration configuration)
        {
            string? defaultConnectionString = configuration.GetConnectionString(DEFAULT_CONNECTION_STRING);

            if (defaultConnectionString == null)
                throw new MissingFieldException("Failed to get access to default connection string");

            _databaseConnectionString = defaultConnectionString;
        }

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_databaseConnectionString);
        }
    }
}
