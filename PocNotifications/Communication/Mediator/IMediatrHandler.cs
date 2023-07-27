using PocNotifications.Messages;
using PocNotifications.Messages.Notifications;

namespace PocNotifications.Communication.Mediator
{
    public interface IMediatrHandler
    {
        Task<bool> SendCommand<T>(T command) where T : Command;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}
