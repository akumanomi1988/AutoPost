﻿using AutoPost.Application.Interfaces;
using AutoPost.Infraestructure.Instagram;
using AutoPost.Infraestructure.Youtube;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Application.Services
{
    public class CategoryManager
    {
        private readonly IDictionary<string, ICategoryService> _categoryServices;

        public CategoryManager(IServiceProvider serviceProvider)
        {
            _categoryServices = new Dictionary<string, ICategoryService>
            {
                { "YouTube", serviceProvider.GetRequiredService<YouTubeCategoryService>() },
                { "Instagram", serviceProvider.GetRequiredService<InstagramCategoryService>() }
            };
        }

        public async Task<IEnumerable<string>> GetCategoriesAsync(string platform)
        {
            if (_categoryServices.TryGetValue(platform, out var service))
            {
                return await service.GetCategoriesAsync();
            }

            throw new NotSupportedException($"Platform {platform} is not supported.");
        }
    }

}