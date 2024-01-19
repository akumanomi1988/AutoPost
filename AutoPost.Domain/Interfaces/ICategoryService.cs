namespace AutoPost.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<string>> GetCategoriesAsync();
    }

}
