using Zamin.Core.Contracts.ApplicationServices.Events;
using Zamin.Core.Domain.Events;

namespace Zamin.Core.ApplicationServices.Events;

/// <summary>
/// به جای IDomainEventHandler
/// از این متد  برای دریافت ایونت استفاده شود
/// امکان مدیریت کاربر ارسال کننده ایونت را دارد
/// </summary>
/// <typeparam name="TDomainEvent"></typeparam>
public abstract class DomainEventHandler<TDomainEvent> : IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{
    /// <summary>
    /// در این قسمت کار هایی ضرروی ایونت از جمله خالی کردن اطلاعات کاربر انجام میشود
    /// </summary>
    /// <param name="Event"></param>
    /// <returns></returns>
    public async Task Handle(TDomainEvent Event)
    {
        await EventHandler(Event);

        EventUserInfo.ClearInfo();
    }

    public abstract Task EventHandler(TDomainEvent Event);
}