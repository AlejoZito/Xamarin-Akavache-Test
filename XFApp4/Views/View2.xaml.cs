using Akavache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFApp4.Views
{
    public partial class View2 : ContentPage
    {
        public View2()
        {
            InitializeComponent();
            boton.Clicked += Boton_Clicked;
        }

        private async void Boton_Clicked(object sender, EventArgs e)
        {
            busy.IsVisible = true;
            var text = input.Text;
            input.Text = "";
            var storedItems = await BlobCache.LocalMachine.GetObject<List<string>>("test");

            storedItems.Add(text);
            LogEvent(text);
            await BlobCache.LocalMachine.InsertObject<List<string>>("test", storedItems);
            busy.IsVisible = false;
        }

        private void LogEvent(string text)
        {
            Microsoft.Azure.Mobile.Analytics.Analytics.TrackEvent("Test", new Dictionary<string, string>()
            { { "Texto", text }
            });
        }
    }
}