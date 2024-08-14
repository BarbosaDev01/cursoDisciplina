using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class curso
    {
        [Key]
        public int cursoId { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public int depid { get; set; }
        public departamento departamento { get; set; }
        public virtual ICollection<cursoDisciplina> cursoDisciplina { get; set; }
    }
}
