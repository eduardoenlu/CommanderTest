using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commander.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }

    public class CommandModified
    {
        [Key]
        [Column("Id")]
        public int Identificador { get; set; }
        
        [Column("HowTo")] 
        [Required]
        public string Como { get; set; }
        
        [Column("Line")]
        [Required]
        public string Linea { get; set; }
        
        [Column("Platform")]
        [Required]
        public string Plataforma { get; set; }
    }
}