using AutoMapper;
using Data.Contracts;
using Data.Repositories;
using Entities;
using Entities.Post;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using System;
using WebFramework.Api;

namespace MyApi.Controllers.v1
{
    //[ApiVersion("1")]
    public class PostsController : CrudController<PostDto, PostSelectDto, Post, Guid>
    {
        public PostsController(IRepository<Post> repository)
            : base(repository)
        {
        }
    }
}
