using AutoPost.Domain.Interfaces;

namespace AutoPost.Infraestructure.Instagram
{
    public class InstagramCategoryService : ICategoryService
    {
        public Task<IEnumerable<string>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
