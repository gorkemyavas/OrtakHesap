using Newtonsoft.Json;
using OrtakHesap.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.IO;
using System.Net;
using Xamarin.Forms;

namespace OrtakHesap
{
    public partial class MainPage : ContentPage
    {
        public App CurrentApp;

        public MainPage()
        {
            CurrentApp = Application.Current as App;
            InitializeComponent();

            start_get();
        }

        public void OpenAddExpensePopup(object sender, EventArgs eventArgs)
        {
            PopupNavigation.Instance.PushAsync(new AddExpensePopup());
            //MainStackLayout.Children.Add(new AbsoluteLayout()
            //{
            //    Children =
            //    {
            //        new Frame()
            //        {
            //            BackgroundColor = Color.Aqua,
            //            WidthRequest = 50,
            //            HeightRequest = 50,
            //            VerticalOptions = LayoutOptions.Center,
            //            HorizontalOptions = LayoutOptions.Center
            //        }
            //    }
            //});

        }


        private void OpenSettings(object sender, EventArgs e)
        {
            CurrentApp.OpenSettingsPage();
        }
        private void OpenToDoPage(object sender, EventArgs e)
        {
            CurrentApp.OpenToDoPage();
        }

        private void OpenMainPage(object sender, EventArgs e)
        {
            CurrentApp.OpenMainPage();
        }
        public void start_get()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://deneme.biz/api/services/app/Expense/GetAll"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            PagedResponseDto<ExpenseModel> items = JsonConvert.DeserializeObject<PagedResponseDto<ExpenseModel>>(jsonString);

            foreach (var item in items.Result.Items)
            {
                switch (item.Type)
                {
                    case ExpenseType.Market:
                        item.Image = "Basket.png";
                        break;
                }
            }

            EmployeeView.ItemsSource = items.Result.Items;
            double totalExpense = 0;
            foreach (var expenseModel in items.Result.Items)
            {
                totalExpense += expenseModel.Amount;
            }

            TotalExpenseLabel.Text = totalExpense + " TL";
            PersonExpenseLabel.Text = (totalExpense / CurrentApp.personCount).ToString().Split('.')[0] + " TL";
        }

        private void DeleteExpense(object sender, EventArgs e)
        {
            int expenseId = Convert.ToInt32(((Button)sender).BindingContext);
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://deneme.biz/api/services/app/Expense/Delete?Id=" + expenseId));

            WebReq.Method = "DELETE";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
                this.start_get();
            }
        }
    }

}