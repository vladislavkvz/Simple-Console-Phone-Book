namespace PhoneBook.Repositories
{
    using System.Collections.Generic;
    using Entities;
    using System.IO;
    using System;

    public class ContactRepo
    {
        private readonly string filePath;

        public ContactRepo(string path)
        {
            this.filePath = path;
        }

        public int NextId()
        {
            int id = 1;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        Contact contact = new Contact();
                        contact.Id = int.Parse(sr.ReadLine());
                        contact.ParentUserId = int.Parse(sr.ReadLine());
                        contact.FirstName = sr.ReadLine();
                        contact.LastName = sr.ReadLine();
                        contact.Email = sr.ReadLine();
                        contact.Phone = sr.ReadLine();
                        if (id <= contact.Id)
                        {
                            id = contact.Id + 1;
                        }
                    }
                }
            }
            return id;
        }

        public void Add(Contact contact)
        {
            int contactid = NextId();
            using (FileStream fs = new FileStream(filePath, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(contactid);
                    sw.WriteLine(contact.ParentUserId);
                    sw.WriteLine(contact.FirstName);
                    sw.WriteLine(contact.LastName);
                    sw.WriteLine(contact.Email);
                    sw.WriteLine(contact.Phone);
                }
            }
        }

        public List<Contact> List(int id)
        {
            List<Contact> contacts = new List<Contact>();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        Contact contact = new Contact();
                        contact.Id = Convert.ToInt32(sr.ReadLine());
                        var ParentUserId = Convert.ToInt32(sr.ReadLine());
                        if (id == ParentUserId)
                        {
                            contact.ParentUserId = ParentUserId;
                        }
                        else
                        {
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            continue;
                        }
                        contact.FirstName = sr.ReadLine();
                        contact.LastName = sr.ReadLine();
                        contact.Email = sr.ReadLine();
                        contact.Phone = sr.ReadLine();
                        contacts.Add(contact);
                    }
                }
            }
            return contacts;
        }

        public void Edit(int id, Contact edited)
        {
            List<Contact> contacts = new List<Contact>();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        Contact contact = new Contact();
                        contact.Id = int.Parse(sr.ReadLine());
                        if (contact.Id == id)
                        {
                            contact.ParentUserId = int.Parse(sr.ReadLine());
                            contact.FirstName = edited.FirstName;
                            contact.LastName = edited.LastName;
                            contact.Email = edited.Email;
                            contact.Phone = edited.Phone;
                            contacts.Add(contact);
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            continue;
                        }
                        contact.ParentUserId = int.Parse(sr.ReadLine());
                        contact.FirstName = sr.ReadLine();
                        contact.LastName = sr.ReadLine();
                        contact.Email = sr.ReadLine();
                        contact.Phone = sr.ReadLine();
                        contacts.Add(contact);
                    }
                }
            }
            //FileMode.Create - Overwrite the file because it exist already
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (Contact contact in contacts)
                    {
                        sw.WriteLine(contact.Id);
                        sw.WriteLine(contact.ParentUserId);
                        sw.WriteLine(contact.FirstName);
                        sw.WriteLine(contact.LastName);
                        sw.WriteLine(contact.Email);
                        sw.WriteLine(contact.Phone);
                    }
                }
            }
        }

        public void Delete(int id)
        {
            List<Contact> contacts = new List<Contact>();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        Contact contact = new Contact();
                        contact.Id = int.Parse(sr.ReadLine());
                        if (contact.Id == id)
                        {
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            continue;
                        }
                        contact.ParentUserId = int.Parse(sr.ReadLine());
                        contact.FirstName = sr.ReadLine();
                        contact.LastName = sr.ReadLine();
                        contact.Email = sr.ReadLine();
                        contact.Phone = sr.ReadLine();
                        contacts.Add(contact);
                    }
                }
            }
            //FileMode.Create - Overwrite the file because it exist already
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (Contact contact in contacts)
                    {
                        sw.WriteLine(contact.Id);
                        sw.WriteLine(contact.ParentUserId);
                        sw.WriteLine(contact.FirstName);
                        sw.WriteLine(contact.LastName);
                        sw.WriteLine(contact.Email);
                        sw.WriteLine(contact.Phone);
                    }
                }
            }
        }
    }
}