using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tito_Store.viewModels
{
    public class Notification
    {
        public async Task SendNotification(string title, string message)
        {
            var request = new NotificationRequest
            {
                NotificationId = 1000,
                Title = title,
                Subtitle = message,
                Description = message,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5),
                    NotifyRepeatInterval = TimeSpan.FromDays(1)
                }



            };
            await LocalNotificationCenter.Current.Show(request);

        }
    }
}
