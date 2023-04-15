using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Net.Models;

public class Pago
{
    public int? Id { get; set; }
    public int? ContratoId { get; set; }
    
   [DataType(DataType.Date)]
    public DateTime? FechaPago { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Periodo { get; set; }
  
    public double? Monto { get; set; }
  
    


    public Pago(){}


}