using MiniBlog.Core.Domain.Blogs.Events;
using Zamin.Core.Contracts.ApplicationServices.Events;

namespace MiniBlog.Core.ApplicationService.Blogs.Events;

public class BlogCreatedHandler : IDomainEventHandler<BlogCreated>
{
    public Task Handle(BlogCreated Event)
    {
        Console.WriteLine(Event.Title);
        return Task.CompletedTask;
    }
}