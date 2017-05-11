namespace PhoneBook.Views
{
    using System.Collections.Generic;
    using Repositories;
    using Entities;
    using Service;
    using System.Threading;
    using System;

    public class AdminView
    {
        public void View()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("#########################################");
                Console.WriteLine("############ W O R K  W I T H ###########");
                Console.WriteLine("[U] S E R   M A N A G E M E N T");
                Console.WriteLine("[C] O N T A C T S    M A N A G E M E N T");
                Console.WriteLine("E[X]IT");
                string choice = Console.ReadLine();
                Console.Clear();
                if (choice.ToUpper() == "U")
                {
                    UserManagement();
                }
                else if (choice.ToUpper() == "C")
                {
                    ContactsManagement();
                }
                else if (choice.ToUpper() == "X")
                {
                    Environment.Exit(0);
                }
            }
        }

        public void UserManagement()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("#####################################");
                Console.WriteLine("### U S E R   M A N A G E M E N T ###");
                Console.WriteLine("#####################################");
                Console.WriteLine("############# [A]dd #################");
                Console.WriteLine("############# [L]ist ################");
                Console.WriteLine("############# [E]dit ################");
                Console.WriteLine("############# [D]elite ##############");
                Console.WriteLine("############# E[x]it ################");
                Console.WriteLine("########## YOUR CHOICE: ");
                string choice = Console.ReadLine();
                UserRepo repository = new UserRepo("users.txt");
                switch (choice.ToUpper())
                {
                    case "A":
                        AddUser(repository);
                        break;
                    case "L":
                        RenderUsers(repository.List());
                        Console.ReadLine();
                        break;
                    case "E":
                        RenderUsers(repository.List());
                        Console.WriteLine("#####################################");
                        Console.Write("###### EDIT USER BY ID : ");
                        EditUser(repository, int.Parse(Console.ReadLine()));
                        break;
                    case "D":
                        RenderUsers(repository.List());
                        Console.WriteLine("#####################################");
                        Console.Write("##### DELETE USER BY ID : ");
                        int id = int.Parse(Console.ReadLine());
                        if (id != AuthenticationService.LogUser.Id)
                        {
                            repository.Delete(id);
                        }
                        break;
                    case "X":
                        View();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("#####################################");
                        Console.WriteLine("########### Wrong Command! ##########");
                        Console.WriteLine("#####################################");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }

        private void EditUser(UserRepo repository, int editId)
        {
            Console.WriteLine("#######################################");
            Console.WriteLine("###### Edit user with id {0} ######", editId);
            User editedUser = new User();
            var users = repository.List();
            foreach (var user in users)
            {
                if (user.Id != AuthenticationService.LogUser.Id)
                {
                    if (user.Id == editId)
                    {
                        editedUser.Id = user.Id;
                        Console.Clear();
                        Console.Write("Old Username : ");
                        Console.WriteLine(user.Username);
                        Console.Write("New Username : ");
                        editedUser.Username = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Old Password : ");
                        Console.WriteLine(user.Password);
                        Console.Write("New Password : ");
                        editedUser.Password = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Old First Name : ");
                        Console.WriteLine(user.FirstName);
                        Console.Write("New First Name : ");
                        editedUser.FirstName = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Old Last Name : ");
                        Console.WriteLine(user.LastName);
                        Console.Write("New Last Name : ");
                        editedUser.LastName = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Old IsAdmin : ");
                        Console.WriteLine(user.IsAdmin);
                        Console.Write("New IsAdmin : ");
                        editedUser.IsAdmin = Convert.ToBoolean(Console.ReadLine().ToLower());
                        repository.Edit(editId, editedUser);
                        Console.Clear();
                        Console.WriteLine("#########################");
                        Console.WriteLine("####### D O N E ! #######");
                        Console.WriteLine("#########################");
                        Thread.Sleep(1000);
                    }
                }
            }
        }

        private void AddUser(UserRepo repository)
        {
            Console.Clear();
            Console.WriteLine("############ ADD USER ############");
            User user = new User();
            Console.WriteLine("#### Username: ");
            user.Username = Console.ReadLine();
            Console.WriteLine("#### Password: ");
            user.Password = Console.ReadLine();
            Console.WriteLine("#### FirstName: ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("#### LastName: ");
            user.LastName = Console.ReadLine();
            Console.WriteLine("#### IsAdmin: ");
            user.IsAdmin = Convert.ToBoolean(Console.ReadLine());
            repository.Add(user);
            Console.Clear();
            Console.WriteLine("#########################");
            Console.WriteLine("####### D O N E ! #######");
            Console.WriteLine("#########################");
            Thread.Sleep(1000);
            User u = new User();
        }

        public void ContactsManagement()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("#####################################");
                Console.WriteLine("##### Y O U R    C O N T A C T S ####");
                Console.WriteLine("#####################################");
                Console.WriteLine("############# [A]dd #################");
                Console.WriteLine("############# [L]ist ################");
                Console.WriteLine("############# [E]dit ################");
                Console.WriteLine("############# [D]elite ##############");
                Console.WriteLine("############# E[x]it ################");
                Console.WriteLine("########## YOUR CHOICE: ");
                string choice = Console.ReadLine();
                Console.Clear();
                ContactRepo repository = new ContactRepo("contacts.txt");
                var contacts = repository.List(AuthenticationService.LogUser.Id);
                switch (choice.ToUpper())
                {
                    case "A":
                        AddContact(repository);
                        break;
                    case "L":
                        RenderContacts(contacts);
                        Console.ReadKey(true);
                        break;
                    case "E":
                        RenderContacts(contacts);
                        Console.WriteLine("#####################################");
                        Console.Write("##### EDIT CONTACT BY ID : ");
                        EditContact(repository, contacts, int.Parse(Console.ReadLine()));
                        break;
                    case "D":
                        RenderContacts(contacts);
                        Console.WriteLine("#####################################");
                        Console.Write("##### DELETE CONTACT BY ID : ");
                        repository.Delete(int.Parse(Console.ReadLine()));
                        Console.Clear();
                        Console.WriteLine("#########################");
                        Console.WriteLine("####### D O N E ! #######");
                        Console.WriteLine("#########################");
                        Thread.Sleep(1000);
                        break;
                    case "X":
                        View();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("#####################################");
                        Console.WriteLine("########### Wrong Command! ##########");
                        Console.WriteLine("#####################################");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }

        private void EditContact(ContactRepo repository, List<Contact> contacts, int editId)
        {
            Console.WriteLine("#######################################");
            Console.WriteLine("###### Edit contact with id {0} ######", editId);
            Contact editedContact = new Contact();
            foreach (var contact in contacts)
            {
                if (contact.Id == editId)
                {
                    editedContact.ParentUserId = contact.ParentUserId;
                    Console.Clear();
                    Console.Write("#### Old First Name : ");
                    Console.WriteLine(contact.FirstName);
                    Console.Write("#### New First Name : ");
                    editedContact.FirstName = Console.ReadLine();
                    Console.Clear();
                    Console.Write("#### Old Last Name : ");
                    Console.WriteLine(contact.LastName);
                    Console.Write("#### New Last Name : ");
                    editedContact.LastName = Console.ReadLine();
                    Console.Clear();
                    Console.Write("#### Old Email : ");
                    Console.WriteLine(contact.Email);
                    Console.Write("#### New Email : ");
                    editedContact.Email = Console.ReadLine();
                    Console.Write("#### Old Phone : ");
                    Console.WriteLine(contact.Phone);
                    Console.Write("#### New Phone : ");
                    editedContact.Phone = Console.ReadLine();
                    repository.Edit(editId, editedContact);
                    Console.Clear();
                    Console.WriteLine("#########################");
                    Console.WriteLine("####### D O N E ! #######");
                    Console.WriteLine("#########################");
                    Thread.Sleep(1000);
                }
            }
        }

        private void AddContact(ContactRepo repository)
        {
            Console.Clear();
            Console.WriteLine("######### ADD CONTACT ###########");
            Contact contact = new Contact();
            contact.ParentUserId = AuthenticationService.LogUser.Id;
            Console.WriteLine("#### FirstName: ");
            contact.FirstName = Console.ReadLine();
            Console.WriteLine("#### LastName: ");
            contact.LastName = Console.ReadLine();
            Console.WriteLine("#### Email: ");
            contact.Email = Console.ReadLine();
            Console.WriteLine("#### Phone: ");
            contact.Phone = Console.ReadLine();
            repository.Add(contact);
            Console.Clear();
            Console.WriteLine("#########################");
            Console.WriteLine("####### D O N E ! #######");
            Console.WriteLine("#########################");
            Thread.Sleep(1000);
        }

        private static void RenderContacts(List<Contact> contacts)
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine("ID:" + contact.Id);
                Console.WriteLine("FirstName :" + contact.FirstName);
                Console.WriteLine("LastName :" + contact.LastName);
                Console.WriteLine("Email :" + contact.Email);
                Console.WriteLine("Phone :" + contact.Phone);
                Console.WriteLine("#####################################");
            }
        }

        private static void RenderUsers(List<User> users)
        {
            foreach (User user in users)
            {
                if (user.Id != AuthenticationService.LogUser.Id)
                {
                    Console.WriteLine("ID:" + user.Id);
                    Console.WriteLine("Username :" + user.Username);
                    Console.WriteLine("Password :" + user.Password);
                    Console.WriteLine("FirstName :" + user.FirstName);
                    Console.WriteLine("LastName :" + user.LastName);
                    Console.WriteLine("Email :" + user.IsAdmin);
                    Console.WriteLine("#####################################");
                }
            }
        }
    }
}