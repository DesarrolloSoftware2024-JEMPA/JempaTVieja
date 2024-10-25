using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace JempaTV.Califications
{
    public interface ICalificationAppService : ICrudAppService<CalificationDto, int>
    {
        Task AddCalificationAsync(CalificationDto calification);
        Task<List<CalificationDto>> GetCalificationsAsync(string IdUsuario);
    }
}
