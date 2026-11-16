namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada(string suite, int adultos, int criancas,
        DateTime checkin, DateTime checkout, int noites)
    {
        InitializeComponent();

        lblSuite.Text = suite;
        lblHospedes.Text = $"{adultos} adulto(s) e {criancas} criança(s)";
        lblDatas.Text = $"{checkin:dd/MM/yyyy} até {checkout:dd/MM/yyyy}";
        lblNoites.Text = noites == 1 ? "1 noite" : $"{noites} noites";
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnAboutClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}
