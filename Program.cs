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
        public override string ToString()
        {
            return $"{Name},{Email},{Phone}";
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
        }

        public void PrintContacts()
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Email: {contact.Email}, Phone: {contact.Phone}");
            }
        }

        public void SaveContactsToFile(string filename)
        {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Contact contact in contacts)
                    {
                        writer.WriteLine(contact.ToString());
                    }
                }
        }
        public int SearchByName(string name) 
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Name == name) 
                {
                    return i;
                }
            }
            return -1;
        }
        public int SearchByEmail(string email)
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Email == email)
                {
                    return i;
                }
            }
            return -1;
        }
        public int SearchByPhone(string number)
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Phone == number)
                {
                    return i;
                }
            }
            return -1;
        }
        public bool DeleteContact(int idx) 
        {
            if(idx < contacts.Count && idx >= 0)
            {
                contacts.RemoveAt(idx);
                return true;
            }
            else { return false; }  
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.LoadContactsFromFile("contacts.txt");
            phoneBook.DeleteContact(0);
            phoneBook.SaveContactsToFile("contacts.txt");
        }
    }
}
