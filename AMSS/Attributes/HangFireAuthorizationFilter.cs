using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace AMSS.Attributes
{
    public class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public HangFireAuthorizationFilter()
        {
            
        }
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
