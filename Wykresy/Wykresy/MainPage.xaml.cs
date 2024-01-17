using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wykresy
{
    public partial class MainPage : TabbedPage
    {
        public static List<ChartData> ChartData { get; set; }
        public static string Title = "Wykres danych";
        private Color[] Colors = { Color.Red, Color.Blue, Color.Orange, Color.Green, Color.Purple, Color.Gray };
        private Brush[] Brushes = { Brush.Red, Brush.Blue, Brush.Orange, Brush.Green, Brush.Purple, Brush.Gray };


        public MainPage()
        {
            InitializeComponent();
        }
    }
}
