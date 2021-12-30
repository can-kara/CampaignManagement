using MediatR;
using System;
using System.Collections.Generic;

namespace CampaignManagement.Domain.SeedWork
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        private ICollection<INotification> domainEvents;
        public ICollection<INotification> DomainEvents => domainEvents;

        public void AddDomainEvents(INotification notification)
        {
            domainEvents ??= new List<INotification>();
            domainEvents.Add(notification);
        }
    }
}
