using AutoMapper;
using JempaTV.Califications;
using JempaTV.WatchLists;
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
using Volo.Abp.ObjectMapping;

namespace JempaTV.Series
{
    public class SerieAppService : CrudAppService<Serie, SerieDto, int, PagedAndSortedResultRequestDto, CreateUpdateSerieDto>, ISerieAppService
    {
        private readonly ISerieApiService _seriesApiService;
        private readonly IRepository<WatchList, int> _watchlistRepository;
        private readonly IRepository<Serie, int> _serieRepository;
        private readonly IMapper _mapper;
        public SerieAppService(IRepository<Serie, int> repository, ISerieApiService seriesapiService, IRepository<WatchList, int> watchlistRepository, IRepository<Serie, int> serieRepository, IMapper mapper) : base(repository)
        {
            _seriesApiService = seriesapiService;
            _watchlistRepository = watchlistRepository;
            _serieRepository = serieRepository;
            _mapper = mapper;


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

        public async Task<List<CalificationDto>> GetCalificationsAsync(Guid IdUsuario)
        {
            
            try
            {
                var calificationList = new List<CalificationDto>();

                var queryable = await _watchlistRepository.WithDetailsAsync(w => w.Series);

                var watchlist = (await AsyncExecuter.ToListAsync(queryable)).FirstOrDefault(w=>w.IdUsuario == IdUsuario);

                if (watchlist != null)
                {
                    foreach (var serie in watchlist.Series)
                    {
                            var seriesQueryable = await _serieRepository.WithDetailsAsync(s => s.Calification);

                            var series = (await AsyncExecuter.ToListAsync(seriesQueryable)).FirstOrDefault(s=> s.Id == serie.Id);

                            if (series?.Calification != null)
                            {
                            calificationList.Add(_mapper.Map<CalificationDto>(series?.Calification));
                            }
                              
                    }

                }

                return calificationList;

            } catch (Exception ex)
            {
                var calificationList = new List<CalificationDto>();
                Console.WriteLine(ex.ToString());
                return calificationList;
            }

            
        }

        public async Task AddCalificationAsync(CalificationDto calification, Guid IdUsuario)
        {
            if (calification.Valor > 5 | calification.Valor < 0) 
            {

               var serie = await _serieRepository.GetAsync(calification.IdSerie);
            
               var userWatchlist = await _watchlistRepository.GetAsync(w => w.IdUsuario == IdUsuario);

                if (serie != null && userWatchlist != null)
                {

                    if (userWatchlist.Series.Contains(serie))
                    {

                        var newCalification = (_mapper.Map<Calification>(calification));
                        serie.Calification = newCalification;
                        await _serieRepository.UpdateAsync(serie);

                    }
                    else
                    {
                        Console.WriteLine("La serie no se encuentra en la Watchlist de este usuario.");
                    }
                }

            }
            else
            {
                Console.WriteLine("El valor de la calificacion no se encuentra entre 0 y 5");
            }

        }

        public async Task EditCalificationAsync(int IdCalification, CalificationDto updateCalification, Guid IdUsuario)
        {
            var queryable1 = await _serieRepository.WithDetailsAsync(s => s.Calification);

            var serie = (await AsyncExecuter.ToListAsync(queryable1)).FirstOrDefault(s => s.Id == updateCalification.IdSerie);

            var queryable2 = await _watchlistRepository.WithDetailsAsync(w => w.Series);

            var watchlist = (await AsyncExecuter.ToListAsync(queryable2)).FirstOrDefault(w => w.IdUsuario == IdUsuario);

            if (watchlist.Series.Contains(serie))
            {
                var calification = _mapper.Map<Calification>(updateCalification);
                serie.Calification = calification;
                await _serieRepository.UpdateAsync(serie);
            } 
            else
            {
                Console.WriteLine("La serie no pertenece a la watchlist de este usuario");
            }
        }

    }

}
