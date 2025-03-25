using System.Threading.Tasks;

namespace MauiApp1.Views;

public partial class AboutPage1 : ContentPage
{
	public AboutPage1()
	{
		InitializeComponent();
	}
	private async void LearnMore_Clicked(object sender,EventArgs e)
	{
		if(BindingContext is Models.About about)
		await Launcher.Default.OpenAsync(about.MoreInfoUrl);
	}
}