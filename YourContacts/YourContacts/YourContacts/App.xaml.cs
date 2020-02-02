using Prism;
using Prism.Ioc;
using YourContacts.ViewModels;
using YourContacts.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace YourContacts
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var User = await SecureStorage.GetAsync("Username");
            var Password = await SecureStorage.GetAsync("Password");

            if (String.IsNullOrEmpty(User) || String.IsNullOrEmpty(Password))
            {
                await NavigationService.NavigateAsync($"{Constants.Navigation}/{Constants.SetUp}");
            }else
                await NavigationService.NavigateAsync($"{Constants.Navigation}/{Constants.Login}");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<SetUpPage, SetUpPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
