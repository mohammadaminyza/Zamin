using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace MiniBlog.Core.Contracts.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
