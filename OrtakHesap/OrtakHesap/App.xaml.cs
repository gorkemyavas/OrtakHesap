using Xamarin.Forms;

namespace OrtakHesap
{
    public partial class App : Application
    {
        public MainPage _mainPage;
        public SettingsPage _settingsPage;
        public AppSettingsViewModel _colorViewModel;
        public int personCount = 3;
        public App()
        {
            InitializeComponent();
            _mainPage = new MainPage();
            _settingsPage = new SettingsPage();
            _colorViewModel = new AppSettingsViewModel();
            _mainPage.BindingContext = _colorViewModel;
            _settingsPage.BindingContext = _colorViewModel;

            MainPage = _mainPage;
            //MainPage = _settingsPage;
        }

        public void OpenSettingsPage()
        {
            MainPage = _settingsPage;
        }
        public void OpenMainPage()
        {
            MainPage = _mainPage;
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public void UpdateApplication()
        {
            _mainPage = new MainPage();
            _settingsPage = new SettingsPage();
            _mainPage.BindingContext = _colorViewModel;
            _settingsPage.BindingContext = _colorViewModel;

        }
    }
}
