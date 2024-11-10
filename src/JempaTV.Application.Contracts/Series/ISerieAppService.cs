using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace JempaTV.Series
{
    public interface ISerieAppService : ICrudAppService<SerieDto, int, PagedAndSortedResultRequestDto, CreateUpdateSerieDto>
    {
        Task<ICollection<SerieDto>> SearchAsync(string title);
        Task PersistSeriesAsync(string title);

        Task<Collection<SerieDto>> GetInternalSeries();

    }
}
