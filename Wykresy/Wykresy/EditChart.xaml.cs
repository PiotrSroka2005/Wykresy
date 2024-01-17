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
    }
}