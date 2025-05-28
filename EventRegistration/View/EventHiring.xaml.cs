namespace EventRegistration.View;

public partial class EventHiring : ContentPage
{
    public EventHiring()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Parabens por contratar o evento", "O evento foi contratado com sucesso!", "OK");

        Navigation.PushAsync(new ContractedEvent());
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ContractedEvent()); // Navigate back to the previous page
    }
}
