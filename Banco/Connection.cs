using System;
using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
    public class Connection
    {
        private string connectionString = "Server=localhost,1433;Database=ScreenSound;User Id=sa;Password=78545632@Abc;Encrypt=False;";

        public SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }

        public IEnumerable<Artista> Listar()
        {
            var lista = new List<Artista>();
            using var connection = ObterConexao();
            connection.Open();

            string sql = "SELECT * FROM Artistas";
            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string nomeArtista = Convert.ToString(dataReader["Nome"]);
                string bioArtista = Convert.ToString(dataReader["Bio"]);
                int idArtista = Convert.ToInt32(dataReader["Id"]);
                Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };

                lista.Add(artista);
            }

            return lista;
        }
    }
}
