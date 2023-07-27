using MediatR;
using PocNotifications.Messages;
using PocNotifications.Messages.Notifications;

namespace PocNotifications.Communication.Mediator
{
    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator _mediatr;

        public MediatrHandler(IMediator mediatr)
        {
            _mediatr = mediatr; 
        }

        public async Task<bool> SendCommand<T>(T command) where T : Command
        {
            return await _mediatr.Send(command);
        }

        public async Task PublishNotification<T>(T notification) where T : DomainNotification
        {
            await _mediatr.Publish(notification);
        }
    }
}
