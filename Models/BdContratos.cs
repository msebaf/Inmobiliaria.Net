using MySql.Data.MySqlClient;

namespace Inmobiliaria.Net.Models;

public class BdContratos
{
    String connectionString = "Server=localhost;User=root;Password=;Database=inmobiliaria.net;SslMode=none";

    public BdContratos()
    {

    }

    public int Alta(Contrato contrato)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"INSERT INTO contrato (InmuebleId, InquilinoId, FechaInicio, FechaFinal, MontoMensual)
        VALUES (@InmuebleId, @InquilinoId, @FechaInicio, @FechaFinal, @MontoMensual);
        SELECT LAST_INSERT_ID();";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InmuebleId", contrato.InmuebleId);
                command.Parameters.AddWithValue("@InquilinoId", contrato.InquilinoId);
                command.Parameters.AddWithValue("@FechaInicio", contrato.FechaInicio);
                command.Parameters.AddWithValue("@FechaFinal", contrato.FechaFinal);
                command.Parameters.AddWithValue("@MontoMensual", contrato.MontoMensual);
                

                connection.Open();
                res = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                contrato.Id = res;
            }
        }
        return res;
    }

     public int Actualizar(Contrato contrato)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"UPDATE contrato SET InmuebleId=@InmuebleId, InquilinoId=@InquilinoId, FechaInicio=@FechaInicio,
             FechaFinal=@FechaFinal, MontoMensual=@MontoMensual WHERE Id=@Id;";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", contrato.Id);
                command.Parameters.AddWithValue("@InmuebleId", contrato.InmuebleId);
                command.Parameters.AddWithValue("@InquilinoId", contrato.InquilinoId);
                command.Parameters.AddWithValue("@FechaInicio", contrato.FechaInicio);
                command.Parameters.AddWithValue("@FechaFinal", contrato.FechaFinal);
                command.Parameters.AddWithValue("@MontoMensual", contrato.MontoMensual);

                connection.Open();
                res = command.ExecuteNonQuery();
                connection.Close();
                
            }
        }
        return res;
    }

    public List<Contrato>GetContratos()
    {

        List<Contrato> Contratos = new List<Contrato>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT contrato.Id, contrato.InmuebleId, contrato.InquilinoId, contrato.FechaInicio, contrato.FechaFinal, contrato.MontoMensual
        from contrato ORDER BY FechaFinal DESC";
            using (var command = new MySqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contrato contrato = new Contrato
                        {
                            Id = reader.GetInt32(nameof(contrato.Id)), // ID
                            InmuebleId = reader.GetInt32(nameof(contrato.InmuebleId)),
                            InquilinoId = reader.GetInt32(nameof(contrato.InquilinoId)),
                            FechaInicio= reader.GetDateTime(nameof(contrato.FechaInicio)),
                            FechaFinal= reader.GetDateTime(nameof(contrato.FechaFinal)),
                            MontoMensual= reader.GetDouble(nameof(contrato.MontoMensual))
                            
                        };
                        Contratos.Add(contrato);
                    }
                }

            }
            connection.Close();
        }
        return Contratos;
    }

    public List<Contrato>GetContratosVigentes()
    {

        List<Contrato> Contratos = new List<Contrato>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT contrato.Id, contrato.InmuebleId, contrato.InquilinoId, contrato.FechaInicio, contrato.FechaFinal, contrato.MontoMensual
        from contrato WHERE YEAR(contrato.FechaFinal) >= YEAR(NOW()) AND  MONTH(contrato.FechaFinal) >= MONTH(NOW()) ORDER BY FechaFinal ASC";
            using (var command = new MySqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contrato contrato = new Contrato
                        {
                            Id = reader.GetInt32(nameof(contrato.Id)), // ID
                            InmuebleId = reader.GetInt32(nameof(contrato.InmuebleId)),
                            InquilinoId = reader.GetInt32(nameof(contrato.InquilinoId)),
                            FechaInicio= reader.GetDateTime(nameof(contrato.FechaInicio)),
                            FechaFinal= reader.GetDateTime(nameof(contrato.FechaFinal)),
                            MontoMensual= reader.GetDouble(nameof(contrato.MontoMensual))
                            
                        };
                        Contratos.Add(contrato);
                    }
                }

            }
            connection.Close();
        }
        return Contratos;
    }

     public Contrato GetContrato(int id)
    {

        Contrato contrato = null;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT Id, InmuebleId, InquilinoId, FechaInicio, FechaFinal, MontoMensual
        from contrato where Id = @id";
            using (var command = new MySqlCommand(query, connection))
           
            {
                 command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        contrato = new Contrato
                        {
                            Id = reader.GetInt32(nameof(contrato.Id)), // ID
                            InmuebleId = reader.GetInt32(nameof(contrato.InmuebleId)),
                            InquilinoId = reader.GetInt32(nameof(contrato.InquilinoId)),
                            FechaInicio= reader.GetDateTime(nameof(contrato.FechaInicio)),
                            FechaFinal= reader.GetDateTime(nameof(contrato.FechaFinal)),
                            MontoMensual= reader.GetDouble(nameof(contrato.MontoMensual))
                         
                            
                        };
                        
                    }
                }

            }
            connection.Close();
        }
        return contrato;
    }



     public int DeleteContrato(int id)
    {

       int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"Delete from contrato where Id = @id";
            using (var command = new MySqlCommand(query, connection))
           
            {
                 command.Parameters.AddWithValue("@id", id);
                connection.Open();
                res = command.ExecuteNonQuery();
            connection.Close();
        }
        
    }
    return res;
    }
}

