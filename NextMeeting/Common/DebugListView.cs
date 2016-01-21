using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace NextMeeting.Common
{
    public class DebugListView : ListView
    {

        public int GetContainerCount { get; set; }

        public int PrepareContainerCount { get; set; }

        protected override Windows.UI.Xaml.DependencyObject GetContainerForItemOverride()
        {
            GetContainerCount++;
            return base.GetContainerForItemOverride();
        }

        protected override void PrepareContainerForItemOverride(Windows.UI.Xaml.DependencyObject element, object item)
        {
            PrepareContainerCount++;
            base.PrepareContainerForItemOverride(element, item);
        }

        public DebugListView()
        {
            this.Loaded += DebugListView_Loaded;
        }

        private void DebugListView_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Debug.WriteLine("GetContainerCount : " + GetContainerCount.ToString());
            Debug.WriteLine("PrepareContainerCount : " + PrepareContainerCount.ToString());
        }

        internal void WriteStats()
        {
            Debug.WriteLine("GetContainerCount : " + GetContainerCount.ToString());
            Debug.WriteLine("PrepareContainerCount : " + PrepareContainerCount.ToString());
        }
    }
}
