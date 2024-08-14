using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class disciplina
    {

        [Key]
        public int disciplinaId { get; set; }
        [Required]
        public string nome { get; set; }
        public virtual ICollection<cursoDisciplina> cursoDisciplina { get; set; }
    }
}
