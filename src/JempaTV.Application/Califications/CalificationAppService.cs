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

        public async Task AddCalificationAsync(CalificationDto calification)
        {
            
        }
    }
}
