using Akavache;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFApp4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            BindingContext = new TestClass();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var viewmodel = (TestClass)BindingContext;
            try
            {
                var storedItems = await BlobCache.LocalMachine.GetObject<List<string>>("test");
                if (storedItems != null)
                {
                    foreach (var item in storedItems)
                    {
                        if (!viewmodel.Listado.Contains(item))
                            viewmodel.Listado.Add(item);
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                await BlobCache.LocalMachine.InsertObject<List<string>>("test", new List<string>());
                //               
            }
        }
    }
    public class TestClass
    {
        public TestClass()
        {
            Listado = new ObservableCollection<string>();
        }
        public ObservableCollection<string> Listado { get; set; }
    }
}