﻿namespace PhoneBook.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        public int ParentUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}