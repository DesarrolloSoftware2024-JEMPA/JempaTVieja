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
        public string Title { get; set; }

        public string Genre { get; set; }

        public string Year { get; set; }

        public string Runtime { get; set; }

        public string Writer { get; set; }

        public string Poster { get; set; }

        public string Country { get; set; }

        public float ImdbRating { get; set; }
    }
}
