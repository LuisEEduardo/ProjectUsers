using FluentValidation.Results;

namespace ProjectUsers.Domain.Notifications;

public interface INotificationContext
{
    void AddNotification(string message);
    void AddNotification(Notification notification);
    void AddNotification(List<Notification> notifications);
    void AddNotification(ValidationResult validationResult);
    List<Notification> GetAllNotifications();
    bool HasNotification();
}
