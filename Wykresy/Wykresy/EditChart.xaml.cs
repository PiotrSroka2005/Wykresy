using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wykresy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditChart : ContentPage
    {
        public EditChart()
        {
            InitializeComponent();

            for (int i = 0; i < MainPage.ChartData.Count; i++)
            {
                (grid.Children[i] as Entry).Text = MainPage.ChartData[i].Name;
                (grid.Children[i + 4] as Entry).Text = MainPage.ChartData[i].Value.ToString();
            }
            titleEntry.Text = MainPage.Title;
        }

        private void Update_Chart(object sender, EventArgs e)
        {
            MainPage.ChartData = new List<ChartData>();

            for (int i = 0; i < 4; i++)
            {
                if (!string.IsNullOrWhiteSpace((grid.Children[i] as Entry).Text) && !string.IsNullOrWhiteSpace((grid.Children[i + 4] as Entry).Text))
                    MainPage.ChartData.Add(new ChartData((grid.Children[i] as Entry).Text, double.Parse((grid.Children[i + 4] as Entry).Text)));
            }
            if (string.IsNullOrWhiteSpace(titleEntry.Text))
                DisplayAlert("Błąd", "Podaj poprawną nazwe", "OK");
            else
            {
                MainPage.Title = titleEntry.Text;
                Navigation.PopAsync();
            }

        }
    }
}