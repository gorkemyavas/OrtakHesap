using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace OrtakHesap
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
            var a = new ListView();

            var people = new List<Expense>();
            for (int i = 1; i < 29; i++)
            {
                people.Add(new Expense()
                {
                    Name = "Market Harcaması",
                    Date = new DateTime(2022, 04, i),
                    Amount = i * ((i + 4) * i)
                });
            }
            EmployeeView.ItemsSource = people;
            //Content = a;
        }
    }

    public class Expense
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}