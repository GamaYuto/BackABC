using System;
using System.ComponentModel.DataAnnotations;

namespace Api_1.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de identificación es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El número de identificación no puede ser menor a 0.")]
        public int Numeroidentificacion { get; set; }

        [Required(ErrorMessage = "El primer nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El primer nombre no puede exceder los 50 caracteres.")]
        public string? Primernombre { get; set; }

        [MaxLength(50, ErrorMessage = "El segundo nombre no puede exceder los 50 caracteres.")]
        public string? Segundonombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El primer apellido no puede exceder los 50 caracteres.")]
        public string? Primerapellido { get; set; }

        [MaxLength(50, ErrorMessage = "El segundo apellido no puede exceder los 50 caracteres.")]
        public string? Segundoapellido { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "El formato de la fecha de nacimiento no es válido.")]
        [CustomValidation(typeof(Client), nameof(ValidarEdad))]
        public DateTime Fechanacimiento { get; set; }

        [Required(ErrorMessage = "El valor estimado es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor estimado no puede ser menor a 0.")]
        public int Valorestimado { get; set; }

        [MaxLength(500, ErrorMessage = "Las observaciones no pueden exceder los 500 caracteres.")]
        public string? Observaciones { get; set; }

        // Validación personalizada para la edad mínima (por ejemplo, 18 años).
        public static ValidationResult? ValidarEdad(DateTime fechaNacimiento, ValidationContext context)
        {
            var edad = DateTime.Today.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad)) edad--;

            return edad >= 18
                ? ValidationResult.Success
                : new ValidationResult("El cliente debe ser mayor de 18 años.");
        }
    }
}