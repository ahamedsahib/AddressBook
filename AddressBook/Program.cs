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
                Console.WriteLine("         MENU   ");
                Console.WriteLine("1) Add member to Contact\n2)View Members in Contact List\n3)Edit details in Contact\n4)Delete Contact\n5)SearchPerson\n6)View Members in Contact List\n7)Exit");
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
                    case 3:
                        addressBook.ModifyDetails();
                        break;
                    case 4:
                        addressBook.DeleteContact();
                        break;
                    case 5:
                        addressBook.SearchDetails();
                        break;
                    case 6:
                        addressBook.ViewContactByStateOrCity();
                        break;
                    case 7:
                        addressBook.CountByStateOrCity();
                        break;
                    default:
                        Console.WriteLine("Exited Successfully");
                        break;

                }

            } while (option<8);
        }
    }
}
