using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YourContacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        private async void HiperLink_Tapped(object sender, EventArgs e)
        {
            await Browser.OpenAsync(new Uri("https://randomuser.me/"), BrowserLaunchMode.SystemPreferred);
        }
    }
}