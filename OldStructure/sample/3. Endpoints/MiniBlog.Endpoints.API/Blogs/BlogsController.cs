﻿using Microsoft.AspNetCore.Mvc;
using MiniBlog.Core.Contracts.Blogs.Commands.CreateBlog;
using Zamin.EndPoints.Web.Controllers;

namespace MiniBlog.Endpoints.API.Blogs
{
    [Route("api/[controller]")]
    public class BlogsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBlogCommand createBlog)
        {
            return await Create(createBlog);
        }
    }
}
