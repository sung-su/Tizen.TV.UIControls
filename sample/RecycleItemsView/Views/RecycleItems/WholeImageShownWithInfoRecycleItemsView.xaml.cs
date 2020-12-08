using System;

using Xamarin.Forms;

using RecycleItemsView.Services;

namespace RecycleItemsView.Views.RecycleItems
{
    public partial class WholeImageShownWithInfoRecycleItemsView : Tizen.TV.UIControls.Forms.RecycleItemsView
    {
        public WholeImageShownWithInfoRecycleItemsView()
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

                AbsoluteLayout imageLayout = (AbsoluteLayout)layout.Children[0];
                Frame frame = (Frame)imageLayout.Children[1];
                if (isFocused)
                {
                    var animation = new Animation((rate) =>
                    {
                        var origin = AbsoluteLayout.GetLayoutBounds(imageLayout);
                        AbsoluteLayout.SetLayoutBounds(imageLayout, new Rectangle(0.5, 0.5, 0.8 + rate * 0.2, 0.8 + rate * 0.2));
                        frame.Padding = new Thickness(25.0 + rate * 25.0, 25.0 + rate * 15.0);
                    });

                    animation.Commit(this, "WholeImageShownWithInfoAnimation");
                }
                else
                {
                    var animation = new Animation((rate) =>
                    {
                        var origin = AbsoluteLayout.GetLayoutBounds(imageLayout);
                        AbsoluteLayout.SetLayoutBounds(imageLayout, new Rectangle(0.5, 0.5, 1 - rate * 0.2, 1 - rate * 0.2));
                        frame.Padding = new Thickness(50.0 - rate * 25.0, 45.0 - rate * 15.0);
                    });

                    animation.Commit(this, "PartOfImageShownWithInfoAnimation");
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