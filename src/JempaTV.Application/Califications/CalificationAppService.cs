using JempaTV.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace JempaTV.Califications
{
    public class CalificationAppService : CrudAppService<Calification, CalificationDto, int>, ICalificationAppService
    {
        private readonly IRepository<Calification, int> _CalificationRepository;

        public CalificationAppService(IRepository<Calification, int> repository) : base(repository)
        {
            _CalificationRepository = repository;
        }



        public async Task<List<CalificationDto>> GetCalificationsAsync(string IdUsuario)
        {
            var result = await _CalificationRepository.GetListAsync(c => c.IdUsuario == IdUsuario);
            var calificationList = new List<CalificationDto>();
            foreach (var item in result)
            {
                calificationList.Add(new CalificationDto()
                {
                    Id = item.Id,
                    IdSerie = item.IdSerie,
                    IdUsuario = item.IdUsuario,
                    Valor = item.Valor,
                    Comentario = item.Comentario,
                });
            }
            return calificationList;
        }

        public async Task AddCalificationAsync(CalificationDto calification)
        {
            
            await _CalificationRepository.InsertAsync(new Calification() 
            {   IdUsuario = calification.IdUsuario,
                IdSerie = calification.IdSerie,
                Valor = calification.Valor,
                Comentario = calification.Comentario });
            
        }
    }
}
