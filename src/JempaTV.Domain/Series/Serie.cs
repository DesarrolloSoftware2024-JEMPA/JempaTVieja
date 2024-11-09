using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace JempaTV.Series
{
    public class Serie : AggregateRoot<int>
    {
        public String Title { get; set; }

        public String Genero { get; set; }

        public DateTime LastModification { get; set; }

        public DateTime Year { get; set; }

        public String Director { get; set; }

        public String Actors { get; set; }

        public String Plot { get; set; }

        public String Poster { get; set; }

        public float Imdb {  get; set; }

    }
}
