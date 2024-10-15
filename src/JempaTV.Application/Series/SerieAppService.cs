using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace JempaTV.Series
{
    public class SerieAppService : CrudAppService<Serie, SerieDto, int, PagedAndSortedResultRequestDto, CreateUpdateSerieDto, CreateUpdateSerieDto>, ISerieAppService
    {
        private readonly ISerieApiService _seriesApiService;
        private readonly IRepository<Serie, int> _seriesRepository;
        public SerieAppService(IRepository<Serie, int> repository, ISerieApiService seriesapiService) : base(repository)
        {
            _seriesApiService = seriesapiService;
            _seriesRepository = repository;
        }

        public async Task<ICollection<SerieDto>> SearchAsync(string title, string gender)
        {
            return await _seriesApiService.GetSeriesAsync(title, gender);
        }

        public async Task PersistSeriesAsync(string title, string gender)
        {
            var matchedSeries = await _seriesApiService.GetSeriesAsync(title, gender);

            var listSeries = new List<Serie>();

            foreach (var series in matchedSeries) {
                listSeries.Add(new Serie { Title = series.Title });
            }

            await _seriesRepository.InsertManyAsync(listSeries);
        }

    }
}
