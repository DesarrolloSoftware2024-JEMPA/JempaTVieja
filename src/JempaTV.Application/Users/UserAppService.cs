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
using Volo.Abp.Users;
using JempaTV.Users;
using JempaTV.Series;
using Volo.Abp.Identity;

namespace JempaTV.Users
{
    public class UserAppService : CrudAppService<User, UserDto, int, PagedAndSortedResultRequestDto, CreateUpdateUserDto>, IUserAppService
    {
        private readonly IRepository<WatchList, int> _watchlistRepository;
        private readonly IRepository<User, int> _userRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;
        private readonly IIdentityUserAppService _IIdentityUserAppService;
        public UserAppService(IRepository<User, int> repository, IRepository<WatchList, int> watchlistRepository, IRepository<User, int> userRepository, IMapper mapper, ICurrentUser currentUser, IIdentityUserAppService identityUserAppService) : base(repository)
        {
            _watchlistRepository = watchlistRepository;
            _userRepository = userRepository;
            _currentUser = currentUser;
            _mapper = mapper;
            _IIdentityUserAppService = identityUserAppService;
        }

        public async Task<PagedResultDto<IdentityUserDto>> GetAllUsers()
        {
            /*var users = await _IIdentityUserAppService.GetListAsync(new GetIdentityUsersInput());

            *//*Convertimos las entidades de IdentityUserDto a UserDto*//*

            return ConvertToUserDto(users);*/

            
             


            return await _IIdentityUserAppService.GetListAsync(new GetIdentityUsersInput());

        }
        public List<UserDto> ConvertToUserDto(PagedResultDto<IdentityUserDto> pagedResult)
        {
            if (pagedResult == null || pagedResult.Items == null)
            {
                return new List<UserDto>();
            }

            return pagedResult.Items.Select(user => new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
        }).ToList();
        }
    }
}
