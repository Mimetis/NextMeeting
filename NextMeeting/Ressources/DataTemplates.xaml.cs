using NextMeeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace NextMeeting.Ressources
{
    public partial class DataTemplates
    {
        public DataTemplates()
        {
            InitializeComponent();
        }

        private void Trending_ItemClick(object sender, Windows.UI.Xaml.Controls.ItemClickEventArgs e)
        {
            var item = e.ClickedItem as TrendingViewModel;

            if (e == null)
                return;

            item.OpenItem.Execute(null);
        }
        private void DriveItem_ItemClick(object sender, Windows.UI.Xaml.Controls.ItemClickEventArgs e)
        {
            var item = e.ClickedItem as DriveItemViewModel;

            if (e == null)
                return;

            item.OpenItem.Execute(null);
        }

        
    }
}
