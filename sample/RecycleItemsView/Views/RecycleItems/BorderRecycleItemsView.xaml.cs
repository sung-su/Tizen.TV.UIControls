using System;

using Xamarin.Forms;

using RecycleItemsView.Services;

namespace RecycleItemsView.Views.RecycleItems
{
    public partial class BorderRecycleItemsView : Tizen.TV.UIControls.Forms.RecycleItemsView
    {
        public BorderRecycleItemsView()
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

                Frame border = (Frame)layout.Children[0];
                if (isFocused)
                {
                    border.IsVisible = true;
                    layout.ScaleTo(1.2, 200);
                }
                else
                {
                    border.IsVisible = false;
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