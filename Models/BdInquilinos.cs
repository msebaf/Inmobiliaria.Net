using MySql.Data.MySqlClient;

namespace Inmobiliaria.Net.Models;

public class BdInquilinos
{
    String connectionString = "Server=localhost;User=root;Password=;Database=inmobiliaria.net;SslMode=none";

    public BdInquilinos()
    {

    }

    public int Alta(Inquilino inquilino)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"INSERT INTO inquilino (Nombre, Direccion, Telefono, Nacimiento, Apellido, Email, Dni)
        VALUES (@Nombre, @Direccion, @Telefono, @Nacimiento, @Apellido, @Email, @Dni);
        SELECT LAST_INSERT_ID();";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", inquilino.Nombre);
                command.Parameters.AddWithValue("@Direccion", inquilino.Direccion);
                command.Parameters.AddWithValue("@Telefono", inquilino.Telefono);
                command.Parameters.AddWithValue("@Nacimiento", inquilino.Nacimiento);
                command.Parameters.AddWithValue("@Apellido", inquilino.Apellido);
                command.Parameters.AddWithValue("@Email", inquilino.Email);
                command.Parameters.AddWithValue("@Dni", inquilino.Dni);

                connection.Open();
                res = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                inquilino.Id = res;
            }
        }
        return res;
    }

     public int Actualizar(Inquilino inquilino)
    {
        int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"UPDATE inquilino SET Nombre=@Nombre, Direccion=@Direccion, Telefono=@Telefono,
             Nacimiento=@Nacimiento, Apellido=@Apellido, Email=@Email, Dni=@Dni WHERE Id=@Id;";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", inquilino.Id);
                command.Parameters.AddWithValue("@Nombre", inquilino.Nombre);
                command.Parameters.AddWithValue("@Direccion", inquilino.Direccion);
                command.Parameters.AddWithValue("@Telefono", inquilino.Telefono);
                command.Parameters.AddWithValue("@Nacimiento", inquilino.Nacimiento);
                command.Parameters.AddWithValue("@Apellido", inquilino.Apellido);
                command.Parameters.AddWithValue("@Email", inquilino.Email);
                command.Parameters.AddWithValue("@Dni", inquilino.Dni);

                connection.Open();
                res = command.ExecuteNonQuery();
                connection.Close();
                
            }
        }
        return res;
    }

    public List<Inquilino>Getinquilinos()
    {

        List<Inquilino> inquilinos = new List<Inquilino>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT Id, Nombre, Direccion, Telefono, Nacimiento, Apellido, Email, Dni
        from inquilino";
            using (var command = new MySqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inquilino inquilino = new Inquilino
                        {
                            Id = reader.GetInt32(nameof(inquilino.Id)), // ID
                            Dni = reader.GetString(nameof(inquilino.Dni)), // DNI
                            Nombre = reader.GetString(nameof(inquilino.Nombre)), // Nombre = reader.GetString("Nombre")
                            Apellido = reader.GetString(nameof(inquilino.Apellido)), // Apellido = reader.GetString("Apellido")
                            Direccion = reader.GetString(nameof(inquilino.Direccion)), // Direccion = reader.GetString("Direccion")
                            Telefono = reader.GetString(nameof(inquilino.Telefono)), // Telefono = reader.GetString("Telefono")   
                            Email = reader.GetString(nameof(inquilino.Email)), // Email = reader.GetString("Email")
                            Nacimiento = reader.GetDateTime(nameof(inquilino.Nacimiento))
                            
                        };
                        inquilinos.Add(inquilino);
                    }
                }

            }
            connection.Close();
        }
        return inquilinos;
    }

     public Inquilino Getinquilino(int id)
    {

        Inquilino inquilino = null;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT Id, Nombre, Direccion, Telefono, Nacimiento, Apellido, Email, Dni
        from inquilino where Id = @id";
            using (var command = new MySqlCommand(query, connection))
           
            {
                 command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        inquilino = new Inquilino
                        {
                            Id = reader.GetInt32(nameof(inquilino.Id)), // ID
                            Dni = reader.GetString(nameof(inquilino.Dni)), // DNI
                            Nombre = reader.GetString(nameof(inquilino.Nombre)), // Nombre = reader.GetString("Nombre")
                            Apellido = reader.GetString(nameof(inquilino.Apellido)), // Apellido = reader.GetString("Apellido")
                            Direccion = reader.GetString(nameof(inquilino.Direccion)), // Direccion = reader.GetString("Direccion")
                            Telefono = reader.GetString(nameof(inquilino.Telefono)), // Telefono = reader.GetString("Telefono")   
                            Email = reader.GetString(nameof(inquilino.Email)), // Email = reader.GetString("Email")
                            Nacimiento = reader.GetDateTime(nameof(inquilino.Nacimiento))
                            
                        };
                        
                    }
                }

            }
            connection.Close();
        }
        return inquilino;
    }



     public int DeleteInquilino(int id)
    {

       int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"Delete from inquilino where Id = @id";
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

