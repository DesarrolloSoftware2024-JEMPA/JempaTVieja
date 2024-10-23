using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace JempaTV.Califications
{
    public class CalificationDto : EntityDto<int>
    {
        public string idUsuario { get; set; }
        public int idSerie { get; set; }
        public int valor { get; set; }
        public string comentario { get; set; }
    }
}   