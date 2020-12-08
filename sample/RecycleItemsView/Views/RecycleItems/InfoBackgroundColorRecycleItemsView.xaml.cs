using System;
using System.Linq;

using Xamarin.Forms;

using RecycleItemsView.Services;


namespace RecycleItemsView.Views.RecycleItems
{
    public partial class InfoBackgroundColorRecycleItemsView : Tizen.TV.UIControls.Forms.RecycleItemsView
    {
        public static readonly BindableProperty FocusInColorProperty = BindableProperty.Create(nameof(FocusInColor), typeof(Color), typeof(BackgroundColorRecycleItemsView), Color.Default);
        public static readonly BindableProperty FocusOutColorProperty = BindableProperty.Create(nameof(FocusOutColor), typeof(Color), typeof(BackgroundColorRecycleItemsView), Color.Default);
        public static readonly BindableProperty TitleFocusInColorProperty = BindableProperty.Create(nameof(TitleFocusInColor), typeof(Color), typeof(BackgroundColorRecycleItemsView), Color.Default);
        public static readonly BindableProperty TitleFocusOutColorProperty = BindableProperty.Create(nameof(TitleFocusOutColor), typeof(Color), typeof(BackgroundColorRecycleItemsView), Color.Default);

        public InfoBackgroundColorRecycleItemsView()
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

        public Color TitleFocusInColor
        {
            get { return (Color)GetValue(TitleFocusInColorProperty); }
            set { SetValue(TitleFocusInColorProperty, value); }
        }

        public Color TitleFocusOutColor
        {
            get { return (Color)GetValue(TitleFocusOutColorProperty); }
            set { SetValue(TitleFocusOutColorProperty, value); }
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
                // Label title = (Label)grid.Children.FirstOrDefault(c => Grid.GetRow(c) == 1);
                Label title = grid.FindByName<Label>("Title");
                if (title == null)
                {
                    return;
                }

                if (isFocused)
                {
                    title.TextColor = TitleFocusInColor;
                    frame.BackgroundColor = FocusInColor;
                    frame.ScaleTo(1.2, 200);
                }
                else
                {
                    title.TextColor = TitleFocusOutColor;
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