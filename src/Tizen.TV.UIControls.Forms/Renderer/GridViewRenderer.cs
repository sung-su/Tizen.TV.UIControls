﻿/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using ElmSharp;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Tizen.TV.UIControls.Forms;
using Tizen.TV.UIControls.Forms.Renderer;

[assembly: ExportRenderer(typeof(GridView), typeof(GridViewRenderer))]
namespace Tizen.TV.UIControls.Forms.Renderer
{
    class GengridItemContext
    {
        public object Data { get; set; }
        public View RealizedView { get; set; }
    }

    public class GridViewRenderer : ViewRenderer<GridView, GenGrid>
    {
        Dictionary<object, GenGridItem> _gengridItemDic = new Dictionary<object, GenGridItem>();
        Dictionary<IntPtr, GenGridItem> _itemContextDic = new Dictionary<IntPtr, GenGridItem>();
        INotifyCollectionChanged _collectionChanged = null;

        GenItemClass gridItemClass = new GenItemClass("full")
        {
            GetContentHandler = (obj, part) =>
            {
                GengridItemContext context = (GengridItemContext)obj;

                if (part == "elm.swallow.icon")
                {
                    var renderer = Platform.GetOrCreateRenderer(context.RealizedView);

                    if (renderer is LayoutRenderer)
                    {
                        (renderer as LayoutRenderer).RegisterOnLayoutUpdated();
                    }
                    return renderer.NativeView;
                }
                return null;
            }
        };

        protected override void OnElementChanged(ElementChangedEventArgs<GridView> e)
        {
            if (Control == null)
            {
                SetNativeControl(new GenGrid(Xamarin.Forms.Forms.NativeParent));
                Control.ItemSelected += OnItemSelected;
                Control.HorizontalScrollBarVisiblePolicy = Element.HorizontalScrollBarVisible ? ElmSharp.ScrollBarVisiblePolicy.Visible : ScrollBarVisiblePolicy.Invisible;
                Control.VerticalScrollBarVisiblePolicy = Element.VerticalScrollBarVisible ? ElmSharp.ScrollBarVisiblePolicy.Visible : ScrollBarVisiblePolicy.Invisible;
                Control.IsHorizontal = Element.Orientation == GridViewOrientation.Horizontal ? true : false;
                Control.ItemWidth = Element.ItemWidth;
                Control.ItemHeight = Element.ItemHeight;
                Control.ItemAlignmentX = Element.ItemHorizontalAlignment;
                Control.ItemAlignmentY = Element.ItemVerticalAlignment;
                Control.Style = Element.ThemeStyle;
                Control.ItemSelected += OnItemSelected;
                Control.ItemRealized += OnItemRealized;

                SmartEvent<GenGridItemEventArgs> _focused = new SmartEvent<GenGridItemEventArgs>(Control, Control.RealHandle, "item,focused", OnSmartEvent);
                SmartEvent<GenGridItemEventArgs> _unfocused = new SmartEvent<GenGridItemEventArgs>(Control, Control.RealHandle, "item,unfocused", OnSmartEvent);
                _focused.On += OnItemFocused;
                _unfocused.On += OnItemUnfocused;

                if (Element.ItemsSource != null)
                {
                    UpdateItemsSource();
                }
            }
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == GridView.ItemWidthProperty.PropertyName)
            {
                Control.ItemWidth = Element.ItemWidth;
            }
            else if (e.PropertyName == GridView.ItemHeightProperty.PropertyName)
            {
                Control.ItemHeight = Element.ItemHeight;
            }
            else if (e.PropertyName == GridView.ItemVerticalAlignmentProperty.PropertyName)
            {
                Control.ItemAlignmentX = Element.ItemVerticalAlignment;
            }
            else if (e.PropertyName == GridView.ItemHorizontalAlignmentProperty.PropertyName)
            {
                Control.ItemAlignmentY = Element.ItemHorizontalAlignment;
            }
            else if (e.PropertyName == GridView.HorizontalScrollBarVisibleProperty.PropertyName)
            {
                Control.HorizontalScrollBarVisiblePolicy =
                    Element.HorizontalScrollBarVisible ? ElmSharp.ScrollBarVisiblePolicy.Visible : ScrollBarVisiblePolicy.Invisible;
            }
            else if (e.PropertyName == GridView.VerticalScrollBarVisibleProperty.PropertyName)
            {
                Control.VerticalScrollBarVisiblePolicy =
                    Element.VerticalScrollBarVisible ? ElmSharp.ScrollBarVisiblePolicy.Visible : ScrollBarVisiblePolicy.Invisible;
            }
            else if (e.PropertyName == GridView.OrientationProperty.PropertyName)
            {
                Control.IsHorizontal = Element.Orientation == GridViewOrientation.Horizontal ? true : false;
            }
            else if (e.PropertyName == GridView.ItemsSourceProperty.PropertyName)
            {
                UpdateItemsSource();
            }
            else if (e.PropertyName == GridView.SelectedItemProperty.PropertyName)
            {
                UpdateSelectedItem();
            }
            base.OnElementPropertyChanged(sender, e);
        }

