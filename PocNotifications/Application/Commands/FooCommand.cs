using PocNotifications.Messages;

namespace PocNotifications.Application.Commands
{
    public class FooCommand : Command
    {
        public Guid Id { get; private set; }

        public FooCommand()
        {
            Id = Guid.NewGuid();
        }
    }
}
