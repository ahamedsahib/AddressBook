using System;
using System.Collections.Generic;


namespace AddressBook
{
    class AddressBook
    {
        private static List<ContactPerson> contacts = new List<ContactPerson> ();
        public void AddMember()
        {
            ContactPerson person = new ContactPerson();

            Console.Write("Enter First Name: ");
            person.firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            person.lastName = Console.ReadLine();
            Console.Write("Enter Address: ");
            person.address = Console.ReadLine();
            Console.Write("Enter City: ");
            person.city = Console.ReadLine();
            Console.Write("Enter State: ");
            person.state = Console.ReadLine();
            Console.Write("Enter Zip Code: ");
            person.zipCode = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Phone Number: ");
            person.phoneNumber = Console.ReadLine();
            Console.Write("Enter Email-id: ");
            person.email = Console.ReadLine();


            contacts.Add(person);

            Console.WriteLine("Successfully Added");
        }

        public void ShowContactDetails()
        {
            foreach (var details in contacts)
            {
                Console.WriteLine($"First Name : {details.firstName}");
                Console.WriteLine($"Last Name : {details.lastName}");
                Console.WriteLine($"Address : {details.address}");
                Console.WriteLine($"City : {details.city}");
                Console.WriteLine($"State : {details.state}");
                Console.WriteLine($"Zip Code: {details.zipCode}");
                Console.WriteLine($"Phone Number: {details.phoneNumber}");
                Console.WriteLine($"Email: {details.email}");
            }
        }


    }
}
