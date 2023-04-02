using MySql.Data.MySqlClient;

namespace Inmobiliaria.Net.Models;

public class BdTipos
{
    String connectionString = "Server=localhost;User=root;Password=;Database=inmobiliaria.net;SslMode=none";

    public BdTipos()
    {

    }

   

    public List<Tipo> GetTipos()
    {

        List<Tipo> tipos = new List<Tipo>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT Id, Tipo from tipo";
            using (var command = new MySqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tipo tipo = new Tipo
                        {
                            Id = reader.GetInt32(0), // ID
                            TipoInm = reader.GetString(1), // DNI
                        
                            
                        };
                        tipos.Add(tipo);
                    }
                }

            }
            connection.Close();
        }
        return tipos;
    }

     
}

