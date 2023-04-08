
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inmobiliaria.Net.Models;



[Table("Inmuebles")]

public class Inmueble
{
    [Display(Name = "N°")]
    public int? Id { get; set; }
    public string? Direccion { get; set; }
    public int? Uso { get; set; }
    public int? Tipo { get; set; }
    [Display(Name = "Ambientes")]
    public int? CantidadDeAmbientes { get; set; }
    public decimal? Latitud { get; set; }
    public decimal? Longitud { get; set; }
    public decimal? Precio { get; set; }
    public decimal? Superficie { get; set; }
    [Display(Name = "Propietario")]
    public int? PropietarioId { get; set; }
    public bool Disponible {get;set;}


     public Propietario? Duenio { get; set; }

    public Inmueble()
    {
    }

     public override string ToString()
    {
        return $"{Direccion}";
    }
    
}

