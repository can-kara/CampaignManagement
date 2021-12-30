using CampaignManagement.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CampaignManagement.Application.DomainEventHandlers
{
    public class OrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        //Order Create edilmeden birşeyler create edilecek ise buradan yapılabilinir. Repository constructure injection yapılarak
        public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            if (notification.Order.Id == 0)
            {
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
