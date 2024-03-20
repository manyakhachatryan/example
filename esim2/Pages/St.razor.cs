using BusinessLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Telerik.Blazor.Components;
using static BusinessLayer.Entities.Student;

namespace esim2.Pages
{
    public class StM : ComponentBase
    {
        protected TelerikGrid<Student> Grid { get; set; }
        protected int? ID { get; set; }
        protected int? Age { get; set; }
        protected int? Grade { get; set; }

        protected Student st { get; set; } = new Student();
        public bool ExportAllPages { get; set; }
        protected Student? itemForDeleted { get; set; }
        public Student? Total { get; set; }
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        protected EducationT EducationType { get; set; }

        protected bool WindowIsVisible { get; set; }
        protected int? UniversityID { get; set; }

        [Parameter]
        public int? UID { get; set; }
        protected int? selectedValue { get; set; }

        protected List<University> Universities { get; set; }

        protected List<EducationT> EduType { get; set; }
        protected async Task ReadItems(GridReadEventArgs args)
        {


            Student item = new Student();
            Total = new Student();
            Total = await Total.GetTotal();
 

            Universities = await new University().GetListAsync(null, null, null, null, 0, 0);
            if (UID != null)
                selectedValue = UID;
           
            args.Data = await item.GetListAsync(ID, FirstName, LastName, selectedValue, Age, Grade, ExportAllPages  ? 0: args.Request.Page - 1      , args.Request.PageSize, EducationType);


            args.Total = (int)item.RowCount;


        }


        protected async Task CreateHandler(GridCommandEventArgs args)
        {

            Student item = (Student)args.Item;
            await item.AddAsync();
        }

        protected async Task DeleteStudent()
        {

            await itemForDeleted.DeleteAsync();
            Grid.Rebind();
            WindowIsVisible = false;
        }

        protected async Task UpdateHandler(GridCommandEventArgs args)
        {
            Student item = (Student)args.Item;
            selectedValue = null;
            await item.EditAsync();
        }

        protected void RebindGrid()
        {
            UID = null;
            Grid.Page = 1;
            Grid.Rebind();
        }

        protected void HandleDeletePopUp(GridCommandEventArgs args)
        {
            WindowIsVisible = true;
            itemForDeleted = (Student)args.Item;
        }




        protected void OnRowRenderHandler(GridRowRenderEventArgs args)
        {
            Student item = args.Item as Student;

            if (item.Grade <= 3)
                args.Class = "negativeValuesRowFormatting";

        }
    }




}

