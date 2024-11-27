using JempaTV.Califications;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JempaTV.Series
{
    public class CreateUpdateSerieDto
    {
        public string Title { get; set; }
        public CalificationDto? Calification { get; set; }
        public string Year { get; set; }
        public string? Director { get; set; }
        public string? Actors { get; set; }
        public string? Plot { get; set; }
        public string Poster { get; set; }

    }
}
