using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<string>> GetCategoriesAsync();
    }

}
