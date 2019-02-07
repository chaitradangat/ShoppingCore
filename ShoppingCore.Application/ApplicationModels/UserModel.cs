using ShoppingCore.Application.Interfaces;

namespace ShoppingCore.Application.ApplicationModels
{
    public class UserModel : IAppModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsAutheticated { get; set; }

        public AutheticationType AutheticationType { get; set; }

        public UserRole UserRole { get; set; }
    }
}
