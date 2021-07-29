using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;

namespace AddressBook
{
    class AddressBook
    {
        private List<ContactPerson> contacts;
        private static List<ContactPerson> searchContacts = new List<ContactPerson>();
        private static List<ContactPerson> viewContacts = new List<ContactPerson>();
        private int countCity = 0, countState = 0;

        private static Dictionary<string, List<ContactPerson>> addressBookDictionary = new Dictionary<string, List<ContactPerson>>();
        public void AddMember()
        {
            contacts = new List<ContactPerson>();
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
                            break;
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
            
;           
            addressBookDictionary.Add(addressBookName, contacts);
            //addressBookDictionary.ToDictionary(addressBookName, SortContacts());
            addressBookDictionary[addressBookName] = SortContacts();
            
        }
        public void ShowContactDetails()
        {
            if (addressBookDictionary.Count > 0)
            {
                //printing the values in address book
                foreach (KeyValuePair<string, List<ContactPerson>> dict in addressBookDictionary)
                {
                    Console.WriteLine("*****************************************************");
                    Console.WriteLine($"******************{dict.Key}*********************");
                    Console.WriteLine("*****************************************************");
                    foreach (var addressBook in dict.Value)
                    {
                        PrintValues(addressBook);

                    }
                }
            }
            else
            {
                Console.WriteLine("Address Book is Empty");
            }

        }

