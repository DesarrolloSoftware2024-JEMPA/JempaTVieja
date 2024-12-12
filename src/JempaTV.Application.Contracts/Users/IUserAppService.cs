using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace JempaTV.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<PagedResultDto<IdentityUserDto>> GetAllUsers();
    };
}
