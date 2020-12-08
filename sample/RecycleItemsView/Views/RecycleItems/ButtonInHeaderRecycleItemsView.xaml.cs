using System;
using System.Linq;

using Xamarin.Forms;

using RecycleItemsView.Services;

namespace RecycleItemsView.Views.RecycleItems
{
    public partial class ButtonInHeaderRecycleItemsView : Tizen.TV.UIControls.Forms.RecycleItemsView
    {
        public static readonly BindableProperty ButtonFocusOutColorProperty = BindableProperty.Create(nameof(ButtonFocusOutColor), typeof(Color), typeof(ButtonInHeaderRecycleItemsView), Color.Default);
        public static readonly BindableProperty ButtonFocusInColorProperty = BindableProperty.Create(nameof(ButtonFocusInColor), typeof(Color), typeof(ButtonInHeaderRecycleItemsView), Color.Default);

        public ButtonInHeaderRecycleItemsView()
        {
            InitializeComponent();
            Focused += (s, e) => { Console.WriteLine($"@@@@ ButtonInHeaderRecycleItemsView.Focused"); };
            Unfocused += (s, e) => { Console.WriteLine($"@@@@ ButtonInHeaderRecycleItemsView.Unfocused"); };
            ItemSelected += (s, e) => { Console.WriteLine($"@@@@ ButtonInHeaderRecycleItemsView.ItemSelected [{e.SelectedItemIndex}]"); };
        }

        public Color ButtonFocusInColor
        {
            get { return (Color)GetValue(ButtonFocusInColorProperty); }
            set { SetValue(ButtonFocusInColorProperty, value); }
        }

        public Color ButtonFocusOutColor
        {
            get { return (Color)GetValue(ButtonFocusOutColorProperty); }
            set { SetValue(ButtonFocusOutColorProperty, value); }
        }

        protected override void OnItemFocused(object data, View targetView, bool isFocused)
        {
            try
            {
                if (data == Header)
                {
                    Frame frame = targetView as Frame;
                    if (frame == null)
                    {
                        return;
                    }

                    Grid grid = (Grid)frame.Content;
                    Frame button = (Frame)grid.Children.FirstOrDefault(c => Grid.GetRow(c) == 2);
                    if (button == null)
                    {
                        return;
                    }

                    if (isFocused)
                    {
                        button.BackgroundColor = ButtonFocusInColor;
                    }
                    else
                    {
                        button.BackgroundColor = ButtonFocusOutColor;
                    }
                }
                else
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
                    }
                    else
                    {
                        border.IsVisible = false;
                    }
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