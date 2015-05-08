using System.Linq;
using System.Web;
using Overtime.Models;

namespace Overtime
{
    public static class Auth

    {
        private const string UserKey = "UserKey";

        public static User User
        {
            get
            {
                var _db = new OvertimeDbContext();
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                    return null;
                var user = HttpContext.Current.Items[UserKey] as User;
                if (user == null)
                {
                    user = _db.Users.FirstOrDefault(x => x.Name == HttpContext.Current.User.Identity.Name);
                    if (user == null)
                        return null;
                    HttpContext.Current.Items[UserKey] = user;
                }
                return user;
            }
        }
    }
}