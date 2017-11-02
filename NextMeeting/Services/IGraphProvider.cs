﻿using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Services
{
    public interface IGraphProvider
    {
        GraphServiceClient GetAuthenticatedGraphClient();
        void SignOut();
    }
}
