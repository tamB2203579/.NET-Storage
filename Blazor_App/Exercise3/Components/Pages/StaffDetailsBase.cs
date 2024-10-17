using Exercise3.Data;
using Microsoft.AspNetCore.Components;

namespace Exercise3.Components.Pages;

public class StaffDetailBase : ComponentBase{
    public Employee staff {get; set;} = new Employee();
    [Inject]
    public IStaffRepository staffRepository {get; set;}
    [Parameter]
    public string Id {get; set;}
    protected async override Task OnInitializedAsync(){
        Id = Id ?? "1";
        staff = await staffRepository.GetStaff(int.Parse(Id));
    }
}