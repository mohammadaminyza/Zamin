using MiniBlog.Core.Domain.EventTests;
using Zamin.Core.Contracts.Data.Commands;

namespace MiniBlog.Core.Contracts
{
    public interface IEventTestRepository : ICommandRepository<EventTest>
    {
    }
}
