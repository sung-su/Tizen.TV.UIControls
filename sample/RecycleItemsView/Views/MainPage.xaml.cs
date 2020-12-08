using System;
using System.Collections;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using RecycleItemsView.Models;
using RecycleItemsView.Services;


namespace RecycleItemsView.Views
{
    public partial class MainPage : ContentPage
    {
        private IEnumerable _wideItems;
        private IEnumerable _narrowItems;
        private IEnumerable _settingItems;
        private IEnumerable _squareItems;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            UpdateItems();
        }

        public IEnumerable WideItems
        {
            get => _wideItems;
            set => Set(ref _wideItems, value);
        }

        public IEnumerable NarrowItems
        {
            get => _narrowItems;
            set => Set(ref _narrowItems, value);
        }

        public IEnumerable SettingItems
        {
            get => _settingItems;
            set => Set(ref _settingItems, value);
        }

        public IEnumerable SquareItems
        {
            get => _squareItems;
            set => Set(ref _squareItems, value);
        }

        public void UpdateItems()
        {
            WideItems = SampleDataService.WideItems();
            NarrowItems = SampleDataService.NarrowItems();
            SettingItems = SampleDataService.SettingItems();
            SquareItems = SampleDataService.SquareItems();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Tizen.TV.UIControls.Forms.RecycleItemsView recycleView = sender as Tizen.TV.UIControls.Forms.RecycleItemsView;

            if (e.SelectedItem is RecycleItem item)
            {
                Logger.Info(item.Title + "is selected");
            }
            else if (e.SelectedItem == recycleView.Header)
            {
                Logger.Info("Header is selected");
            }
            else if (e.SelectedItem == recycleView.Footer)
            {
                Logger.Info("Footer is selected");
            }
        }

        private bool Set<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(property, value))
            {
                return false;
            }

            property = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}

