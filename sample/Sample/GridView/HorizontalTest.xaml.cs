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
    public partial class HorizontalTest : ContentPage
    {
        public HorizontalTest()
        {
            InitializeComponent();
            //Xamarin.Forms.PlatformConfiguration.TizenSpecific.ItemsView.SetFocusedItemScrollPosition(collectionview, ScrollToPosition.Center);
            Xamarin.Forms.PlatformConfiguration.TizenSpecific.ItemsView.SetFocusedItemScrollPosition(collectionview2, ScrollToPosition.Center);
            Xamarin.Forms.PlatformConfiguration.TizenSpecific.ItemsView.SetFocusedItemScrollPosition(collectionview3, ScrollToPosition.Center);
            /*
            var collectionView2 = new CollectionView
            {
                BackgroundColor = Color.LightPink,
                WidthRequest = 800,
                HeightRequest = 800,
                ItemSizingStrategy = ItemSizingStrategy.MeasureFirstItem,
                ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal) { ItemSpacing = 10, },
                ItemTemplate = new DataTemplate(typeof(ItemsView)),
                ItemsSource = PosterModel.MakeAlbumArtsModel(),
            };
            stack.Children.Add(collectionview);
            Xamarin.Forms.PlatformConfiguration.TizenSpecific.ItemsView.SetFocusedItemScrollPosition(collectionView2, ScrollToPosition.Center);
            */
        }
        void FrameFocused(object sender, FocusEventArgs e)
        {
            var f = sender as Frame;
            f.ScaleTo(1.2);
        }
        void FrameUnFocused(object sender, FocusEventArgs e)
        {
            var f = sender as Frame;
            f.ScaleTo(1.0);
        }
    }
}