using MiniBlog.Core.Domain.EventTests;
using MiniBlog.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;
using MiniBlog.Core.Contracts;

namespace MiniBlog.Infra.Data.Sql.Commands.EventTests
{
    public class EventTestRepository : BaseCommandRepository<EventTest, MiniblogCommandDbContext>, IEventTestRepository
    {
        public EventTestRepository(MiniblogCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
