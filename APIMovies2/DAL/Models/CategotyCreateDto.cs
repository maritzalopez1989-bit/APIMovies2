using System.ComponentModel.DataAnnotations;

namespace APIMovies2.DAL.Models.Dtos
{
    public class CategotyCreateDto
    {
        [Required(ErrorMessage = "El nombre de la categoria es obligatorio")]
        [MaxLength(100, ErrorMessage = "El numero de la categoria es de 100.")]
        public string Name { get; set; }    
    }
}
