using System.ComponentModel.DataAnnotations;

namespace PawCare.Models
{
    public class Mascota
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la mascota es obligatorio.")]
        [Display(Name = "Nombre Mascota")]
        public string NombreMascota { get; set; }

        [Required(ErrorMessage = "El nombre del dueño es obligatorio.")]
        [Display(Name = "Nombre Dueño")]
        public string NombreDueno { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un tipo.")]
        public string Tipo { get; set; }

        [Range(0, 30, ErrorMessage = "La edad debe estar entre 0 y 30 años.")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [RegularExpression(@"^\d{9}$", ErrorMessage = "El teléfono debe tener exactamente 9 dígitos numéricos.")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Observaciones (Opcional)")]
        public string? Observaciones { get; set; }
    }
}
