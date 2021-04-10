using System.Data;
using System.Data.SqlClient;
using MosquitoLab.Domain.Persistence.Context;

namespace MosquitoLab.Infra.Persistence.Context
{
    public class DbContext : IDbContext
    {

        private IDbConnection _connection;

        public void Dispose()
        {
            this.Connection?.Close();
        }

        public IDbConnection Connection
        {

            get
            {

                if (_connection == null)
                    _connection = new SqlConnection(Connections.DbConnection);

                //if (_connection?.State != ConnectionState.Open)
                //    _connection?.Open();

                return _connection;

            }

        }
    }
}
