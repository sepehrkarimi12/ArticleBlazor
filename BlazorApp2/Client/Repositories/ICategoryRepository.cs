using BlazorApp2.Shared.DTO;
using BlazorApp2.Shared.Entities;
using BlazorApp2.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BlazorApp2.Client.Repositories
{
    public interface ICategoryRepository
    {
        Task<ResponseDataHelper<bool>> CreateCategory(Category category);
        Task<ResponseDataHelper<bool>> DeleteCategory(Category category);
        Task<ResponseDataHelper<List<Category>>> GetAllCategories();
        Task<ResponseDataHelper<Category>> GetCategoryById(long Id);
        Task<ResponseDataHelper<bool>> UpdateCategory(Category category);
    }
}
