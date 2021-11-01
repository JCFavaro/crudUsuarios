using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crudUsuarios.Models
{
    public class SEG_Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de alta o de modificación")]
        public DateTime FechaAltaModificacion { get; set; }
    }
}
