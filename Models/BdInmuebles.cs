using MySql.Data.MySqlClient;

namespace Inmobiliaria.Net.Models;

public class BdInmuebles
{
    String connectionString = "Server=localhost;User=root;Password=;Database=inmobiliaria.net;SslMode=none";

    public BdInmuebles()
    {

    }

    public int Alta(Inmueble inmueble)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"INSERT INTO inmueble (Direccion, Uso, Tipo, CantidadDeAmbientes, Latitud, Longitud, Precio, 
            Superficie, PropietarioId, Disponible)
        VALUES (@Direccion, @Uso, @Tipo, @CantidadDeAmbientes, @Latitud, @Longitud, @Precio, @Superficie, @PropietarioId, @Disponible);
        SELECT LAST_INSERT_ID();";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Direccion", inmueble.Direccion);
                command.Parameters.AddWithValue("@Uso", inmueble.Uso);
                command.Parameters.AddWithValue("@Tipo", inmueble.Tipo);
                command.Parameters.AddWithValue("@CantidadDeAmbientes", inmueble.CantidadDeAmbientes);
                command.Parameters.AddWithValue("@Latitud", inmueble.Latitud);
                command.Parameters.AddWithValue("@Longitud", inmueble.Longitud);
                command.Parameters.AddWithValue("@Precio", inmueble.Precio);
                command.Parameters.AddWithValue("@Superficie", inmueble.Superficie);
                command.Parameters.AddWithValue("@PropietarioId", inmueble.PropietarioId);
                command.Parameters.AddWithValue("@Disponible", inmueble.Disponible);

                connection.Open();
                res = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                inmueble.Id = res;
            }
        }
        return res;
    }

     public int Actualizar(Inmueble inmueble)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"UPDATE inmueble SET Direccion = @Direccion, Uso = @Uso, Tipo = @Tipo, 
            CantidadDeAmbientes = @CantidadDeAmbientes, Latitud = @Latitud, Longitud = @Longitud, 
            Precio = @Precio, Superficie = @Superficie, PropietarioId = @PropietarioId, Disponible = @Disponible WHERE Id = @Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", inmueble.Id);
                command.Parameters.AddWithValue("@Direccion", inmueble.Direccion);
                command.Parameters.AddWithValue("@Uso", inmueble.Uso);
                command.Parameters.AddWithValue("@Tipo", inmueble.Tipo);
                command.Parameters.AddWithValue("@CantidadDeAmbientes", inmueble.CantidadDeAmbientes);
                command.Parameters.AddWithValue("@Latitud", inmueble.Latitud);
                command.Parameters.AddWithValue("@Longitud", inmueble.Longitud);
                command.Parameters.AddWithValue("@Precio", inmueble.Precio);
                command.Parameters.AddWithValue("@Superficie", inmueble.Superficie);
                command.Parameters.AddWithValue("@PropietarioId", inmueble.PropietarioId);
                command.Parameters.AddWithValue("@Disponible", inmueble.Disponible);
               

                connection.Open();
                res = command.ExecuteNonQuery();
                connection.Close();
                
            }
        }
        return res;
    }

    public List<Inmueble>Getinmuebles(int? id)
    {
        List<Inmueble> inmuebles = new List<Inmueble>();
        if(id == null){

        

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT i.Id, i.Direccion, i.Tipo, i.Uso, i.CantidadDeAmbientes, i.Superficie, i.Precio, i.PropietarioId, i.Disponible,
             p.Dni, p.Nombre, p.Apellido, p.Telefono, p.Email FROM inmueble i JOIN Propietario p on 
             i.PropietarioId = p.Id  ";
            using (var command = new MySqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inmueble inmueble = new Inmueble
                        {
                            Id = reader.GetInt32(0), // ID
                            Direccion = reader.GetString(nameof(inmueble.Direccion)), // Direccion = reader.GetString("Direccion")
                            Tipo = reader.GetInt32(nameof(inmueble.Tipo)), // Tipo = reader.GetString("Tipo")
                            Uso = reader.GetInt32(nameof(inmueble.Uso)), // Uso = reader.GetString("Uso")
                            CantidadDeAmbientes = reader.GetInt32(nameof(inmueble.CantidadDeAmbientes)), // CantidadDeAmbientes = reader.GetInt32("CantidadDeAmbientes")
                            Superficie = reader.GetDecimal(nameof(inmueble.Superficie)), // Superficie = reader.GetDecimal("Superficie")
                            Precio = reader.GetDecimal(nameof(inmueble.Precio)), // Precio = reader.GetDecimal("Precio")
                            Duenio = new Propietario
                            {
                                Id = reader.GetInt32(7), // Id = reader.GetInt32("Id")
                                Dni = reader.GetString(9), // Dni = reader.GetInt32("Dni")
                                Nombre = reader.GetString(10), // Nombre = reader.GetString("Nombre")
                                Apellido = reader.GetString(11), // Apellido = reader.GetString("Apellido")
                                Telefono = reader.GetString(12), // Telefono = reader.GetString("Telefono")
                                Email = reader.GetString(13) // Email = reader.GetString("Email")
                            },
                            PropietarioId = reader.GetInt32(7), // PropietarioId = reader.GetInt32("PropietarioId")
                            Disponible = reader.GetBoolean(8)
                            
                        };
                        inmuebles.Add(inmueble);
                    }
                }

            }
            connection.Close();
        }
        }else{
            

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT i.Id, i.Direccion, i.Tipo, i.Uso, i.CantidadDeAmbientes, i.Superficie, i.Precio, i.PropietarioId, i.Disponible,
             p.Dni, p.Nombre, p.Apellido, p.Telefono, p.Email FROM inmueble i JOIN Propietario p on 
             i.PropietarioId = p.Id  where i.PropietarioId = @idProp";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@idProp", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inmueble inmueble = new Inmueble
                        {
                            Id = reader.GetInt32(0), // ID
                            Direccion = reader.GetString(nameof(inmueble.Direccion)), // Direccion = reader.GetString("Direccion")
                            Tipo = reader.GetInt32(nameof(inmueble.Tipo)), // Tipo = reader.GetString("Tipo")
                            Uso = reader.GetInt32(nameof(inmueble.Uso)), // Uso = reader.GetString("Uso")
                            CantidadDeAmbientes = reader.GetInt32(nameof(inmueble.CantidadDeAmbientes)), // CantidadDeAmbientes = reader.GetInt32("CantidadDeAmbientes")
                            Superficie = reader.GetDecimal(nameof(inmueble.Superficie)), // Superficie = reader.GetDecimal("Superficie")
                            Precio = reader.GetDecimal(nameof(inmueble.Precio)), // Precio = reader.GetDecimal("Precio")
                            Duenio = new Propietario
                            {
                                Id = reader.GetInt32(7), // Id = reader.GetInt32("Id")
                                Dni = reader.GetString(9), // Dni = reader.GetInt32("Dni")
                                Nombre = reader.GetString(10), // Nombre = reader.GetString("Nombre")
                                Apellido = reader.GetString(11), // Apellido = reader.GetString("Apellido")
                                Telefono = reader.GetString(12), // Telefono = reader.GetString("Telefono")
                                Email = reader.GetString(13) // Email = reader.GetString("Email")
                            },
                            PropietarioId = reader.GetInt32(7), // PropietarioId = reader.GetInt32("PropietarioId")
                            Disponible = reader.GetBoolean(8)
                            
                        };
                        inmuebles.Add(inmueble);
                    }
                }

            }
            connection.Close();
        }
        }
        return inmuebles;
    }

     public Inmueble Getinmueble(int id)
    {

        Inmueble inmueble = null;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT i.Direccion,Uso, Tipo, CantidadDeAmbientes, Latitud, Longitud, 
            Precio, Superficie, PropietarioId, p.Dni, p.Nombre, p.Apellido, p.Telefono, p.Email, p.Id, Disponible FROM inmueble i
            INNER JOIN propietario p ON i.PropietarioId = p.Id where i.Id = @id" ;
            using (var command = new MySqlCommand(query, connection))
           
            {
                 command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        inmueble = new Inmueble
                        {
                            Id = id, // ID
                            Direccion = reader.GetString(nameof(inmueble.Direccion)), // Direccion = reader.GetString("Direccion")
                            Uso = reader.GetInt32(nameof(inmueble.Uso)), // Uso = reader.GetString("Uso")
                            Tipo = reader.GetInt32(nameof(inmueble.Tipo)), // Tipo = reader.GetString("Tipo")
                            CantidadDeAmbientes = reader.GetInt32(nameof(
                             inmueble.CantidadDeAmbientes)), // CantidadDeAmbientes = reader.GetInt32("CantidadDeAmbientes")
                           
                            Latitud = reader.GetDecimal(nameof(inmueble.Latitud)), // Latitud = reader.GetDecimal("Latitud")
                            Longitud = reader.GetDecimal(nameof(inmueble.Longitud)), // Longitud = reader.GetDecimal("Longitud")
                            Precio = reader.GetDecimal(nameof(inmueble.Precio)), // Precio = reader.GetDecimal("Precio")
                            Superficie = reader.GetDecimal(nameof(inmueble.Superficie)), // Superficie = reader.GetDecimal("Superficie")
                            
                           
                            Duenio = new Propietario
                            {
                                Id = reader.GetInt32(14), // Id = reader.GetInt32("Id")
                                Dni = reader.GetString(nameof(Propietario.Dni)), // Dni = reader.GetString("Dni")
                                Nombre = reader.GetString(nameof(Propietario.Nombre)), // Nombre = reader.GetString("Nombre")
                                Apellido = reader.GetString(nameof(Propietario.Apellido)), // Apellido = reader.GetString("Apellido")
                                Telefono = reader.GetString(nameof(Propietario.Telefono)), // Telefono = reader.GetString("Telefono")
                                Email = reader.GetString(nameof(Propietario.Email)), // Email = reader.GetString("Email")
                            },
                             PropietarioId =reader.GetInt32(14), // PropietarioId = reader.GetInt32("PropietarioId")
                             Disponible = reader.GetBoolean(nameof(inmueble.Disponible))

                        };
                        
                    }
                }

            }
            connection.Close();
        }
        return inmueble;
    }



     public int DeleteInmueble(int id)
    {

       int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"Delete from inmueble where Id = @id";
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

    public void SacarM(int id){
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"UPDATE inmueble SET Disponible = 0 WHERE Id = @id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();

            }
        }
    }
    public void AgregarM(int id){
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"UPDATE inmueble SET Disponible = 1 WHERE Id = @id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();

            }
        }
    }



     
}