        protected override void UpdateThemeStyle()
        {
            Control.Style = Element.ThemeStyle;
        }

        void OnItemSelected(object sender, GenGridItemEventArgs e)
        {
            GengridItemContext context = e.Item.Data as GengridItemContext;
            Element.SelectedItem = context.Data;
        }

        void OnItemUnfocused(object sender, GenGridItemEventArgs e)
        {
            if (e.Item == null)
                return;

            GengridItemContext context = e.Item.Data as GengridItemContext;
            (Element as IGridViewController)?.SendItemFocused(new GridViewFocusedEventArgs(context.Data, context.RealizedView, false));
        }

        void OnItemFocused(object sender, GenGridItemEventArgs e)
        {
            if (e.Item == null)
                return;

            GengridItemContext context = e.Item.Data as GengridItemContext;
            (Element as IGridViewController)?.SendItemFocused(new GridViewFocusedEventArgs(context.Data, context.RealizedView, true));
        }
        void OnItemRealized(object sender, GenGridItemEventArgs e)
        {
            e.Item.EmitSignal("elm,state,5p,scale", "");
            e.Item.SetPartColor("effect", new ElmSharp.Color(0, 0, 0, 0));
        }

        GenGridItemEventArgs OnSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            return new GenGridItemEventArgs
            {
                Item = _itemContextDic.ContainsKey(info) ? _itemContextDic[info] : null
            };
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateItemsSource();
        }

        void UpdateItemsSource()
        {
            Control.Clear();
            _gengridItemDic.Clear();

            if (_collectionChanged != null)
            {
                _collectionChanged.CollectionChanged -= OnCollectionChanged;
                _collectionChanged = null;
            }

            if (Element.ItemsSource == null)
            {
                return;
            }

            foreach (var item in Element.ItemsSource)
            {
                View realview = CreateView(Element.ItemTemplate, item, Element.ItemHeight, Element.ItemWidth);
                realview.BindingContext = item;
                var context = new GengridItemContext
                {
                    Data = item,
                    RealizedView = realview,
                };
                var gridItem = Control.Append(gridItemClass, context);
                IntPtr handle = gridItem;
                _itemContextDic.Add(handle, gridItem);
                _gengridItemDic.Add(item, gridItem);
            }

            if (Element.ItemsSource is INotifyCollectionChanged collection)
            {
                _collectionChanged = collection;
                collection.CollectionChanged += OnCollectionChanged;
            }
        }

        View CreateView(DataTemplate template, Object data, double heightRequest, double widthRequest)
        {
            if (template != null)
            {
                var content = template.CreateContent();
                if (content is View view)
                    return view;
            }
            return null;
        }

        void UpdateSelectedItem()
        {
            if (Element.SelectedItem == null)
            {
                Control.SelectedItem.IsSelected = false;
                return;
            }
            GenGridItem item = null;
            _gengridItemDic.TryGetValue(Element.SelectedItem, out item);
            if (item != null)
            {
                item.IsSelected = true;
            }
        }
    }
}