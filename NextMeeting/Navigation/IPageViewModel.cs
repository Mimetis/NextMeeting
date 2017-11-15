using NextMeeting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Navigation
{
    public interface IPageWithViewModel
    {
        void SetViewModel(BaseViewModel viewModel);
    }

    public interface IPageWithViewModel<TViewModel> : IPageWithViewModel
    {
        TViewModel ViewModel { get; }
    }



}
