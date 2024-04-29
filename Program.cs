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
        public int[] SearchByName(string name)
        {
            List<int> foundIndexes = new List<int>();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Name.Contains(name) == true)
                {
                    foundIndexes.Add(i);
                }
            }
            return foundIndexes.ToArray();
        }
        public int[] SearchByEmail(string email)
        {
            List<int> foundIndexes = new List<int>();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Email.Contains(email) == true)
                {
                    foundIndexes.Add(i);
                }
            }
            return foundIndexes.ToArray();
        }
        public int[] SearchByPhone(string number)
        {
            List<int> foundIndexes = new List<int>();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Phone.Contains(number) == true)
                {
                    foundIndexes.Add(i);
                }
            }
            return foundIndexes.ToArray();
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
        public void EditContact(int idx, int c, string new1)
        {
            /*idx : the index of the wanted contact 
             * c : 0 -> name , 1-> email , 2->phone
             * new1 : the new string you want to add
             */

            switch (c)
            {
                case 0:
                    contacts[idx].Name = new1;
                    break;
                case 1:
                    contacts[idx].Email = new1;
                    break;
                case 2:
                    contacts[idx].Phone = new1;
                    break;
            }
        }
        public void SortByName()
        {
            contacts.Sort((x, y) => x.Name.CompareTo(y.Name));
        }
        public void SortByEmail()
        {
            contacts.Sort((x, y) => x.Email.CompareTo(y.Email));
        }
        public void SortByPhone()
        {
            contacts.Sort((x, y) => x.Phone.CompareTo(y.Phone));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.LoadContactsFromFile("contacts.txt");
            phoneBook.SaveContactsToFile("contacts.txt");
        }
    }
}
