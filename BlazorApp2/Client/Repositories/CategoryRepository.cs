using BlazorApp2.Client.Services;
using BlazorApp2.Shared.DTO;
using BlazorApp2.Shared.Entities;
using BlazorApp2.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Client.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IHttpService _http;
        private readonly string _URL = "api/categories";
        public CategoryRepository(IHttpService http)
        {
            _http = http;
        }

        public async Task<ResponseDataHelper<bool>> CreateCategory(Category category)
        {
            var result = await _http.PostAsync<Category, bool>($"{_URL}/createCategory", category);

            return result;
        }

        public async Task<ResponseDataHelper<List<Category>>> GetAllCategories()
        {
            var result = await _http.Get<List<Category>>($"{_URL}/categoryList");

            return result;
        }

        public async Task<ResponseDataHelper<Category>> GetCategoryById(long Id)
        {
            var result = await _http.PostAsync<long, Category>($"{_URL}/getCategoryById", Id);

            return result;
        }

        public async Task<ResponseDataHelper<bool>> UpdateCategory(Category category)
        {
            var result = await _http.PostAsync<Category, bool>($"{_URL}/updateCategory", category);

            return result;
        }

        public async Task<ResponseDataHelper<bool>> DeleteCategory(Category category)
        {
            var result = await _http.PostAsync<Category, bool>($"{_URL}/deleteCategory", category);

            return result;
        }
    }
}
