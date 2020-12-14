using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.GridView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataTemplateTest : ContentPage
    {
        public DataTemplateTest()
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.TizenSpecific.ItemsView.SetFocusedItemScrollPosition(collectionview, ScrollToPosition.Center);
        }
    }
}