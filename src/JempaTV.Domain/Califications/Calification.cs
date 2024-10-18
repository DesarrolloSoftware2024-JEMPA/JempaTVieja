using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace JempaTV.Califications
{
    public class Calification : AggregateRoot<int>
    {
        public int idUsuario { get; set; }
        public int idSerie { get; set; }
        public int valor { get; set; }
        public string comentario { get; set; }
    }
}