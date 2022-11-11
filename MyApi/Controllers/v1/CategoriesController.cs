﻿using AutoMapper;
using Data.Contracts;
using Data.Repositories;
using Entities;
using Entities.Post;
using MyApi.Models;
using WebFramework.Api;

namespace MyApi.Controllers.v1
{
    public class CategoriesController : CrudController<CategoryDto, Category>
    {
        public CategoriesController(IRepository<Category> repository) : base(repository)
        {
        }
    }
}
