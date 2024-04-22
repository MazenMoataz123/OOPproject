using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finnn
{
    //test
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Contact(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }

    class PhoneBook
    {
        private List<Contact> contacts;

        public PhoneBook()
        {
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void LoadContactsFromFile(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string name = parts[0];
                        string email = parts[1];
                        string phone = parts[2];
                        Contact contact = new Contact(name, email, phone);
                        AddContact(contact);
                    }
                }
                Console.WriteLine("Contacts loaded successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading contacts: " + ex.Message);
            }
        }

        public void PrintContacts()
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Email: {contact.Email}, Phone: {contact.Phone}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.LoadContactsFromFile("C:\\Users\\User\\source\\repos\\finnn\\contacts.txt");
            phoneBook.PrintContacts();
        }
    }
}
