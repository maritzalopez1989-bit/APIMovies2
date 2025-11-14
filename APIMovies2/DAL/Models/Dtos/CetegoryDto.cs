using System.ComponentModel.DataAnnotations;
using System.Data;

namespace APIMovies2.DAL.Models.Dtos
{
    public class CetegoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la categoria es obligatorio")]
        [MaxLength(100, ErrorMessage = "El numero de la categoria es de 100.")]
        public string Name { get; set; }    

        public DateTime CreatedDate { get; set; }   
        public DateTime ModifiedDate { get; set; }

    }
}
