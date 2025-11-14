using System.ComponentModel.DataAnnotations;

namespace APIMovies2.DAL.Models
{
    public class AuditBase
    {
        [Key]
        public  virtual int Id { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime ModifiedDate { get; set; }
    }
}