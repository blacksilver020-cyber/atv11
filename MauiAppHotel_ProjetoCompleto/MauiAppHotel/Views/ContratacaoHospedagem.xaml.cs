namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    public ContratacaoHospedagem()
    {
        InitializeComponent();

        pck_quarto.ItemsSource = new List<string>
        {
            "Suíte Jardim",
            "Suíte Vista Mar",
            "Suíte Premium"
        };
        pck_quarto.SelectedIndex = 0;

        dtpck_checkin.MinimumDate = DateTime.Today;
        dtpck_checkin.Date = DateTime.Today;
        dtpck_checkout.MinimumDate = DateTime.Today.AddDays(1);
        dtpck_checkout.Date = DateTime.Today.AddDays(2);
    }

    private void OnAdultsChanged(object sender, ValueChangedEventArgs e)
    {
        lblAdultos.Text = e.NewValue.ToString("0");
    }

    private void OnChildrenChanged(object sender, ValueChangedEventArgs e)
    {
        lblCriancas.Text = e.NewValue.ToString("0");
    }

    private void OnCheckInDateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime minimumCheckout = e.NewDate.Date.AddDays(1);
        dtpck_checkout.MinimumDate = minimumCheckout;

        if (dtpck_checkout.Date.Date < minimumCheckout)
        {
            dtpck_checkout.Date = minimumCheckout;
        }
    }

    private async void OnBookingClicked(object sender, EventArgs e)
    {
        if (dtpck_checkout.Date.Date <= dtpck_checkin.Date.Date)
        {
            await DisplayAlert("Período inválido",
                "A data de check-out precisa ser posterior à data de check-in.", "OK");
            return;
        }

        string suite = pck_quarto.SelectedItem?.ToString() ?? "Suíte Jardim";
        int adultos = (int)stp_adultos.Value;
        int criancas = (int)stp_criancas.Value;
        int noites = (dtpck_checkout.Date.Date - dtpck_checkin.Date.Date).Days;

        await Navigation.PushAsync(new HospedagemContratada(
            suite, adultos, criancas, dtpck_checkin.Date, dtpck_checkout.Date, noites));
    }

    private async void OnAboutClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}
