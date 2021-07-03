using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            Console.WriteLine("Welcome to Address Book Program");
            AddressBook addressBook = new AddressBook();
            do
            {
                Console.WriteLine("     MENU   ");
                Console.WriteLine("1. Add member to Contact list \n2.View Members in Contact List\n3.Exit");
                Console.WriteLine("Enter an option:");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        addressBook.AddMember();
                        break;
                    case 2:
                        addressBook.ShowContactDetails();
                        break;
                    default:
                        Console.WriteLine("Exited Successfully");
                        break;

                }

            } while (option<3);
        }
    }
}
