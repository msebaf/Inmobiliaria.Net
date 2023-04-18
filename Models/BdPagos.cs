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
            var query = @"INSERT INTO pago (ContratoId, Monto, FechaPago, Periodo)
        VALUES (@ContratoId, @Monto, @FechaPago, @Periodo);
        SELECT LAST_INSERT_ID();";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ContratoId", pago.ContratoId);
                command.Parameters.AddWithValue("@Monto", pago.Monto);
                command.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                command.Parameters.AddWithValue("@Periodo", pago.Periodo);
                

                connection.Open();
                res = command.ExecuteNonQuery();
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
            var query = @"UPDATE pago SET ContratoId=@ContratoId, Monto=@Monto, FechaPago=@FechaPago, Periodo=@Periodo WHERE Id=@Id;";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", pago.Id);
                command.Parameters.AddWithValue("@ContratoId", pago.ContratoId);
                command.Parameters.AddWithValue("@Monto", pago.Monto);
                command.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                command.Parameters.AddWithValue("@Periodo", pago.Periodo);

                connection.Open();
                res = command.ExecuteNonQuery();
                connection.Close();
                
            }
        }
        return res;
    }

    public List<Pago>GetPagos(int? id)
    
    {
        List<Pago> pagos = new List<Pago>();
        if(id != null){
       

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT Id,  Monto, FechaPago, Periodo FROM pago WHERE ContratoId=@id;";
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
                            Id = reader.GetInt32("Id"),
                            ContratoId = id,
                            Monto = reader.GetDouble("Monto"),
                            FechaPago = reader.GetDateTime("FechaPago"),
                            Periodo = reader.GetDateTime("Periodo")
                            
                        };
                        pagos.Add(pago);
                    }
                }

            }
            connection.Close();
        }}else{
            

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT Id,  Monto, FechaPago, Periodo, ContratoId FROM pago ;";
            using (var command = new MySqlCommand(query, connection))
            {
                 
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pago pago = new Pago
                        {
                            Id = reader.GetInt32("Id"),
                            ContratoId = reader.GetInt32("ContratoId"),
                            Monto = reader.GetDouble("Monto"),
                            FechaPago = reader.GetDateTime("FechaPago"),
                            Periodo = reader.GetDateTime("Periodo")
                            
                        };
                        pagos.Add(pago);
                    }
                }

            }
            connection.Close();
        }
        }
        return pagos;
    }
    

   

    

     public Pago GetPago(int id)
    {

        Pago pago = null;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT Id, ContratoId, Monto, FechaPago, Periodo FROM pago WHERE Id=@id;";
            using (var command = new MySqlCommand(query, connection))
           
            {
                 command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pago = new Pago
                        {
                           Id = reader.GetInt32("Id"),
                            ContratoId = reader.GetInt32("ContratoId"),
                            Monto = reader.GetDouble("Monto"),
                            FechaPago = reader.GetDateTime("FechaPago"),
                            Periodo = reader.GetDateTime("Periodo")
                            
                        };
                        
                    }
                }

            }
            connection.Close();
        }
        return pago;
    }


    
    
     public int DeletePago(int id)
    {

       int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"Delete from pago where Id = @id";
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


