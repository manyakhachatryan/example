using BusinessLayer.Entities;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;

namespace esim2.Pages
{
    public class UnM : ComponentBase
    {
        protected TelerikGrid<University> Grid { get; set; }
        protected int? ID { get; set; }
        protected string Name { get; set; }
        protected string Country { get; set; }
  
        protected string? City { get; set; }

        protected async Task ReadItems(GridReadEventArgs args)
        {
            University item = new University();
            args.Data = await item.GetListAsync(ID, Name, Country, City, args.Request.Page - 1, args.Request.PageSize);
            args.Total = (int)item.RowCount;
        }

        protected async Task CreateHandler(GridCommandEventArgs args)
        {
            University item = (University)args.Item;
            await item.AddAsync();
        }

        protected async Task DeleteHandler(GridCommandEventArgs args)
        {
            University item = (University)args.Item;
            await item.DeleteAsync();
        }


        protected async Task UpdateHandler(GridCommandEventArgs args)
        {
            University item = (University)args.Item;
            await item.EditAsync();
        }

        protected void RebindGrid()
        {
            Grid.Page = 1;
            Grid.Rebind();
        }

        protected void RedirectToDatebyPlayer(University item, NavigationManager navigationManager,  int? ID = null)
        {
            navigationManager.NavigateTo($"/students/{item.ID}");
        }
    }
}
