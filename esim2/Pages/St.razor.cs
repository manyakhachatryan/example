using BusinessLayer.Entities;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;

namespace esim2.Pages
{
    public class StM : ComponentBase
    {

        protected TelerikGrid<Student> Grid { get; set; }
        protected int? ID { get; set; }
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        protected int? UniversityID { get; set; }

        protected int? selectedValue { get; set; }
        protected List<University> univercities { get; set; }
        protected async Task ReadItems(GridReadEventArgs args)
        {
            Student item = new Student();
            univercities = await new University().GetListAsync(null, null, null, null);
            args.Data = await item.GetListAsync(ID, FirstName, LastName, selectedValue, args.Request.Page - 1, args.Request.PageSize);
            args.Total = (int)item.RowCount;
        }


        protected async Task CreateHandler(GridCommandEventArgs args)
        {
            Student item = (Student)args.Item;
            await item.AddAsync();
        }


        protected async Task DeleteHandler(GridCommandEventArgs args)
        {
            Student item = (Student)args.Item;
            await item.DeleteAsync();
        }

        protected async Task UpdateHandler(GridCommandEventArgs args)
        {
            Student item = (Student)args.Item;
            await item.EditAsync();
        }


        protected void RebindGrid()
        {
            Grid.Page = 1;
            Grid.Rebind();
        }
    }
}
