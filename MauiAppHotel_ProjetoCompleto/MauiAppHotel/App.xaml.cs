namespace MauiAppHotel;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new Views.ContratacaoHospedagem())
        {
            BarBackgroundColor = Color.FromArgb("#173F3A"),
            BarTextColor = Colors.White
        };
    }
}
