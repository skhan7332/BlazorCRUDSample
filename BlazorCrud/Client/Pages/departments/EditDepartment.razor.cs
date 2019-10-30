using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;
using BlazorCrud.Shared.Model;
using Microsoft.AspNetCore.Components;
using BlazorCrud.Client.Utils;

namespace BlazorCrud.Client.Pages.departments
{
    public class EditDepartmentBase : ComponentBase
    {
        [Inject] private HttpClient Http { get; set; }
        private Timer _timer;

        protected bool IsShowAlert { get; set; }

        [Parameter]
        public string DepartmentId { get; set; }

        protected Department Department;

        protected EditDepartmentBase()
        {
            Department = new Department();
            _timer = new Timer(5000);
            _timer.Elapsed += HideSuccess;
            _timer.AutoReset = false;
        }

        protected override async Task OnInitializedAsync()
        {
            if (long.TryParse(DepartmentId, out var departmentId) && departmentId <= 0)
                return;

            Department = await Http.GetJsonAsync<Department>($"getById?id={departmentId}", "Department");
        }

        protected async Task UpdateDepartment()
        {
            Department = await Http.PutJsonAsync<Department>("/api/Department/updateDepartment", Department);
            
            StartTimer();
            IsShowAlert = true;
        }

        protected void ShowSuccess() => IsShowAlert = true;

        protected void HideSuccess(object source, ElapsedEventArgs args)
        {
            IsShowAlert = false;
            this.StateHasChanged();
        }

        private void StartTimer()
        {
            if (_timer.Enabled)
                _timer.Stop();

            _timer.Start();
        }
    }
}
