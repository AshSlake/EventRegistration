namespace EventRegistration.View;
using EventRegistration.Model;

public partial class ContractedEvent : ContentPage
{

    App appPropriety;
    public ContractedEvent()
    {
        InitializeComponent();
        if (Application.Current == null) //Verifica se a instancia da aplicação atual é nula.
        {
            throw new Exception("Erro Aplicação nula");
        }
        appPropriety = (App)Application.Current; //Atribui a instancia da aplicação atual a uma variavel do tipo App.

        start_data_event.MinimumDate = DateTime.Now; //Define a data minima do evento como a data atual.
        start_data_event.MaximumDate = DateTime.Now.AddYears(1); //Define a data maxima do evento como a data atual mais um ano.

        end_data_event.MinimumDate = start_data_event.Date.AddDays(1); //Define a data minima do evento como a data de inicio mais um dia.
        end_data_event.MaximumDate = start_data_event.Date.AddMonths(6);//Define a data maxima do evento como a data de inicio mais seis meses.
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
#pragma warning disable CS8604 // Possível argumento de referência nula,já tratado na classe.
            Event evento = new Event(campo_nome_evento.Text,
                start_data_event.Date,
                end_data_event.Date,
                int.Parse(numberOfAttendees.Text),
                location.Text,
                45,
                15);
            await Navigation.PushAsync(new EventHiring()
            {
                BindingContext = evento // Define o contexto de vinculação da página de contratação do evento como o evento criado.
            });
            Navigation.RemovePage(this);
        }
        catch (Exception ex)
        {
            // Display an error message if an exception occurs
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}