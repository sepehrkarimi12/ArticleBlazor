using BlazorApp2.Shared.Entities;
using System.Threading.Tasks;

namespace BlazorApp2.Client.Pages.Admin.CategoryComponents
{
    public partial class Create
    {
        public Category category { get; set; } = new Category();
        public string Message = null;
        public bool ShowMessage = false;

        private async Task CreateCategory()
        {
            var response = await categoryRepository.CreateCategory(category);
            ShowMessage = true;
            if (response.Success)
            {
                if (response.Response)
                {
                    Message = "عملیات با موفقیت انجام شد";
                }
                else
                {
                    Message = "در ثبت اطلاعات خطایی رخ داد";
                }
            }
            else
            {
                Message = "درخواست شما انجام نشد";
            }
        }

        public Create()
        {

        }

        protected override void OnInitialized()
        {
            
        }
    }
}
