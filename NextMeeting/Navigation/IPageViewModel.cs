using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Navigation
{



    public interface IPageViewModel<TViewModel>
    {
        TViewModel ViewModel { get; set; }

    }
}
