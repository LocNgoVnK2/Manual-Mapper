using Manual_Mapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_Mapper.Services
{
    public class FakeCurrentUserBusiness : ICurrentUserBusiness
    {
        // This is a fake implementation used for testing or demo purposes.
        // In a real project, these methods would retrieve data from an authentication framework or user context.
        public string GetCurrentUserId()
        {
            return Guid.NewGuid().ToString(); // Simulated current user
        }

        public string GetCurrentUserRole()
        {
            return "Admin";
        }


    }
}
