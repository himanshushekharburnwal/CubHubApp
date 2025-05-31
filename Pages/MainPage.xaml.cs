using CubHubApp.Models;
using CubHubApp.PageModels;

namespace CubHubApp.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}