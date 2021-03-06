using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherRestService.Models;
using Xamarin.Forms;

namespace WeatherRestService.ViewModels
{
    public class WeatherPageViewModel : INotifyPropertyChanged
    {
        private WeatherData data;

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public WeatherData Data
        {
            get => data; set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; set; }


        public WeatherPageViewModel()
        {
            SearchCommand = new Command(async (zipCode) =>
            {

                //var entrada = zipCode as string;
                //var datos = entrada.Split(',');
                //var lat = datos[0];
                //var lon = datos[1];

                await GetData("https://api.weatherbit.io/v2.0/current?postal_code=" + zipCode + "&lang=es&key=372c879b4eb74ee7813e9c363e1d25c6");
            });
        }

        private async Task GetData(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WeatherData>(json);
            Data = result;
        }
    }
}
