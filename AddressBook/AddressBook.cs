using System;
using System.Collections.Generic;


namespace AddressBook
{
    class AddressBook
    {
        private List<ContactPerson> contacts = new List<ContactPerson>();
        private static Dictionary<string, List<ContactPerson>> addressBookDictionary = new Dictionary<string, List<ContactPerson>>();
        public void AddMember()
        {
            bool flag = true;
            Console.WriteLine("Enter The Name of the Address Book");
            string addressBookName = Console.ReadLine();
            //Checking uniqueness of address books
            while (addressBookDictionary.Count>0)
            {
                if (addressBookDictionary.ContainsKey(addressBookName))
                {
                    Console.WriteLine("This name of address book already exists");
                    flag = false;
                    break;
                }
            }
            
            while (flag)
            { 
                ContactPerson person = new ContactPerson();
                while (flag)
                {
                    Console.Write("Enter First Name: ");
                    string firstName = Console.ReadLine();
                    if (contacts.Count >0)
                    {
                        var x = contacts.Find(x => x.firstName.Equals(firstName));
                        if (x != null)
                        {
                            Console.WriteLine("Your name  already exists");
                        }
                        else
                        {
                            person.firstName = firstName;
                            break;
                        }
                    }
                    else
                    {
                        person.firstName = firstName;
                        break;
                    }

                }    //ContactPerson person = new ContactPerson();

                
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
                addressBookDictionary.Add(addressBookName, contacts);

                Console.WriteLine("Successfully Added");
                Console.WriteLine("you want add more member? 'YES' or 'NO' choose one");
                if (Console.ReadLine().ToLower().Equals("yes"))
                {
                    flag = true;
                }
                else
                {
                    break;
                }

            }
        }
        public void ShowContactDetails()
        {
            foreach (KeyValuePair<string, List<ContactPerson>> dict in addressBookDictionary)
            {
                Console.WriteLine($"         {dict.Key} Address Book");
                foreach (var details in dict.Value)
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
        public void ModifyDetails()
        {
            int option;
            Console.Write("Enter the Name of the person you want to change ");
            string findName = Console.ReadLine().ToLower();

            foreach (ContactPerson modify in contacts)
            {
                if (findName.Equals(modify.firstName.ToLower())||findName.Equals(modify.lastName.ToLower()))
                {
                    do
                    {
                        Console.WriteLine("1.First name\n2.Last name\n3.Address\n4.City\n5.State\n6.ZipCode\n7.Phone Number\n8.email\n9.Cancel");
                        Console.WriteLine("Enter Option to Modify Details");
                        option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter New First name");
                                modify.firstName = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Enter New Last name");
                                break;
                            case 3:
                                Console.WriteLine("Enter New Address");
                                modify.address = Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine("Enter New City");
                                modify.city = Console.ReadLine();
                                break;
                            case 5:
                                Console.WriteLine("Enter New State");
                                modify.state = Console.ReadLine();
                                break;
                            case 6:
                                Console.WriteLine("Enter New Zip Code");
                                modify.zipCode = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 7:
                                Console.Write("Enter new Phone Number: ");
                                modify.phoneNumber = Console.ReadLine();
                                break;
                            case 8:
                                Console.Write("Enter new Email-id: ");
                                modify.email = Console.ReadLine();
                                break;
                            default:
                                Console.WriteLine("Cancelled");
                                break;
                        }

                    } while (option < 9);
                }
                else
                {
                    Console.WriteLine("Entered name not in Contact list");
                }
            }
        }
        public  void DeleteContact()
        {
            
                Console.Write("Enter name of a person you want to Delete: ");
                string deleteName = Console.ReadLine().ToLower();

                foreach (ContactPerson x in contacts)
                {
                    if (deleteName.Equals(x.firstName.ToLower()))
                    {
                        Console.WriteLine($" {x.firstName} Contact deleted");
                        contacts.Remove(x);
                        
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The name you have entered not in the address book");
                    }
                }
                
            
        }

    }
}


 
