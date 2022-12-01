using System;
using Microsoft.Data.SqlClient;

namespace api.handlers
{
    public abstract class DBHandler
    {
        public static string GetConnectionString()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.TrustServerCertificate = true;
                builder.DataSource = "diplomajoy.database.windows.net";
                builder.UserID = "joy";
                builder.Password = "PlayerHater22!";
                builder.InitialCatalog = "diplomaplaya";
                return builder.ConnectionString;
            }
            catch (Exception e)
            {
                throw new Exception("Error in GetConnectionString(): " + e.Message);
            }
        }
    }
}
