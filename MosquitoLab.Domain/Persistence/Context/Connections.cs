using System.Configuration;

namespace MosquitoLab.Domain.Persistence.Context
{
    public static class Connections
    {
        public static string DbConnection => ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
    }
}
