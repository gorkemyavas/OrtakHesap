using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrtakHesap
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public App CurrentApp;

        public SettingsPage()
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

        private void ChangeBaseColor(object sender, EventArgs e)
        {
            var baseColorViewModel = (Application.Current.MainPage.BindingContext as AppSettingsViewModel);
            var hex = (sender as Button).BackgroundColor.ToHex().Remove(0, 3);
            switch (hex)
            {
                case "2EC7A2":
                    baseColorViewModel.BaseColor =
                        Color.FromHex("#2EC7A2");
                    baseColorViewModel.SecondColor =
                        Color.FromHex("#A1B52C");
                    baseColorViewModel.ThirdColor =
                        Color.FromHex("#59E7C4");
                    break;
                case "7B61FF":
                    baseColorViewModel.BaseColor =
                        Color.FromHex("#7B61FF");
                    baseColorViewModel.SecondColor =
                        Color.FromHex("#5462D8");
                    baseColorViewModel.ThirdColor =
                        Color.FromHex("#9088B9");
                    break;
                case "3270BA":
                    baseColorViewModel.BaseColor =
                        Color.FromHex("#3270BA");
                    baseColorViewModel.SecondColor =
                        Color.FromHex("#14BCC7");
                    baseColorViewModel.ThirdColor =
                        Color.FromHex("#5D99DE");
                    break;
            }


        }

        private void SaveButton(object sender, EventArgs e)
        {
            CurrentApp.personCount = Convert.ToInt32(PersonCount.Text);
            CurrentApp.UpdateApplication();
        }
    }
}