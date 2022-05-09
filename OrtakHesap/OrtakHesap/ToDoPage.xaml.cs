using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrtakHesap
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoPage : ContentPage
    {
        public App CurrentApp;
        public ToDoPage()
        {
            CurrentApp = Application.Current as App;
            InitializeComponent();
        }
        private void OpenMainPage(object sender, EventArgs e)
        {
            CurrentApp.OpenMainPage();
        }
        private void OpenSettings(object sender, EventArgs e)
        {
            CurrentApp.OpenSettingsPage();
        }
        private void OpenToDoPage(object sender, EventArgs e)
        {
            CurrentApp.OpenToDoPage();
        }
    }
}