using System.ComponentModel.DataAnnotations;
namespace Inmobiliaria.Net.Models;

public class Inquilino
{
    public int? Id { get; set; }
    public String? Dni { get; set; }
    public String? Nombre { get; set; }
    public String? Apellido { get; set; }
    public String? Telefono { get; set; }

    [DataType(DataType.PhoneNumber)]
    
    public String? Direccion { get; set; }
    public String? Email { get; set; }

    [DataType(DataType.Date)]
    public DateTime? Nacimiento { get; set; }


    public Inquilino(){}

     public override string ToString()
    {
        return $"{Nombre} {Apellido}";
    }
}
