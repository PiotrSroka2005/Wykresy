﻿using System;
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
        public static List<ChartData> DataOfCharts { get; set; }
        public static string Title = "Wykres danych";
        private Color[] Colors = { Color.Purple, Color.Brown, Color.Black, Color.Green};
        private Brush[] Brushes = { Brush.Purple, Brush.Brown, Brush.Black, Brush.Green};


        public MainPage()
        {
            InitializeComponent();
            DataOfCharts = new List<ChartData>
            {
                new ChartData("Słupek 1", 11),
                new ChartData("Słupek 2", 2),
                new ChartData("Słupek 3", 91),
                new ChartData("Słupek 4", 3),
            };
        }

        private void WykresSlupkowy_Odswiez(object sender, EventArgs e)
        {
            wykresSlupkowy.Children.Clear();
            wykresSlupkowy.ColumnDefinitions.Clear();
            wykresSlupkowy.RowDefinitions.Clear();
            for (int i = 0; i < DataOfCharts.Count; i++)
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
            if (DataOfCharts.Count > 0)
            {
                Grid.SetColumnSpan(horizontalLine, DataOfCharts.Count);
                double max = DataOfCharts.Max(x => x.Value);
                for (int i = 0; i < DataOfCharts.Count; i++)
                {
                    StackLayout stackLayout = new StackLayout
                    {
                        BackgroundColor = Colors[i],
                        Margin = new Thickness(10),
                        HeightRequest = DataOfCharts[i].Value / max * 700,
                        VerticalOptions = LayoutOptions.End,
                    };
                    Label label = new Label
                    {
                        TextColor = Color.White,
                        HorizontalOptions = LayoutOptions.Center,
                        Text = DataOfCharts[i].Value.ToString()
                    };
                    stackLayout.Children.Add(label);
                    Label title = new Label
                    {
                        FontSize = 17,
                        HorizontalOptions = LayoutOptions.Center,
                        Text = DataOfCharts[i].Name
                    };
                    wykresSlupkowy.Children.Add(stackLayout, i, 0);
                    wykresSlupkowy.Children.Add(title, i, 2);
                }
            }
            slupkowyNazwa.Text = Title;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditChart());
        }
    }
}
