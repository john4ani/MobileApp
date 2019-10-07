using Microsoft.Azure.Mobile.Server;

namespace MobileApp.Backend.Models
{
    public class UserDBEntity : EntityData
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CurrentAddress { get; set; }

    }
}