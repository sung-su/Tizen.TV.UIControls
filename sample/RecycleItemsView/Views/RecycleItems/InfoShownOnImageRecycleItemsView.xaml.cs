using System;

using Xamarin.Forms;

using RecycleItemsView.Services;

namespace RecycleItemsView.Views.RecycleItems
{
    public partial class InfoShownOnImageRecycleItemsView : Tizen.TV.UIControls.Forms.RecycleItemsView
    {
        public InfoShownOnImageRecycleItemsView()
        {
            InitializeComponent();
        }

        protected override void OnItemFocused(object data, View targetView, bool isFocused)
        {
            try
            {
                AbsoluteLayout layout = targetView as AbsoluteLayout;
                if (layout == null)
                {
                    return;
                }

                //StackLayout info = (StackLayout)layout.Children[1];
                StackLayout info = layout.FindByName<StackLayout>("DetailsLayout");
                if (info == null)
                {
                    return;
                }

                if (isFocused)
                {
                    info.IsVisible = true;
                    layout.ScaleTo(1.2, 200);
                }
                else
                {
                    info.IsVisible = false;
                    layout.ScaleTo(1.0, 200);
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                Logger.Error(ex.ToString());
            }
        }
    }
}