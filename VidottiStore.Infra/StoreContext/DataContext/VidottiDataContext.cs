using System;
using System.Data;
using System.Data.SqlClient;
using VidottiStore.Shared;

namespace VidottiStore.Infra.StoreContext.DataContext
{
    public class VidottiDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public VidottiDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}