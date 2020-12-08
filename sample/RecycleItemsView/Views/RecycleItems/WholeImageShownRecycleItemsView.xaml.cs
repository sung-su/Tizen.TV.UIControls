using System;

using Xamarin.Forms;

using RecycleItemsView.Services;

namespace RecycleItemsView.Views.RecycleItems
{
    public partial class WholeImageShownRecycleItemsView : Tizen.TV.UIControls.Forms.RecycleItemsView
    {
        public WholeImageShownRecycleItemsView()
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
                if (isFocused)
                {
                    var animation = new Animation((rate) =>
                    {
                        var origin = AbsoluteLayout.GetLayoutBounds(imageLayout);
                        AbsoluteLayout.SetLayoutBounds(imageLayout, new Rectangle(0.5, 0.5, rate, rate));
                    }, 0.8, 1.0);

                    animation.Commit(this, "WholeImageShownAnimation");
                }
                else
                {
                    var animation = new Animation((rate) =>
                    {
                        var origin = AbsoluteLayout.GetLayoutBounds(imageLayout);
                        AbsoluteLayout.SetLayoutBounds(imageLayout, new Rectangle(0.5, 0.5, 1.8 - rate, 1.8 - rate));
                    }, 0.8, 1.0);

                    animation.Commit(this, "PartOfImageShownAnimation");
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