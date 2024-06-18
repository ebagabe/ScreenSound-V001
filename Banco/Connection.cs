using System;
using Microsoft.Data.SqlClient;

namespace ScreenSound.Banco
{
    public class Connection
    {
        private string connectionString = "Server=localhost,1433;Database=ScreenSound;User Id=sa;Password=78545632@Abc;Encrypt=False;";

        public SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }
    }
}
