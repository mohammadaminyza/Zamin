using MiniBlog.Core.Contracts;
using MiniBlog.Core.Domain.Blogs.Events;
using MiniBlog.Core.Domain.EventTests;
using Zamin.Core.ApplicationServices.Events;

namespace MiniBlog.Core.ApplicationService.Blogs.Events;

public class BlogCreatedHandler : DomainEventHandler<BlogCreated>
{
    private readonly IEventTestRepository _eventTestRepository;
    public BlogCreatedHandler(IEventTestRepository eventTestRepository)
    {
        _eventTestRepository = eventTestRepository;
    }

    public override async Task EventHandler(BlogCreated Event)
    {
        var entity = new EventTest(Event.Title);
        await _eventTestRepository.InsertAsync(entity);
        await _eventTestRepository.CommitAsync();
    }
}