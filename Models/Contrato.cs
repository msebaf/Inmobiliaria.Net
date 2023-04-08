namespace Inmobiliaria.Net.Models;

public class Contrato
{
    public int? Id { get; set; }
    public int? InmuebleId { get; set; }
    public int? InquilinoId { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFinal { get; set; }
  
    public double? MontoMensual { get; set; }
    public Inmueble inmueble { get; set; }
    public Inquilino inquilino { get; set; }
    


    public Contrato(){}
}
