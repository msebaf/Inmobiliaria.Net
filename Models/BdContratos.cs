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
            var query = @"SELECT c.Id, c.InmuebleId, c.InquilinoId, c.FechaInicio, c.FechaFinal, c.MontoMensual, i.Id, 
i.Direccion, i.Uso, i.Disponible, inq.Dni, inq.Nombre, inq.Apellido
        from contrato c  JOIN inmueble i on c.InmuebleId = i.Id JOIN inquilino inq on inq.Id = c.InquilinoId ORDER BY c.FechaFinal DESC";
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
                            MontoMensual= reader.GetDouble(nameof(contrato.MontoMensual)),
                            inmueble = new Inmueble
                            {
                                Id = reader.GetInt32(nameof(contrato.InmuebleId)),
                                Direccion = reader.GetString(nameof(contrato.inmueble.Direccion)),
                                Uso = reader.GetInt32(nameof(contrato.inmueble.Uso)),
                                Disponible = reader.GetBoolean(nameof(contrato.inmueble.Disponible))
                            },
                            inquilino = new Inquilino
                            {
                                Id = reader.GetInt32(nameof(contrato.InquilinoId)),
                                Dni = reader.GetString(nameof(contrato.inquilino.Dni)),
                                Nombre = reader.GetString(nameof(contrato.inquilino.Nombre)),
                                Apellido = reader.GetString(nameof(contrato.inquilino.Apellido))
                            }
                            
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
            var query = @"SELECT c.Id, c.InmuebleId, c.InquilinoId, c.FechaInicio, c.FechaFinal, c.MontoMensual, i.Id, 
i.Direccion, i.Uso, i.Disponible, inq.Dni, inq.Nombre, inq.Apellido
        from contrato c  JOIN inmueble i on c.InmuebleId = i.Id JOIN inquilino inq on inq.Id = c.InquilinoId WHERE c.FechaFinal >= NOW() ORDER BY c.FechaFinal ASC";
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
                            MontoMensual= reader.GetDouble(nameof(contrato.MontoMensual)),
                            inmueble = new Inmueble
                            {
                                Id = reader.GetInt32(nameof(contrato.InmuebleId)),
                                Direccion = reader.GetString(nameof(contrato.inmueble.Direccion)),
                                Uso = reader.GetInt32(nameof(contrato.inmueble.Uso)),
                                Disponible = reader.GetBoolean(nameof(contrato.inmueble.Disponible))
                            },
                            inquilino = new Inquilino
                            {
                                Id = reader.GetInt32(nameof(contrato.InquilinoId)),
                                Dni = reader.GetString(nameof(contrato.inquilino.Dni)),
                                Nombre = reader.GetString(nameof(contrato.inquilino.Nombre)),
                                Apellido = reader.GetString(nameof(contrato.inquilino.Apellido))
                            }
                            
                        };
                        Contratos.Add(contrato);
                    }
                }

            }
            connection.Close();
        }
        return Contratos;
    }

     public List<Contrato>GetContratosVencidos()
    {

        List<Contrato> Contratos = new List<Contrato>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT c.Id, c.InmuebleId, c.InquilinoId, c.FechaInicio, c.FechaFinal, c.MontoMensual, i.Id, 
i.Direccion, i.Uso, i.Disponible, inq.Dni, inq.Nombre, inq.Apellido
        from contrato c  JOIN inmueble i on c.InmuebleId = i.Id JOIN inquilino inq on inq.Id = c.InquilinoId WHERE YEAR(c.FechaFinal) <= YEAR(NOW()) AND  MONTH(c.FechaFinal) <= MONTH(NOW()) AND DAY(c.FechaFinal) < DAY(NOW()) ORDER BY FechaFinal ASC";
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
                            MontoMensual= reader.GetDouble(nameof(contrato.MontoMensual)),
                            inmueble = new Inmueble
                            {
                                Id = reader.GetInt32(nameof(contrato.InmuebleId)),
                                Direccion = reader.GetString(nameof(contrato.inmueble.Direccion)),
                                Uso = reader.GetInt32(nameof(contrato.inmueble.Uso)),
                                Disponible = reader.GetBoolean(nameof(contrato.inmueble.Disponible))
                            },
                            inquilino = new Inquilino
                            {
                                Id = reader.GetInt32(nameof(contrato.InquilinoId)),
                                Dni = reader.GetString(nameof(contrato.inquilino.Dni)),
                                Nombre = reader.GetString(nameof(contrato.inquilino.Nombre)),
                                Apellido = reader.GetString(nameof(contrato.inquilino.Apellido))
                            }
                            
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
            var query = @"SELECT c.Id, c.InmuebleId, c.InquilinoId, c.FechaInicio, c.FechaFinal, c.MontoMensual, 
i.Direccion, i.Uso, i.Disponible, inq.Dni, inq.Nombre, inq.Apellido
        from contrato c  JOIN inmueble i on c.InmuebleId = i.Id JOIN inquilino inq on inq.Id = c.InquilinoId where c.Id = @id";
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
                            MontoMensual= reader.GetDouble(nameof(contrato.MontoMensual)),
                            inmueble = new Inmueble
                            {
                                Id = reader.GetInt32(nameof(contrato.InmuebleId)),
                                Direccion = reader.GetString(nameof(contrato.inmueble.Direccion)),
                                Uso = reader.GetInt32(nameof(contrato.inmueble.Uso)),
                                Disponible = reader.GetBoolean(nameof(contrato.inmueble.Disponible))
                            },
                            inquilino = new Inquilino
                            {
                                Id = reader.GetInt32(nameof(contrato.InquilinoId)),
                                Dni = reader.GetString(nameof(contrato.inquilino.Dni)),
                                Nombre = reader.GetString(nameof(contrato.inquilino.Nombre)),
                                Apellido = reader.GetString(nameof(contrato.inquilino.Apellido))
                            }
                         
                            
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



  public int GetContratoEditarValidador(DateTime? inicio, DateTime? final, int? inmId, int? contratoId)
{
    int count = 0;
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        var query = @"SELECT COUNT(*) FROM contrato 
WHERE InmuebleId = @inmId AND (contrato.Id != @contratoId) AND ((@FechaInicio BETWEEN contrato.FechaInicio AND contrato.FechaFinal) OR (@FechaFinal BETWEEN contrato.FechaInicio AND contrato.FechaFinal))"; 
        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@inmId", inmId);
            command.Parameters.AddWithValue("@FechaInicio", inicio);
            command.Parameters.AddWithValue("@FechaFinal", final);
            command.Parameters.AddWithValue("@contratoId", contratoId);
            connection.Open();
            count = Convert.ToInt32(command.ExecuteScalar());
        }
    }
    return count;
}

public int GetContratoCrearValidador(DateTime? inicio, DateTime? final, int? inmId)
{
    int count = 0;
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        var query = @"SELECT COUNT(*) FROM contrato 
WHERE InmuebleId = @inmId  AND ((@FechaInicio BETWEEN contrato.FechaInicio AND contrato.FechaFinal) OR (@FechaFinal BETWEEN contrato.FechaInicio AND contrato.FechaFinal))"; 
        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@inmId", inmId);
            command.Parameters.AddWithValue("@FechaInicio", inicio);
            command.Parameters.AddWithValue("@FechaFinal", final);
            
            connection.Open();
            count = Convert.ToInt32(command.ExecuteScalar());
        }
    }
    return count;
}
}

