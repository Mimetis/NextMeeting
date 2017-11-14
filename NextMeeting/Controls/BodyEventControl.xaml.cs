using Microsoft.Graph;
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
    public sealed partial class BodyEventControl : UserControl
    {
        public BodyEventControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or Sets the body text, issued from the Graph api. Can be either html or txt
        /// </summary>
        public ItemBody Body
        {
            get { return (ItemBody)GetValue(BodyProperty); }
            set { SetValue(BodyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Body.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BodyProperty =
            DependencyProperty.Register("Body", typeof(ItemBody), typeof(BodyEventControl),
                new PropertyMetadata(null, OnBodyChanged));

        private static void OnBodyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BodyEventControl bodyEventControl = d as BodyEventControl;

            var body = e.NewValue as ItemBody;

            bodyEventControl.SetBody();
        }

        private void SetBody()
        {
            if (Body.ContentType == BodyType.Html)
            {
                BodyWebview.Visibility = Visibility.Visible;
                BodyTextBlock.Visibility = Visibility.Collapsed;
                BodyWebview.NavigateToString(Body.Content);
            }
            else
            {
                BodyWebview.Visibility = Visibility.Collapsed;
                BodyTextBlock.Visibility = Visibility.Visible;
                BodyTextBlock.Text = Body.Content;
            }
        }

    }
}
