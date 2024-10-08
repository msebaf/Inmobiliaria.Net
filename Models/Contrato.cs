using System.ComponentModel.DataAnnotations;


namespace Inmobiliaria.Net.Models;

public class Contrato
{
    public int? Id { get; set; }
    public int? InmuebleId { get; set; }
    public int? InquilinoId { get; set; }

  [DataType(DataType.Date)]
  [Display(Name = "Fecha de Inicio")]
    public DateTime? FechaInicio { get; set; }

  [Display(Name = "Fecha Final")]
    [DataType(DataType.Date)]
    [FechaActual(ErrorMessage = null)]
  
    public DateTime? FechaFinal { get; set; }
    
    [Display(Name = "Monto")]
    [Required(ErrorMessage = "El monto es obligatorio.")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El monto debe ser un número válido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser un número positivo.")]
    public double? MontoMensual { get; set; }
    
    public Inmueble inmueble { get; set; }
    public Inquilino inquilino { get; set; }
    


    public Contrato(){}

   public override string ToString(){
    return $"{InmuebleId} {InquilinoId}";
   }


    
}

public class FechaActualAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime fechaFinal = Convert.ToDateTime(value);
        var contrato = (Contrato)validationContext.ObjectInstance;

        if (fechaFinal < DateTime.Now)
        {
            return new ValidationResult(ErrorMessage ?? $"La {validationContext.DisplayName} no puede ser anterior a la fecha actual.");
        }

        if (contrato.FechaInicio.HasValue && fechaFinal < contrato.FechaInicio.Value)
        {
            return new ValidationResult(ErrorMessage ?? $"La {validationContext.DisplayName} no puede ser menor que la fecha de inicio.");
        }
        if(contrato.FechaFinal.HasValue && contrato.FechaInicio.HasValue)
        {
            
        }

        return ValidationResult.Success;
    }
}

