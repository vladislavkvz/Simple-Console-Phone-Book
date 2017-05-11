namespace PhoneBook.Views
{
    using System.Collections.Generic;
    using Repositories;
    using Entities;
    using Service;
    using System.Threading;
    using System;

    public class UserView
    {
        public void View()
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
                        AddContact(repository, AuthenticationService.LogUser.Id);
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
                        Console.Clear();
                        Console.WriteLine("#########################");
                        Console.WriteLine("####### D O N E ! #######");
                        Console.WriteLine("#########################");
                        Thread.Sleep(1000);
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
                        Environment.Exit(0); ;
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

        private void AddContact(ContactRepo repository, int logUserId)
        {
            Console.WriteLine("#########################");
            Contact contact = new Contact();
            contact.ParentUserId = logUserId;
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
    }
}