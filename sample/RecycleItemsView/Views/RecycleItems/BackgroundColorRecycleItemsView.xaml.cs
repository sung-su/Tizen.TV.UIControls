using System;

using Xamarin.Forms;

using RecycleItemsView.Services;

namespace RecycleItemsView.Views.RecycleItems
{
    public partial class BackgroundColorRecycleItemsView : Tizen.TV.UIControls.Forms.RecycleItemsView
    {
        public static readonly BindableProperty FocusInColorProperty = BindableProperty.Create(nameof(FocusInColor), typeof(Color), typeof(BackgroundColorRecycleItemsView), Color.Default);

        public static readonly BindableProperty FocusOutColorProperty = BindableProperty.Create(nameof(FocusOutColor), typeof(Color), typeof(BackgroundColorRecycleItemsView), Color.Default);

        public BackgroundColorRecycleItemsView()
        {
            InitializeComponent();
        }

        public Color FocusInColor
        {
            get { return (Color)GetValue(FocusInColorProperty); }
            set { SetValue(FocusInColorProperty, value); }
        }

        public Color FocusOutColor
        {
            get { return (Color)GetValue(FocusOutColorProperty); }
            set { SetValue(FocusOutColorProperty, value); }
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

                if (isFocused)
                {
                    frame.BackgroundColor = FocusInColor;
                    frame.ScaleTo(1.2, 200);
                }
                else
                {
                    frame.BackgroundColor = FocusOutColor;
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