
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Net.Models;



public enum enRoles
	{
		
		Administrador = 1,
		Empleado = 2,
	}
public class Usuario
{
    [Key]
    [Display(Name = "Codigo")]
    public int? Id { get; set; }
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public string? Apellido { get; set; }

    
    public string? Avatar { get; set; }
    [Required, DataType(DataType.Password)]
    public string? Clave { get; set; }
    [Required, EmailAddress]
    public string? Email { get; set; }

    [NotMapped]
    public IFormFile? AvatarFile { get; set; }
		//[NotMapped]//Para EF
		//public byte[] AvatarFileContent { get; set; }
		//[NotMapped]//Para EF
		//public string AvatarFileName { get; set; }
	public int Rol { get; set; }
    public string RolNombre => Rol > 0 ? ((enRoles)Rol).ToString() : ""; //castea a un rol predefinido en el ENUM

    public static IDictionary<int, string> ObtenerRoles()
		{
			SortedDictionary<int, string> roles = new SortedDictionary<int, string>();
			Type tipoEnumRol = typeof(enRoles);
			foreach (var valor in Enum.GetValues(tipoEnumRol))
			{
				roles.Add((int)valor, Enum.GetName(tipoEnumRol, valor));
			}
			return roles;
		}

   

    public Usuario()
    {
    }

   
}

