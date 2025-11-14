using System.ComponentModel.DataAnnotations;

namespace APIMovies2.DAL.Models
{
    public class Category : AuditBase
    {
        [Required] // esta anotación indica que el campo es obligatorio
        [Display(Name = "Nombre de la categoria")] // esta anotación cambia el nombre que se muestra en las vistas
        public string Name { get; set; }
    }
}
/*
 * Category
 * Id
 * Name
 * createdDate
 * modifiedDate
 */