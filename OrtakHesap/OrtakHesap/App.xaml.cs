using Xamarin.Forms;

namespace OrtakHesap
{
    public partial class App : Application
    {
        public MainPage _mainPage;
        public SettingsPage _settingsPage;
        public ToDoPage _toDoPage;
        public BaseColorViewModel _colorViewModel;
        public App()
        {
            InitializeComponent();
            _mainPage = new MainPage();
            _settingsPage = new SettingsPage();
            _colorViewModel = new BaseColorViewModel();
            _toDoPage = new ToDoPage();
            _mainPage.BindingContext = _colorViewModel;
            _settingsPage.BindingContext = _colorViewModel;
            _toDoPage.BindingContext = _colorViewModel;

            //MainPage = _mainPage;
            MainPage = _settingsPage;
        }

        public void OpenSettingsPage()
        {
            MainPage = _settingsPage;
        }
        public void OpenMainPage()
        {
            MainPage = _mainPage;
        }
        public void OpenToDoPage()
        {
            MainPage = _toDoPage;
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
    }
}
