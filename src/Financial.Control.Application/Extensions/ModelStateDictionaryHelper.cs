using Financial.Control.Domain.Entities.NotificationEntity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Financial.Control.Application.Extensions
{
    public static class ModelStateDictionaryHelper
    {
        public static IReadOnlyCollection<Notification> CreateNotifications(this ModelStateDictionary modelState, string context = null)
        {
            return modelState.Select(ms => ms).ToList().ConvertAll(ms => Notification.Create(context, ms.Key, ms.Value.Errors.Select(err => err.ErrorMessage)
                                    .ToList()));
        }
    }
}
