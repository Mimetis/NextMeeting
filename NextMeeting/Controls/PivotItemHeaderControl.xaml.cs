using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NextMeeting.Controls
{
    public sealed partial class PivotItemHeaderControl : UserControl
    {

        public T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindParent<T>(parentObject);
        }

        Pivot pivot;

        public PivotItemHeaderControl()
        {
            this.InitializeComponent();
            this.Loaded += PivotItemHeaderControl_Loaded;
        }

        private void PivotItemHeaderControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.pivot = FindParent<Pivot>(this);
            if (this.pivot == null)
                return;

            this.pivot.SelectionChanged += Pivot_SelectionChanged;

            PivotItem pi = this.pivot.SelectedItem as PivotItem;

            if (pi == null)
                return;

            CheckBorderOpacity(pi);
        }

        public Symbol Symbol
        {
            get { return (Symbol)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Symbol.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register("Symbol", typeof(Symbol), typeof(PivotItemHeaderControl), new PropertyMetadata(Symbol.Account));

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.AddedItems[0] as PivotItem;
            //var container = this.pivot.ContainerFromItem(item);

            if (item == null)
                return;

            CheckBorderOpacity(item);
        }

        private void CheckBorderOpacity(PivotItem item)
        {
            var pvih = item.Header as PivotItemHeaderControl;

            if (pvih == null)
                return;

            if (pvih == this)
            {
                PivotItemHeaderControlBorder.Opacity = 1.0d;
            }
            else
            {
                PivotItemHeaderControlBorder.Opacity = 0.0d;
            }
        }
        
    }
}
