namespace EventRegistration.View;

public partial class ContractedEvent : ContentPage
{
    public ContractedEvent()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new EventHiring());

        }
        catch (Exception ex)
        {
            // Display an error message if an exception occurs
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}