namespace IDSps1.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "sanket_admin", EmailAddress = "sanket.admin@email.com", Password = "MyPass_w0rd", GivenName = "Sanket", Surname = "Jaiswal", Role = "Administrator" },
          
        };
    }
}