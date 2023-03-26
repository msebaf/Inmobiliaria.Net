using MySql.Data.MySqlClient;

namespace Inmobiliaria.Net.Models;

public class BdPropietarios
{
    String connectionString = "Server=localhost;User=root;Password=;Database=inmobiliaria.net;SslMode=none";

    public BdPropietarios()
    {

    }

    public int Alta(Propietario propietario)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"INSERT INTO propietario (Nombre, Direccion, Telefono, Nacimiento, Apellido, Email, Dni)
        VALUES (@Nombre, @Direccion, @Telefono, @Nacimiento, @Apellido, @Email, @Dni);
        SELECT LAST_INSERT_ID();";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", propietario.Nombre);
                command.Parameters.AddWithValue("@Direccion", propietario.Direccion);
                command.Parameters.AddWithValue("@Telefono", propietario.Telefono);
                command.Parameters.AddWithValue("@Nacimiento", propietario.Nacimiento);
                command.Parameters.AddWithValue("@Apellido", propietario.Apellido);
                command.Parameters.AddWithValue("@Email", propietario.Email);
                command.Parameters.AddWithValue("@Dni", propietario.Dni);

                connection.Open();
                res = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                propietario.Id = res;
            }
        }
        return res;
    }

     public int Actualizar(Propietario propietario)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"UPDATE propietario SET Nombre=@Nombre, Direccion=@Direccion, Telefono=@Telefono,
             Nacimiento=@Nacimiento, Apellido=@Apellido, Email=@Email, Dni=@Dni WHERE Id=@Id;";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", propietario.Id);
                command.Parameters.AddWithValue("@Nombre", propietario.Nombre);
                command.Parameters.AddWithValue("@Direccion", propietario.Direccion);
                command.Parameters.AddWithValue("@Telefono", propietario.Telefono);
                command.Parameters.AddWithValue("@Nacimiento", propietario.Nacimiento);
                command.Parameters.AddWithValue("@Apellido", propietario.Apellido);
                command.Parameters.AddWithValue("@Email", propietario.Email);
                command.Parameters.AddWithValue("@Dni", propietario.Dni);

                connection.Open();
                res = command.ExecuteNonQuery();
                connection.Close();
                
            }
        }
        return res;
    }

    public List<Propietario>Getpropietarios()
    {

        List<Propietario> propietarios = new List<Propietario>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT Id, Nombre, Direccion, Telefono, Nacimiento, Apellido, Email, Dni
        from propietario";
            using (var command = new MySqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Propietario propietario = new Propietario
                        {
                            Id = reader.GetInt32(nameof(propietario.Id)), // ID
                            Dni = reader.GetString(nameof(propietario.Dni)), // DNI
                            Nombre = reader.GetString(nameof(propietario.Nombre)), // Nombre = reader.GetString("Nombre")
                            Apellido = reader.GetString(nameof(propietario.Apellido)), // Apellido = reader.GetString("Apellido")
                            Direccion = reader.GetString(nameof(propietario.Direccion)), // Direccion = reader.GetString("Direccion")
                            Telefono = reader.GetString(nameof(propietario.Telefono)), // Telefono = reader.GetString("Telefono")   
                            Email = reader.GetString(nameof(propietario.Email)), // Email = reader.GetString("Email")
                            Nacimiento = reader.GetDateTime(nameof(propietario.Nacimiento))
                            
                        };
                        propietarios.Add(propietario);
                    }
                }

            }
            connection.Close();
        }
        return propietarios;
    }

     public Propietario Getpropietario(int id)
    {

        Propietario propietario = null;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT Id, Nombre, Direccion, Telefono, Nacimiento, Apellido, Email, Dni
        from propietario where Id = @id";
            using (var command = new MySqlCommand(query, connection))
           
            {
                 command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        propietario = new Propietario
                        {
                            Id = reader.GetInt32(nameof(propietario.Id)), // ID
                            Dni = reader.GetString(nameof(propietario.Dni)), // DNI
                            Nombre = reader.GetString(nameof(propietario.Nombre)), // Nombre = reader.GetString("Nombre")
                            Apellido = reader.GetString(nameof(propietario.Apellido)), // Apellido = reader.GetString("Apellido")
                            Direccion = reader.GetString(nameof(propietario.Direccion)), // Direccion = reader.GetString("Direccion")
                            Telefono = reader.GetString(nameof(propietario.Telefono)), // Telefono = reader.GetString("Telefono")   
                            Email = reader.GetString(nameof(propietario.Email)), // Email = reader.GetString("Email")
                            Nacimiento = reader.GetDateTime(nameof(propietario.Nacimiento))
                            
                        };
                        
                    }
                }

            }
            connection.Close();
        }
        return propietario;
    }



     public int DeletePropietario(int id)
    {

       int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"Delete from propietario where Id = @id";
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

