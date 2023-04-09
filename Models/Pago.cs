namespace Inmobiliaria.Net.Models;

public class Pago
{
    public int? Id { get; set; }
    public int? ContratoId { get; set; }
    
   
    public DateTime? FechaPago { get; set; }
    public DateTime? MesPagado { get; set; }
  
    public double? Monto { get; set; }
  
    


    public Pago(){}
}
