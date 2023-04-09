using MySql.Data.MySqlClient;

namespace Inmobiliaria.Net.Models;

public class BdPagos
{
    String connectionString = "Server=localhost;User=root;Password=;Database=inmobiliaria.net;SslMode=none";

    public BdPagos()
    {

    }

    public int Alta(Pago pago)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"INSERT INTO pago (contratoId, FechaPago, Monto, MesPagado);
        SELECT LAST_INSERT_ID();";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@contratoId", pago.ContratoId);
                command.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                command.Parameters.AddWithValue("@Monto", pago.Monto);
                command.Parameters.AddWithValue("@MesPagado", pago.MesPagado);
                

                connection.Open();
                res = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                pago.Id = res;
            }
        }
        return res;
    }

     public int Actualizar(Pago pago)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"UPDATE pago SET contratoId=@contratoId, FechaPago=@FechaPago, Monto=@Monto, MesPagado=@MesPagado WHERE Id=@Id;";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", pago.Id);
                command.Parameters.AddWithValue("@contratoId", pago.ContratoId);
                command.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                command.Parameters.AddWithValue("@Monto", pago.Monto);
                command.Parameters.AddWithValue("@MesPagado", pago.MesPagado);

                connection.Open();
                res = command.ExecuteNonQuery();
                connection.Close();
                
            }
        }
        return res;
    }

    public List<Pago>GetPagos(int id)
    {

        List<Pago> Pagos = new List<Pago>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT pago.Id, pago.contratoId, pago.FechaPago, pago.Monto, pago.MesPagado 
            FROM pago where contratoId=@id;";
            using (var command = new MySqlCommand(query, connection))
            {
                 command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pago pago = new Pago
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            ContratoId = Convert.ToInt32(reader["contratoId"]),
                            FechaPago = Convert.ToDateTime(reader["FechaPago"]),
                            Monto = Convert.ToDouble(reader["Monto"]),
                            MesPagado = Convert.ToDateTime(reader["MesPagado"])
                            
                        };
                        Pagos.Add(pago);
                    }
                }

            }
            connection.Close();
        }
        return Pagos;
    }

public Pago GetPago(int id)
    {

        Pago pago = null;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT Id, contratoId, FechaPago, MontoMensual, MesPagado FROM pago WHERE Id=@id;";
            using (var command = new MySqlCommand(query, connection))
           
            {
                 command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pago = new Pago
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            ContratoId = Convert.ToInt32(reader["contratoId"]),
                            FechaPago = Convert.ToDateTime(reader["FechaPago"]),
                            Monto = Convert.ToDouble(reader["MontoMensual"]),
                            MesPagado = Convert.ToDateTime(reader["MesPagado"])
                        
                         
                            
                        };
                        
                    }
                }

            }
            connection.Close();
        }
        return pago;
    }
   

    



 
}

