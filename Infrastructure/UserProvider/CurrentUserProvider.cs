using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Infrastructure.UserProvider
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private IHttpContextAccessor HttpContextAccessor;
        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public int UserId()
        {
            var user = HttpContextAccessor.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
                return default(int);

            var userId = user.Claims.FirstOrDefault(x => x.Type == "Id").Value;
            return int.Parse(userId);
        }
    }
}
