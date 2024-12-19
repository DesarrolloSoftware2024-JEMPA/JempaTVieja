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
using Volo.Abp.Identity;
using Volo.Abp.AuditLogging;
using JempaTV.Logs;
using Volo.Abp.Account;
using Volo.Abp.Data;
using System.Text.Json.Nodes;
using System.Net;
using Newtonsoft.Json;

namespace JempaTV.Users
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;
        private readonly IIdentityUserAppService _identityUserAppService;
        private readonly IAuditLogRepository _auditLogRepository;
        private readonly IRepository<IdentityUser> _identityUserRepository;
        

        public UserAppService(IMapper mapper, ICurrentUser currentUser, IIdentityUserAppService identityUserAppService, IAuditLogRepository auditLogRepository, IRepository<IdentityUser> repository)
        { 
            _currentUser = currentUser;
            _mapper = mapper;
            _identityUserAppService = identityUserAppService;
            _auditLogRepository = auditLogRepository;
            _identityUserRepository = repository;
        }

        public async Task setUserEmailConfiguration(bool emailNotification)
        {
            var userId = _currentUser.Id;
            var user = await _identityUserRepository.FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                user.SetProperty("emailNotification", emailNotification);
                await _identityUserRepository.UpdateAsync(user);
            }
            
        }

        public async Task setProfilePicture(string profilePicture)
        {
            var userId = _currentUser.Id;
            var user = await _identityUserRepository.FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                user.SetProperty("profilePicture", profilePicture);
                await _identityUserRepository.UpdateAsync(user);
            }

        }

        public async Task<string> getProfilePicture()
        {
            var userId = _currentUser.Id;
            var user = await _identityUserRepository.FirstOrDefaultAsync(u => u.Id == userId);
            var userProfilePicture = "";

            if (user != null)
            {
                userProfilePicture = user.GetProperty<string>("profilePicture");
            }

            return JsonConvert.SerializeObject(userProfilePicture);

        }

        public async Task<PagedResultDto<IdentityUserDto>> GetAllUsers()
        {
         

            return await _identityUserAppService.GetListAsync(new GetIdentityUsersInput());

        }
       

        public async Task<List<LogDto>> getApiStats()
        {
            var logList = await _auditLogRepository.GetListAsync(l => l.Url.Contains("/api/app/serie"));
            var logListDto = new List<LogDto>();

            foreach (var log in logList)
            {
                logListDto.Add(_mapper.Map<LogDto>(log));
            }

            return logListDto;
        }

        public async Task<int> getErrorQuantity()
        {
            var logListDto = await getApiStats();
            var err = 0;

            foreach (var log in logListDto)
            {
                if (!log.Exceptions.IsNullOrEmpty())
                {
                    err = err + 1;
                }
            }

            return err;
        }

        public async Task<List<LogDto>> getUserStats()
        {
            var logList = await _auditLogRepository.GetListAsync(l => l.Url.Contains("/api/identity/users"));
            var logListDto = new List<LogDto>();

            foreach (var log in logList)
            {
                logListDto.Add(_mapper.Map<LogDto>(log));
            }

            return logListDto;
        }

        public async Task<List<LogDto>> getAllAuditLogs()
        {
            var logList = await _auditLogRepository.GetListAsync();
            var logListDto = new List<LogDto>();

            foreach (var log in logList)
            {
                logListDto.Add(_mapper.Map<LogDto>(log));
            }

            return logListDto;
        }
    }
}
