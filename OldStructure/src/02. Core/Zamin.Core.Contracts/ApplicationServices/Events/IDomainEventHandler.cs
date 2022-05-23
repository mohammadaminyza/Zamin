using Zamin.Core.Domain.Events;

namespace Zamin.Core.Contracts.ApplicationServices.Events;

/// <summary>
/// در صورت استفاده از این متد قادر به دریافت اطلاعات کاربر ارسال کننده ایونت نخواهید بود
/// </summary>
/// <typeparam name="TDomainEvent"></typeparam>
public interface IDomainEventHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    Task Handle(TDomainEvent Event);
}

