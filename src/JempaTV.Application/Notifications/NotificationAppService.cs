using AutoMapper;
using JempaTV.Califications;
using JempaTV.WatchLists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace JempaTV.Notifications
{
    public class NotificationAppService : ApplicationService, INotificationAppService
    {

        private readonly IRepository<Notification, int> _notificationRepository;
        private readonly IMapper _mapper;

        public NotificationAppService(IRepository<Notification, int> notificationRepository, IMapper mapper) 
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task SendNotification(NotificationDto notif, Guid userId)
        {
            var notification = new Notification()
            {
                Title = notif.Title,
                Content = notif.Content,
                Type = notif.Type,
                Read = notif.Read,
                User = userId,

            };

            await _notificationRepository.InsertAsync(notification);


        }

        public async Task<Collection<NotificationDto>> GetNotificationFromuser(Guid userId)
        {
            var notificationDtoList = new Collection<NotificationDto>();

            var notificationList = await _notificationRepository.GetListAsync(n => n.User == userId);

            if (!notificationList.Any())
            {
                throw new UserFriendlyException("No notifications found for the user.");
            }

            foreach (var notif in notificationList)
            {
                notificationDtoList.Add(_mapper.Map<NotificationDto>(notif));
            }

            return notificationDtoList;
        }
        
    }


}
