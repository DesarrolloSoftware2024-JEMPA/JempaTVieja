using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JempaTV.Series
{
    public interface ISerieApiService
    {
        Task<ICollection<SerieDto>> GetSeriesAsync(string title);

        
    }
}
