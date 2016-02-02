using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Models
{
    public class TrendingAroundItem
    {
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeLastModified { get; set; }
        public String Id { get; set; }
        public String Name { get; set; }
        public String Odata_id { get; set; }
        public String WebUrl { get; set; }

    }
}
