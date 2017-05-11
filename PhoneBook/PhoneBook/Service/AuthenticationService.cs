namespace PhoneBook.Service
{
    using Entities;
    using Repositories;

    public class AuthenticationService
    {
        public static User LogUser { get; set; }

        public void Login(string uName, string pass)
        {
            UserRepo uRepo = new UserRepo("users.txt");
            LogUser = uRepo.List().Find(u => u.Username == uName && u.Password == pass);
        }
    }
}