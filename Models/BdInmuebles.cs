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


    public List<Inmueble> GetInmueblesDisp()
{
    List<Inmueble> inmuebles = new List<Inmueble>();

    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        var query = @"SELECT i.Id, i.Direccion, i.Tipo, i.Uso, i.CantidadDeAmbientes, i.Superficie, i.Precio, i.PropietarioId, i.Disponible,
                      p.Dni, p.Nombre, p.Apellido, p.Telefono, p.Email 
                      FROM inmueble i 
                      JOIN Propietario p on i.PropietarioId = p.Id  
                      WHERE i.Disponible = true";
                      
        using (var command = new MySqlCommand(query, connection))
        {
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Inmueble inmueble = new Inmueble
                    {
                        Id = reader.GetInt32(0),
                        Direccion = reader.GetString(nameof(inmueble.Direccion)), 
                        Tipo = reader.GetInt32(nameof(inmueble.Tipo)), 
                        Uso = reader.GetInt32(nameof(inmueble.Uso)), 
                        CantidadDeAmbientes = reader.GetInt32(nameof(inmueble.CantidadDeAmbientes)), 
                        Superficie = reader.GetDecimal(nameof(inmueble.Superficie)), 
                        Precio = reader.GetDecimal(nameof(inmueble.Precio)),
                        Duenio = new Propietario
                        {
                            Id = reader.GetInt32(7), 
                            Dni = reader.GetString(9), 
                            Nombre = reader.GetString(10),
                            Apellido = reader.GetString(11), 
                            Telefono = reader.GetString(12), 
                            Email = reader.GetString(13) 
                        },
                        PropietarioId = reader.GetInt32(7), 
                        Disponible = reader.GetBoolean(8) 
                    };
                    inmuebles.Add(inmueble);
                }
            }
        }
        connection.Close();
    }

    return inmuebles;
}





public List<Inmueble> GetInmueblesDisponibles(DateTime inicio, DateTime final)
{
    Console.WriteLine(inicio);
    Console.WriteLine(final);
    List<Inmueble> inmueblesDisponibles = new List<Inmueble>();

    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        // Primero, obtén los inmuebles disponibles
        var queryInmuebles = @"
            SELECT 
                i.Id, i.Direccion, i.Tipo, i.Uso, i.CantidadDeAmbientes, i.Superficie, i.Precio, i.PropietarioId, i.Disponible,
                p.Dni, p.Nombre, p.Apellido, p.Telefono, p.Email 
            FROM 
                inmueble i 
            JOIN 
                Propietario p 
            ON 
                i.PropietarioId = p.Id
            WHERE 
                i.Disponible = true";
        
        connection.Open();
        using (var commandInmuebles = new MySqlCommand(queryInmuebles, connection))
        {
            using (var readerInmuebles = commandInmuebles.ExecuteReader())
            {
                List<Inmueble> inmueblesTemp = new List<Inmueble>();

                while (readerInmuebles.Read())
                {
                    Inmueble inmueble = new Inmueble
                    {
                        Id = readerInmuebles.GetInt32(0),
                        Direccion = readerInmuebles.GetString(1),
                        Tipo = readerInmuebles.GetInt32(2),
                        Uso = readerInmuebles.GetInt32(3),
                        CantidadDeAmbientes = readerInmuebles.GetInt32(4),
                        Superficie = readerInmuebles.GetDecimal(5),
                        Precio = readerInmuebles.GetDecimal(6),
                        PropietarioId = readerInmuebles.GetInt32(7),
                        Disponible = readerInmuebles.GetBoolean(8),
                        Duenio = new Propietario
                        {
                            Dni = readerInmuebles.GetString(9),
                            Nombre = readerInmuebles.GetString(10),
                            Apellido = readerInmuebles.GetString(11),
                            Telefono = readerInmuebles.GetString(12),
                            Email = readerInmuebles.GetString(13)
                        }
                    };

                    inmueblesTemp.Add(inmueble);
                }

                readerInmuebles.Close(); // Cierra el primer reader antes de abrir el siguiente
                    Console.WriteLine(inmueblesTemp);
                // Para cada inmueble, verifica los contratos asociados
                var queryContratos = @"
                    SELECT 
                        c.FechaInicio, c.FechaFinal
                    FROM 
                        contrato c
                    WHERE 
                        c.InmuebleId = @InmuebleId
                    AND 
                        c.FechaFinal >= NOW()"; // Considerar solo contratos actuales o futuros

                foreach (var inmueble in inmueblesTemp)
                {
                    using (var commandContratos = new MySqlCommand(queryContratos, connection))
                    {
                        commandContratos.Parameters.AddWithValue("@InmuebleId", inmueble.Id);

                        bool hasConflict = false; // Asume que no hay conflicto inicialmente

                        using (var readerContratos = commandContratos.ExecuteReader())
                        {
                            while (readerContratos.Read())
                            {
                                DateTime contratoInicio = readerContratos.GetDateTime(0);
                                DateTime contratoFinal = readerContratos.GetDateTime(1);
                                Console.WriteLine(contratoInicio);
                                Console.WriteLine(contratoFinal);

                                // Verifica si las fechas del contrato entran en conflicto con las fechas proporcionadas
                                if ((inicio >= contratoInicio && inicio <= contratoFinal) || 
                                         (final >= contratoInicio && final <= contratoFinal))
                                    {
                                        hasConflict = true;
                                        break;
                                    }
                                                                }
                        }

                        // Si no hubo conflicto, agrega el inmueble a la lista de disponibles
                        if (!hasConflict)
                        {
                            inmueblesDisponibles.Add(inmueble);
                        }
                    }
                }
            }
        }
    }
    Console.WriteLine(inmueblesDisponibles);
    return inmueblesDisponibles;
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

