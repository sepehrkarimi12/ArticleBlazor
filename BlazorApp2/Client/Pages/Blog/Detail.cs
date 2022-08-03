using Microsoft.AspNetCore.Components;

namespace BlazorApp2.Client.Pages.Blog
{
    public partial class Detail
    {
        [Parameter]
        public int Id { get; set; }
    }
}
