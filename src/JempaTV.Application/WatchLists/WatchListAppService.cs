using AutoMapper;
using JempaTV.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace JempaTV.WatchLists
{
    public class WatchListAppService : ApplicationService, IWatchListAppService

    {

        private readonly IRepository<WatchList, int> _watchListRepository;
        private readonly IRepository<Serie, int> _serieRepository;
        private readonly IMapper _mapper;

        public WatchListAppService(IRepository<WatchList, int> watchListRepository, IRepository<Serie, int> serieRepository, IMapper mapper)
        {
            this._watchListRepository = watchListRepository;
            this._serieRepository = serieRepository;
            this._mapper = mapper;
        }

        public async Task AddSerieAsync(int watchlistId, int serieId)
        {
            try
            {
                //Podriamos modificar la funcion para que reciba como parametro el IdUsuario en vez de watchlistId.

                var watchlist = ((List<WatchList>)await _watchListRepository.GetListAsync()).FirstOrDefault();

                if (watchlist == null)
                {
                    watchlist = new WatchList();
                    await _watchListRepository.InsertAsync(watchlist);
                }

                var serie = await _serieRepository.GetAsync(serieId);
                watchlist.Series?.Add(serie);
                await _watchListRepository.UpdateAsync(watchlist);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            

        }

        public async Task AddWatchlist(Guid IdUsuario)
        {
            try
            {
                
                var watchlist = await _watchListRepository.FirstOrDefaultAsync(w => w.IdUsuario == IdUsuario);

                if (watchlist?.Id == null)
                {
                    var userWatchlist = new WatchList(){ IdUsuario = IdUsuario};
                    await _watchListRepository.InsertAsync(userWatchlist);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<List<SerieDto>> GetSeriesAsync(Guid IdUsuario)
        {
            var queryable = await _watchListRepository.WithDetailsAsync(w => w.Series);

            var watchlist = (await AsyncExecuter.ToListAsync(queryable)).FirstOrDefault(w => w.IdUsuario == IdUsuario);

            var seriesList = new List<SerieDto>();

            if (watchlist != null)
            foreach (var serie in watchlist.Series)
            {
                seriesList.Add(_mapper.Map<SerieDto>(serie));
            }

            return seriesList;

        }
    }
}
