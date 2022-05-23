using OrtakHesap.Models;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrtakHesap
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpensePopup : PopupPage
    {
        public List<string> ExpenseTypes { get; set; }
        private ExpenseModel _expenseModel;
        public App CurrentApp;


        public AddExpensePopup()
        {
            CurrentApp = Application.Current as App;
            this._expenseModel = new ExpenseModel();
            BindingContext = _expenseModel;

            InitializeComponent();
        }

        private void AddExpense(object sender, EventArgs e)
        {
            var url = "http://deneme.biz/api/services/app/Expense/Create";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";

            var data = @"
    {
        ""name"": """ + _expenseModel.Name + @""",
        ""type"": """ + _expenseModel.Type + @""",
        ""date"": """ + DateTime.Now.ToLongDateString() + @""",
        ""amount"": " + _expenseModel.Amount + @"
    }";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                CurrentApp._mainPage.start_get();
                Navigation.RemovePopupPageAsync(this);
            }

            Console.WriteLine(httpResponse.StatusCode);
        }
    }
}