using JempaTV.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace JempaTV.Users
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private IRepository<IdentityUser, Guid> _userRepository;
        private IIdentityUserAppService _identityUserAppService;

        public UserAppService(IRepository<IdentityUser, Guid> userRepository, IIdentityUserAppService identityUserAppService)
        {
            _userRepository = userRepository;
            _identityUserAppService = identityUserAppService;
        }

        public async Task<PagedResultDto<IdentityUserDto>> getAllUsers()
        {
            var result = new PagedResultDto<IdentityUserDto>();
            result = await _identityUserAppService.GetListAsync(new GetIdentityUsersInput());
            if (result != null)
            {
                return result; // Devuelve la lista de usuarios
            }
            return result;
        }


    }
}
