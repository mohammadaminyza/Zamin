using Zamin.Core.Domain.Entities;

namespace MiniBlog.Core.Domain.EventTests
{
    public class EventTest : AggregateRoot
    {
        public string Name { get; set; }

        public EventTest(string name)
        {
            Name = name;
        }
    }
}
