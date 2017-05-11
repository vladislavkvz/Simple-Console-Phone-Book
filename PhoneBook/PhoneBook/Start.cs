namespace PhoneBook
{
    using Service;
    using Views;

    public class Start
    {
        static void Main()
        {
            AuthenticationView authenticate = new AuthenticationView();
            authenticate.Authenticate();

            if (AuthenticationService.LogUser.IsAdmin)
            {
                AdminView admin = new AdminView();
                admin.View();
            }
            else
            {
                UserView user = new UserView();
                user.View();
            }
        }
    }
}