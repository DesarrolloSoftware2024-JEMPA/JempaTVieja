using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JempaTV.Califications
{
    class CreateUpdateCalificationDto
    {
        [Required]
        public required string IdUsuario { get; set; }

        [Required]
        public required int IdSerie { get; set; }

        [Required]
        public required int Valor { get; set; }

        [StringLength(256)]
        public string? Comentario { get; set; }
    }
}
