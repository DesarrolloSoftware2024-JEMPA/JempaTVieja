
using Scriban.Syntax;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace JempaTV.Series
{
    public class SerieAppService : CrudAppService<Serie, SerieDto, int, PagedAndSortedResultRequestDto, CreateUpdateSerieDto>, ISerieAppService
    {
        private readonly ISerieApiService _seriesApiService;
        private readonly IRepository<Serie, int> _seriesRepository;
        public SerieAppService(IRepository<Serie, int> repository, ISerieApiService seriesapiService) : base(repository)
        {
            _seriesApiService = seriesapiService;
            _seriesRepository = repository;
        }

        public async Task<ICollection<SerieDto>> SearchAsync(string title)
        {
            return await _seriesApiService.GetSeriesAsync(title);
        }

        public async Task PersistSeriesAsync(string title)
        {
            var matchedSeries = await _seriesApiService.GetSeriesAsync(title);

            var listSeries = new List<Serie>();

            foreach (var serie in matchedSeries) {
                listSeries.Add(new Serie()
                {
                    Title = serie.Title,
                    ImdbID = serie.ImdbID,
                    Actors = serie.Actors,
                    Director = serie.Director,
                    Year = serie.Year,
                    Plot = serie.Plot,
                    Poster = serie.Poster
                });
            }

            await _seriesRepository.InsertManyAsync(listSeries);
        }


        public async Task<Collection<SerieDto>> GetInternalSeries()
        {
            var series = await _seriesRepository.ToListAsync();

            var seriesDto = new List<SerieDto>();

            foreach (var serie in series)
            {
                seriesDto.Add(new SerieDto()
                {
                     Title = serie.Title,
                    ImdbID = serie.ImdbID,
                    Actors = serie.Actors,
                    Director = serie.Director,
                    Year = serie.Year,
                    Plot = serie.Plot,
                    Poster = serie.Poster
                }
                );
            }

            return new Collection<SerieDto>(seriesDto);
        }


    }
}
