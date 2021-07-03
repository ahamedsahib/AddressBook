using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBook
    {
        public void AddMember()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter City: ");
            string city = Console.ReadLine();
            Console.Write("Enter State: ");
            string state = Console.ReadLine();
            Console.Write("Enter Zip Code: ");
            int zipCode = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Phone Number: ");
            string phNo = Console.ReadLine();

            Console.WriteLine("Successfully Added");
        }


    }
}
