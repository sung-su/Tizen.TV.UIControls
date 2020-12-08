using System;

using Xamarin.Forms;

using RecycleItemsView.Services;

namespace RecycleItemsView.Views.RecycleItems
{
    public partial class BoldTextRecycleItemsView : Tizen.TV.UIControls.Forms.RecycleItemsView
    {
        public BoldTextRecycleItemsView()
        {
            InitializeComponent();
        }

        protected override void OnItemFocused(object data, View targetView, bool isFocused)
        {
            try
            {
                Frame frame = targetView as Frame;
                if (frame == null)
                {
                    return;
                }

                Grid grid = (Grid)frame.Content;
                foreach (var c in grid.Children)
                {
                    if (c is Label)
                    {
                        if (isFocused)
                        {
                            (c as Label).FontAttributes = FontAttributes.Bold;
                        }
                        else
                        {
                            (c as Label).FontAttributes = FontAttributes.None;
                        }
                    }
                }

                if (isFocused)
                {
                    frame.ScaleTo(1.2, 200);
                }
                else
                {
                    frame.ScaleTo(1.0, 200);
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