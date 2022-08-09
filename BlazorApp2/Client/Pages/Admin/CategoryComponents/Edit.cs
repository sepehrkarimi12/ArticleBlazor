using BlazorApp2.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorApp2.Client.Pages.Admin.CategoryComponents
{
    public partial class Edit
    {
        [Parameter]
        public long Id { get; set; }

        public Category category { get; set; }
        public string Message = null;
        public bool ShowMessage = false;

        protected override async Task OnInitializedAsync()
        {
            var result = await categoryRepository.GetCategoryById(Id);
            if (result.Success)
            {
                if (result != null)
                {
                    this.category = result.Response;
                }
                else
                {
                    this.ShowMessage = true;
                    Message = "اطلاعات کاربر دریافت شد";
                }
            }
            else
            {
                this.ShowMessage = true;
                Message = "دریافت اطلاعات با خطا مواجه شد";
            }
        }

        private async Task UpdateCategory()
        {
            var result = await categoryRepository.UpdateCategory(this.category);
            this.ShowMessage = true;
            if (result.Success)
            {
                if (result.Response)
                {
                    Message = "عملیات با موفقیت انجام شد";
                }
                else
                {
                    Message = "انجام عملیات با خطا مواجه شد";
                }
            }
            else
            {
                Message = "خطایی رخ داد لطفا مجددا تلاش نمایید";
            }
        }
    }
}
