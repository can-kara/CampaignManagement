using MediatR;

namespace CampaignManagement.Domain.Events
{
    public class OrderStartedDomainEvent : INotification
    {
        public AggregateModels.OrderModels.Order Order { get; set; }
    }
}
