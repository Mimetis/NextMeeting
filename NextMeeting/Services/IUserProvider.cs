using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Services
{
    public interface IUserProvider
    {
        Task<List<User>> GetUsers(List<String> emails);
    }
}
