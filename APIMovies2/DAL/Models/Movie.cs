using System.ComponentModel.DataAnnotations;

namespace APIMovies2.DAL.Models
{
    public class Movie : AuditBase
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nombre de la película")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Duración en minutos")]
        public int Duration { get; set; }

        [MaxLength(500)]
        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Clasificación")]
        public string Clasification { get; set; }
    }
}