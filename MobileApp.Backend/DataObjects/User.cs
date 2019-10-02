using Microsoft.Azure.Mobile.Server;

namespace MobileApp.Backend.DataObjects
{
    public class User : EntityData
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CurrentAddress { get; set; }
    }
}
