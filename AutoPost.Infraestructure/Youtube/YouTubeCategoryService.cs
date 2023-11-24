using AutoPost.Domain.Interfaces;

namespace AutoPost.Infraestructure.Youtube
{
    public class YouTubeCategoryService : ICategoryService
    {
        // Suponiendo que tienes configurado el acceso a la API de YouTube aquí
        public Task<IEnumerable<string>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }
    }

}
