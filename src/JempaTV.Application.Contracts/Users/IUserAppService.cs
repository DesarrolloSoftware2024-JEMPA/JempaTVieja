﻿using JempaTV.Logs;
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

        Task setUserEmailConfiguration(bool emailNotification);

        Task setProfilePicture(string profilePicture);

        Task<string> getProfilePicture();

        Task<PagedResultDto<IdentityUserDto>> GetAllUsers();

        Task<List<LogDto>> getApiStats();

        Task<int> getErrorQuantity();

        Task<List<LogDto>> getUserStats();

        Task<List<LogDto>> getAllAuditLogs();
    };
}