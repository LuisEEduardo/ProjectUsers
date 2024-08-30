using FluentValidation.Results;

namespace ProjectUsers.Domain.Notifications;

public class NotificationContext : INotificationContext
{
    public List<Notification> _notifications;

    public NotificationContext()
    {
        _notifications = new();
    }

    public void AddNotification(string message)
    {
        _notifications.Add(new Notification(message));
    }

    public void AddNotification(Notification notification)
    {
        _notifications.Add(notification);
    }

    public void AddNotification(List<Notification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void AddNotification(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            AddNotification(error.ErrorMessage);
        }
    }

    public List<Notification> GetAllNotifications()
    {
        return _notifications;
    }

    public bool HasNotification()
    {
        return _notifications.Any();
    }
}
