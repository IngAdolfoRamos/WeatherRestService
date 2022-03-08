using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherRestService.Models;
using Xamarin.Forms;

namespace WeatherRestService.ViewModels
{
    public class WeatherPageViewModel
    {
        public WeatherData Data { get; set; }

        public ICommand SearchCommand { get; set; }


        public WeatherPageViewModel()
        {
            SearchCommand = new Command(async async =>
            {
                await GetData("https://api.weatherbit.io/v2.0/current?postal_code=56900&key=372c879b4eb74ee7813e9c363e1d25c6");
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
