using Exercise3.Data;
using Microsoft.AspNetCore.Components;

namespace Exercise3.Components.Pages;

public class StaffListBase : ComponentBase{
    [Inject]
    public IStaffRepository staffRepository {get; set;}
    public IEnumerable<Employee> staffs {get; set;}
    protected override async Task OnInitializedAsync(){
        staffs = await staffRepository.GetAllStaffs();
    }
}