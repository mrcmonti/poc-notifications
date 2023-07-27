using MediatR;
using Microsoft.AspNetCore.Mvc;
using PocNotifications.Application.Commands;
using PocNotifications.Communication.Mediator;
using PocNotifications.Messages.Notifications;

namespace PocNotifications.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatrHandler _mediatorHandler;

        public FooController(INotificationHandler<DomainNotification> notifications, IMediatrHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var command = new FooCommand();
            await _mediatorHandler.SendCommand(command);

            if (_notifications.HasNotifications())
            {
                return Ok(_notifications.GetNotifications());
            }

            return Ok();
        }
    }
}