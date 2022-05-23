using MiniBlog.Core.Domain.Blogs.Events;
using Zamin.Core.ApplicationServices.Events;
using Zamin.Core.Contracts.ApplicationServices.Events;

namespace MiniBlog.Core.ApplicationService.Blogs.Events;

public class BlogCreatedHandler : DomainEventHandler<BlogCreated>
{
    public override Task EventHandler(BlogCreated Event)
    {
        Console.WriteLine(Event.Title);
        return Task.CompletedTask;
    }
}