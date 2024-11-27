using JempaTV.WatchLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace JempaTV.Notifications
{
    public class NotificationAppService : ApplicationService, INotificationAppService
    {

        private readonly IRepository<Notification, int> _notificationRepository;

        public NotificationAppService(IRepository<Notification, int> notificationRepository) 
        {
            this._notificationRepository = notificationRepository;
        }

        public async Task SendNotification(NotificationDto notif, string userId)
        {
            var notification = new Notification()
            {
                Title = notif.Title,
                Content = notif.Content,
                Type = notif.Type,
                Read = notif.Read,
                User = userId

            };

            await _notificationRepository.InsertAsync(notification);


        }
        
    }
}
