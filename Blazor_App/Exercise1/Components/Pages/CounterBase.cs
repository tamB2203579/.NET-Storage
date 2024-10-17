using Microsoft.AspNetCore.Components;

namespace Exercise1.Components.Pages;

public class CounterBase:ComponentBase{
    public int currentCount = 0;
    [Parameter]
    public int IncrementAmount {get ; set; } = 1;
    public void IncrementCount(){
        currentCount++;
    }
}