using CubHubApp.ViewModels;

namespace CubHubApp.Pages;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
        BindingContext = new SignupViewModel();


    }
}