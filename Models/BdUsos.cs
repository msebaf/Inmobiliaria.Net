using MySql.Data.MySqlClient;

namespace Inmobiliaria.Net.Models;

public class BdUsos
{
    String connectionString = "Server=localhost;User=root;Password=;Database=inmobiliaria.net;SslMode=none";

    public BdUsos()
    {

    }

   

    public List<Uso> GetUsos()
    {

        List<Uso> usos = new List<Uso>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT Id, Uso from uso";
            using (var command = new MySqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Uso uso = new Uso
                        {
                            Id = reader.GetInt32(0), // ID
                            UsoInm = reader.GetString(1), // DNI
                        
                            
                        };
                        usos.Add(uso);
                    }
                }

            }
            connection.Close();
        }
        return usos;
    }

     
}

