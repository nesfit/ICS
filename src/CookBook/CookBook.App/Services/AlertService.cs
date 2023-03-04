namespace CookBook.App.Services;

public class AlertService : IAlertService
{
    public async Task DisplayAsync(string title, string message)
    {
        var displayAlert = Application.Current?.MainPage?.DisplayAlert(title, message, "OK");
        
        if (displayAlert is not null)
        {
            await displayAlert;
        }
    }
}
