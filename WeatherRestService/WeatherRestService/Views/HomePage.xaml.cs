using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherRestService.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherRestService.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            BindingContext = new WeatherPageViewModel();
        }
    }
}