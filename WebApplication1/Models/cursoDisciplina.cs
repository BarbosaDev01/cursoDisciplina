using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class cursoDisciplina
    {
        [Key]
        public int cursoDisciplinaID { get; set; }
        [Required]
        public int cursoID { get; set; }
        public curso curso { get; set; }
        [Required]
        public int disciplinaID { get; set; }
        public disciplina disciplina { get; set; }
    }
}
