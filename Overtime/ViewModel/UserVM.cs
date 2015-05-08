using System.ComponentModel.DataAnnotations;

namespace Overtime.ViewModel
{
    public class UserLogin
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string PasswoedHash { get; set; }

        public bool RemomeberMe { get; set; }
    }
}