        //Printing values
        public void PrintValues(ContactPerson x)
        {
            Console.WriteLine($"First Name : {x.firstName}");
            Console.WriteLine($"Last Name : {x.lastName}");
            Console.WriteLine($"Address : {x.address}");
            Console.WriteLine($"City : {x.city}");
            Console.WriteLine($"State : {x.state}");
            Console.WriteLine($"Zip Code: {x.zipCode}");
            Console.WriteLine($"Phone Number: {x.phoneNumber}");
            Console.WriteLine($"Email: {x.email}");
            Console.WriteLine("********|||||||||||********");
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
        public void SearchDetails()
        {
            string personName;
            Console.WriteLine("1. Search by city name\n2.Search By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter the name of city in which you want to search:");
                    string cityName = Console.ReadLine();
                    Console.WriteLine("Enter the name of person you want to search:");
                    personName = Console.ReadLine();
                    SearchByCityName(cityName, personName);
                    break;
                case 2:
                    Console.WriteLine("Enter the state of city in which you want to search:");
                    string stateName = Console.ReadLine();
                    Console.WriteLine("Enter the name of person you want to search:");
                    personName = Console.ReadLine();
                    SearchByStateName(stateName, personName);
                    break;
                default:
                    return;

            }

        }
        public void SearchByCityName(string cityName, string personName)
        {
            if (addressBookDictionary.Count > 0)
            {

                foreach (KeyValuePair<string, List<ContactPerson>> dict in addressBookDictionary)
                {
                    searchContacts = dict.Value.FindAll(x => x.firstName.Equals(personName) && x.state.Equals(cityName));


                }
                if (searchContacts.Count > 0)
                {
                    foreach (var x in searchContacts)
                    {
                        PrintValues(x);
                    }
                }
                else
                {
                    Console.WriteLine("Person not found");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
        }
        public void SearchByStateName(string stateName, string personName)
        {
            if (addressBookDictionary.Count > 0)
            {

                foreach (KeyValuePair<string, List<ContactPerson>> dict in addressBookDictionary)
                {
                    searchContacts = dict.Value.FindAll(x => x.firstName.Equals(personName) && x.state.Equals(stateName));

                }
                if (searchContacts.Count > 0)
                {
                    foreach (var x in searchContacts)
                    {
                        PrintValues(x);
                    }
                }
                else
                {
                    Console.WriteLine("Person not found");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }

        }
        public void ViewContactByStateOrCity()
        {

            Console.WriteLine("1. View by city name\n2.View By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter the name of city in which you want to view:");
                    string cityName = Console.ReadLine();
                    ViewContactByCityName(cityName, "view");
                    break;
                case 2:
                    Console.WriteLine("Enter the state of city in which you want to view:");
                    string stateName = Console.ReadLine();
                    ViewContactByStateName(stateName, "view");
                    break;
                default:
                    return;

            }

        }

        public void ViewContactByCityName(string cityName, string check)
        {
            if (addressBookDictionary.Count > 0)
            {

                foreach (KeyValuePair<string, List<ContactPerson>> dict in addressBookDictionary)
                {
                    viewContacts = dict.Value.FindAll(x => x.state.Equals(cityName));
                }
                if (check.Equals("view"))
                {
                    if (searchContacts.Count > 0)
                    {
                        foreach (var x in searchContacts)
                        {
                            PrintValues(x);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Persons found");
                    }
                }
                else
                {
                    countCity = viewContacts.Count;
                    Console.WriteLine($"The total persons in {cityName} are : {countCity}");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
            
        }
        public void ViewContactByStateName(string stateName, string check)
        {
            if (addressBookDictionary.Count > 0)
            {

                foreach (KeyValuePair<string, List<ContactPerson>> dict in addressBookDictionary)
                {
                    viewContacts = dict.Value.FindAll(x => x.state.Equals(stateName));
                }
                if (check.Equals("view"))
                {

                    if (searchContacts.Count > 0)
                    {
                        foreach (var x in searchContacts)
                        {
                            PrintValues(x);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Persons found");
                    }
                }
                else
                {
                    countState = viewContacts.Count;
                    Console.WriteLine($"The total persons in {stateName} are : {countState}");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
            
        }
        public void CountByStateOrCity()
        {

            Console.WriteLine("1.Count by city name\n2.Count By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter the name of city in which you want to count persons:");
                    string cityName = Console.ReadLine();
                    ViewContactByCityName(cityName, "count");
                    break;
                case 2:
                    Console.WriteLine("Enter the name of state in which you want to count persons:");
                    string stateName = Console.ReadLine();
                    ViewContactByStateName(stateName, "count");
                    break;
                default:
                    return;

            }

        }
        public List<ContactPerson> SortContacts()
        {
            if (addressBookDictionary.Count > 0)
            {

                Console.WriteLine("1.Sort by person name\n2.Sort by city name\n3.Sort by state name\n4.Sort by zipcode\nEnter Your option");
                int option = Convert.ToInt32(Console.ReadLine());
                //printing the values in address book
                foreach (KeyValuePair<string, List<ContactPerson>> dict in addressBookDictionary)
                {
                    switch (option)
                    {
                        case 1:
                            //sorting list based on first name
                            contacts = dict.Value.OrderBy(x => x.firstName).ToList();
                            break;
                        case 2:
                            contacts = dict.Value.OrderBy(x => x.city).ToList();
                            break;
                        case 3:
                            contacts = dict.Value.OrderBy(x => x.state).ToList();
                            break;
                        case 4:
                            contacts = dict.Value.OrderBy(x => x.zipCode).ToList();
                            break;
                    }

                    Console.WriteLine($"**********AFTER SORTING {dict.Key}**********");
                    foreach (var addressBook in contacts)
                    {
                        PrintValues(addressBook);
                    }
                }
            }
            else
            {
                Console.WriteLine("Address Book is Empty");
            }
            return contacts;
        }
        public void ReadFromFile()
        {
            string filePath = @"/Users/Akshal/Projects/AddressBook/AddressBook/AddressBookText.txt";

            try
            {
                string[] fileContents = File.ReadAllLines(filePath);
                var currentAddressBookName = fileContents[0];
                contacts = new List<ContactPerson>();
                foreach (string userDetails in fileContents.Skip(1))
                {
                    if (userDetails.Contains(","))
                    {
                        ContactPerson person = new ContactPerson();
                        string[] line = userDetails.Split(",");
                        person.firstName = line[0];
                        person.lastName = line[1];
                        person.address = line[2];
                        person.city = line[3];
                        person.state = line[4];
                        person.zipCode = Convert.ToInt32(line[5]);
                        person.phoneNumber = line[6];
                        person.email = line[7];
                        contacts.Add(person);
                    }
                    else
                    {
                        addressBookDictionary.Add(currentAddressBookName, contacts);
                        currentAddressBookName = userDetails;
                        contacts = new List<ContactPerson>();
                    }


                }
                addressBookDictionary.Add(currentAddressBookName, contacts);
                Console.WriteLine("SuccessFully Added");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void WriteToFile()
        {
            string filePath = @"/Users/Akshal/Projects/AddressBook/AddressBook/AddressBookText.txt";

            try
            {
                if (addressBookDictionary.Count > 0)
                {
                    File.WriteAllText(filePath, string.Empty);
                    //printing the values in address book
                    foreach (KeyValuePair<string, List<ContactPerson>> dict in addressBookDictionary)
                    {
                        File.AppendAllText(filePath, $"{dict.Key}\n");
                        foreach (var addressBook in dict.Value)
                        {
                            string text = $"{addressBook.firstName},{addressBook.lastName},{addressBook.address},{addressBook.city},{addressBook.state},{addressBook.zipCode},{addressBook.phoneNumber},{addressBook.email}\n";
                            File.AppendAllText(filePath, text);
                        }
                    }
                    Console.WriteLine("successfully stored in file");
                }
                else
                {
                    Console.WriteLine("Address Book is Empty");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void ReadFromCsvFile()
        {
            //File path
            string filePath = @"/Users/Akshal/Projects/AddressBook/AddressBook/AddressBookCSV.csv";
            try
            {
                string abName = "Global";
                if (File.Exists(filePath))
                {
                    //Stream reader for reading from csv file
                    using (var reader = new StreamReader(filePath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        //fetching records from csv files
                        var csvContactsList = csv.GetRecords<ContactPerson>().ToList();
                        addressBookDictionary.Add(abName, csvContactsList);
                        Console.WriteLine("Successfully Added from file");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
        /// <summary>
        /// Write records to csv file
        /// </summary>
        public void WriteToCsvFile()
        {
            //File path of csv file
            string filePath = @"/Users/Akshal/Projects/AddressBook/AddressBook/AddressBookCSV.csv";
            try
            {
                if (File.Exists(filePath))
                {
                    if (addressBookDictionary.Count > 0)
                    {
                
                        //initially clear the file
                        File.WriteAllText(filePath, string.Empty);
                        //stream writer to write files
                        using (var writer = new StreamWriter(filePath))
                        using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            foreach (KeyValuePair<string, List<ContactPerson>> dict in addressBookDictionary)
                            {
                                foreach (var addressBook in dict.Value)
                                {
                                    contacts = new List<ContactPerson>();
                                    contacts.Add(addressBook);
                                    //write records into csv file
                                    csvWriter.WriteRecords(contacts);
                                }
                            }
                        }
                        Console.WriteLine("Records Written into csv file");
                    }
                    else
                    {
                        Console.WriteLine("Address Book is Empty");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
        public void ReadFromJsonFile()
        {
            string filePath = @"/Users/Akshal/Projects/AddressBook/AddressBook/AddressContactsJSon.json";
            try
            {
                string abName = "Global";
                if (File.Exists(filePath))
                {
                    // convert json records to list
                    List<ContactPerson> jsonList = JsonConvert.DeserializeObject<List<ContactPerson>>(File.ReadAllText(filePath));
                    addressBookDictionary.Add(abName, jsonList);
                    Console.WriteLine("Data added succesfully");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }


        }
        /// <summary>
        /// Write records into json file
        /// </summary>
        public void WriteToJsonFile()
        {
            string filePath = @"/Users/Akshal/Projects/AddressBook/AddressBook/AddressContactsJSon.json";
            try
            {
                if (addressBookDictionary.Count > 0)
                {
                    //initially clear the file
                    File.WriteAllText(filePath, string.Empty);

                    //Initialising json serializer
                    JsonSerializer serializer = new JsonSerializer();
                    using (StreamWriter writer = new StreamWriter(filePath))
                    using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                    {
                        foreach (KeyValuePair<string, List<ContactPerson>> dict in addressBookDictionary)
                        {
                            //initialising contacts list
                            contacts = new List<ContactPerson>();
                            foreach (var addressBook in dict.Value)
                            {

                                contacts.Add(addressBook);

                            }
                            //write records into json file
                            serializer.Serialize(jsonWriter, contacts);
                        }
                    }
                    Console.WriteLine("Records Written into json file");
                }
                else
                {
                    Console.WriteLine("Address Book is Empty");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }


        }
    }
}


 



 
