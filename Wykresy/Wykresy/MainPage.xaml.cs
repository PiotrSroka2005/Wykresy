using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

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
            ChartData = new List<ChartData>
            {
                new ChartData("Słupek 1", 11),
                new ChartData("Słupek 2", 2),
                new ChartData("Słupek 3", 91),
                new ChartData("Słupek 4", 3),
            };
        }

        private void WykresSlupkowy_Appearing(object sender, EventArgs e)
        {
            wykresSlupkowy.Children.Clear();
            wykresSlupkowy.ColumnDefinitions.Clear();
            wykresSlupkowy.RowDefinitions.Clear();
            for (int i = 0; i < ChartData.Count; i++)
                wykresSlupkowy.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            wykresSlupkowy.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            wykresSlupkowy.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Absolute) });
            wykresSlupkowy.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            Line horizontalLine = new Line
            {
                HeightRequest = 1,
                BackgroundColor = Color.Black
            };
            wykresSlupkowy.Children.Add(horizontalLine, 0, 1);
            if (ChartData.Count > 0)
            {
                
            }
            slupkowyLabel.Text = Title;
        }
    }
}
