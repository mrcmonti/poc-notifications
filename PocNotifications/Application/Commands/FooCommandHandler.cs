using MediatR;
using PocNotifications.Communication.Mediator;
using PocNotifications.Messages.Notifications;

namespace PocNotifications.Application.Commands
{
    public class FooCommandHandler : IRequestHandler<FooCommand, bool>
    {
        private readonly IMediatrHandler _mediatorHandler;

        public FooCommandHandler(IMediatrHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public Task<bool> Handle(FooCommand request, CancellationToken cancellationToken)
        {
            _mediatorHandler.PublishNotification(new DomainNotification("ErrorCode", "Notification message"));
            _mediatorHandler.PublishNotification(new DomainNotification("ErrorCode", "New Notification message"));

            return Task.FromResult(true);
        }
    }
}
