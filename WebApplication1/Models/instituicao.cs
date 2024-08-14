using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class instituicao
    {
        [Key]
        public int instid { get; set; }
        [Required]
        public string instnome { get; set; }
        [Required]
        public string insendereco { get; set; }
        public virtual ICollection<departamento> departamento { get; set; }
    }
}
