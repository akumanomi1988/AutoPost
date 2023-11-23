using AutoPost.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
