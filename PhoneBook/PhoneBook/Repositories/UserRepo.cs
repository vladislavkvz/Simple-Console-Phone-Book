namespace PhoneBook.Repositories
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class UserRepo
    {
        private readonly string filePath;

        public UserRepo(string path)
        {
            this.filePath = path;
        }

        public int NextId()
        {
            int id = 1;
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        User user = new User();
                        user.Id = Convert.ToInt32(sr.ReadLine());
                        user.Username = sr.ReadLine();
                        user.Password = sr.ReadLine();
                        user.FirstName = sr.ReadLine();
                        user.LastName = sr.ReadLine();
                        user.IsAdmin = Convert.ToBoolean(sr.ReadLine());
                        if (id <= user.Id)
                        {
                            id = user.Id + 1;
                        }
                    }
                }
            }
            return id;
        }

        public void Add(User user)
        {
            int userid = NextId();
            using (FileStream fs = new FileStream(filePath, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(userid);
                    sw.WriteLine(user.Username);
                    sw.WriteLine(user.Password);
                    sw.WriteLine(user.FirstName);
                    sw.WriteLine(user.LastName);
                    sw.WriteLine(user.IsAdmin);
                }
            }
        }

        public List<User> List()
        {
            List<User> users = new List<User>();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        User user = new User();
                        user.Id = Convert.ToInt32(sr.ReadLine());
                        user.Username = sr.ReadLine();
                        user.Password = sr.ReadLine();
                        user.FirstName = sr.ReadLine();
                        user.LastName = sr.ReadLine();
                        user.IsAdmin = Convert.ToBoolean(sr.ReadLine());
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public void Edit(int id, User editUser)
        {
            List<User> users = new List<User>();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        User user = new User();
                        user.Id = int.Parse(sr.ReadLine());
                        if (user.Id == id)
                        {
                            user.Username = editUser.Username;
                            user.Password = editUser.Password;
                            user.FirstName = editUser.FirstName;
                            user.LastName = editUser.LastName;
                            user.IsAdmin = editUser.IsAdmin;
                            users.Add(user);
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            continue;
                        }
                        user.Username = sr.ReadLine();
                        user.Password = sr.ReadLine();
                        user.FirstName = sr.ReadLine();
                        user.LastName = sr.ReadLine();
                        user.IsAdmin = Convert.ToBoolean(sr.ReadLine());
                        users.Add(user);
                    }
                }
            }
            //FileMode.Create - Overwrite the file because it exist already
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (User user in users)
                    {
                        sw.WriteLine(user.Id);
                        sw.WriteLine(user.Username);
                        sw.WriteLine(user.Password);
                        sw.WriteLine(user.FirstName);
                        sw.WriteLine(user.LastName);
                        sw.WriteLine(user.IsAdmin);
                    }
                }
            }
        }

        public void Delete(int id)
        {
            List<User> users = new List<User>();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        User user = new User();
                        user.Id = int.Parse(sr.ReadLine());
                        if (user.Id == id)
                        {
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            continue;
                        }
                        user.Username = sr.ReadLine();
                        user.Password = sr.ReadLine();
                        user.FirstName = sr.ReadLine();
                        user.LastName = sr.ReadLine();
                        user.IsAdmin = bool.Parse(sr.ReadLine().ToLower());
                        users.Add(user);
                    }
                }
            }
            //FileMode.Create - Overwrite the file because it exist already
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (User user in users)
                    {
                        sw.WriteLine(user.Id);
                        sw.WriteLine(user.Username);
                        sw.WriteLine(user.Password);
                        sw.WriteLine(user.FirstName);
                        sw.WriteLine(user.LastName);
                        sw.WriteLine(user.IsAdmin);
                    }
                }
            }
        }
    }
}