using Data.Contracts;
using Entities.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using WebFramework.Api;

namespace MyApi.Controllers.v2
{
    [ApiVersion("2")]
    public class PostsController : v1.PostsController
    {
        public PostsController(IRepository<Post> repository) : base(repository)
        {
        }

        [NonAction]
        public override Task<ApiResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            return base.Delete(id, cancellationToken);
        }

        public async override Task<ActionResult<List<PostSelectDto>>> Get(CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<PostSelectDto>
            {
                new PostSelectDto
                {
                    FullTitle = "FullTitle",
                    AuthorFullName = "AuthorFullName",
                    CategoryName = "CategoryName",
                    Description = "Description",
                    Title = "Title",
                }
            });
        }

        public async override Task<ApiResult<PostSelectDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            if (Guid.Empty == id)
                return NotFound();
            return await base.Get(id, cancellationToken);
        }

        [HttpGet("Test")]
        public ActionResult Test()
        {
            return Content("This is test");
        }
    }
}
