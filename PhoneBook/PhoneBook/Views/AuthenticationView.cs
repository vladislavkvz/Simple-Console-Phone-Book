namespace PhoneBook.Views
{
    using System.Threading;
    using Service;
    using System;

    public class AuthenticationView
    {
        public void Authenticate()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" W E L C O M E !!!");
                Console.WriteLine("#####################");
                Console.WriteLine("#### Enter your: ####");
                Console.Write("#### USERNAME:");

                string username = Console.ReadLine();
                if (string.IsNullOrEmpty(username))
                {
                    Authenticate();
                }

                Console.WriteLine("#### Enter your: ####");
                Console.Write("#### PASSWORD:");

                string password = Console.ReadLine();
                if (string.IsNullOrEmpty(password))
                {
                    Authenticate();
                }

                AuthenticationService auth = new AuthenticationService();
                auth.Login(username, password);

                if (AuthenticationService.LogUser != null)
                {
                    Console.Clear();
                    Console.WriteLine("##########################################");
                    Console.WriteLine("#### Welcome {0} ########", AuthenticationService.LogUser.FirstName);
                    Console.WriteLine("##########################################");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("##########################################");
                    Console.WriteLine("#### Invalid username or password ########");
                    Console.WriteLine("##########################################");
                    Thread.Sleep(1200);
                }
            }
        }
    }
}