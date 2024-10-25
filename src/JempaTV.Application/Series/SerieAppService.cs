﻿using JempaTV.Califications;
using JempaTV.WatchLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace JempaTV.Series
{
    public class SerieAppService : CrudAppService<Serie, SerieDto, int, PagedAndSortedResultRequestDto, CreateUpdateSerieDto, CreateUpdateSerieDto>, ISerieAppService
    {
        private readonly ISerieApiService _seriesApiService;
        private readonly IRepository<WatchList, int> _watchlistRepository;
        private readonly IRepository<Serie, int> _serieRepository;
        public SerieAppService(IRepository<Serie, int> repository, ISerieApiService seriesapiService, IRepository<WatchList, int> watchlistRepository, IRepository<Serie, int> serieRepository) : base(repository)
        {
            _seriesApiService = seriesapiService;
            _watchlistRepository = watchlistRepository;
            _serieRepository = serieRepository;
        }

        public async Task<ICollection<SerieDto>> SearchAsync(string title, string gender)
        {
            return await _seriesApiService.GetSeriesAsync(title, gender);
        }


        public async Task<List<CalificationDto>> GetCalificationsAsync(Guid IdUsuario)
        {
            var calificationList = new List<CalificationDto>();
            try
            {
                var watchlist = await _watchlistRepository.GetAsync(w => w.IdUsuario == IdUsuario);
                
                foreach (var serie in watchlist.Series)
                {
                    if (serie.Calification != null)
                    {
                        calificationList.Add(ObjectMapper.Map<Calification, CalificationDto>(serie.Calification));      
                    }
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return calificationList;
        }

        public async Task AddCalificationAsync(CalificationDto calification, Guid IdUsuario)
        {
            var serie = await _serieRepository.GetAsync(calification.IdSerie);

            var userWatchlist = await _watchlistRepository.GetAsync(w => w.IdUsuario == IdUsuario);

            if (serie != null && userWatchlist != null)
            {

                if (userWatchlist.Series.Contains(serie))
                {
                    serie.Calification = (ObjectMapper.Map<CalificationDto, Calification>(calification));
                    await _serieRepository.UpdateAsync(serie);
                }

            }

        }

    }

}
