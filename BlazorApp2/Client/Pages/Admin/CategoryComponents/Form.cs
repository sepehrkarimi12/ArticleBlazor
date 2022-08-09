using BlazorApp2.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorApp2.Client.Pages.Admin.CategoryComponents
{
    public partial class Form
    {
        [Parameter]
        public Category Category { get; set; }
        [Parameter]
        public EventCallback SubmitCallBack { get; set; }
    }
}
