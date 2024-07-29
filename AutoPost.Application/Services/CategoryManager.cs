

using AutoPost.Domain.Interfaces;
using AutoPost.Infraestructure.Instagram;
using AutoPost.Infraestructure.Youtube;
using Microsoft.Extensions.DependencyInjection;

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
            return _categoryServices.TryGetValue(platform, out ICategoryService? service)
                ? await service.GetCategoriesAsync()
                : throw new NotSupportedException($"Platform {platform} is not supported.");
        }
    }

}
