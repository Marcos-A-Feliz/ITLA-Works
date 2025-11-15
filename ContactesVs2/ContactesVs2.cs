using static System.Console;

WriteLine("Welcome to Your Contact List");

bool running = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, bool> favorites = new Dictionary<int, bool>();

do
{
    WriteLine("1. Add Contact     2. View Contacts     3. Search Contacts     4. Edit Contact     5. Delete Contact     6. Exit");
    WriteLine("Enter the number of your choice:");
    try
    {
        int typeOption = Convert.ToInt32(ReadLine());

        switch (typeOption)
        {
            case 1: // Add Contact
                {
                    string name;
                    while (true)
                    {
                        WriteLine("Enter the person's first name:");
                        name = ReadLine();
                        if (!string.IsNullOrWhiteSpace(name))
                            break;
                        WriteLine("Error: Name cannot be empty. Please try again.");
                    }

                    string lastname;
                    while (true)
                    {
                        WriteLine("Enter the person's last name:");
                        lastname = ReadLine();
                        if (!string.IsNullOrWhiteSpace(lastname))
                            break;
                        WriteLine("Error: Last name cannot be empty. Please try again.");
                    }

                    WriteLine("Enter the address:");
                    string address = ReadLine();

                    string phone;
                    while (true)
                    {
                        WriteLine("Enter the phone number:");
                        phone = ReadLine();
                        if (!string.IsNullOrWhiteSpace(phone) && phone.All(char.IsDigit))
                            break;
                        WriteLine("Error: Phone number must contain only digits and cannot be empty. Try again.");
                    }

                    WriteLine("Enter the email:");
                    string email = ReadLine();

                    bool isFavorite;
                    while (true)
                    {
                        WriteLine("Want to add it as Favorite? 1 = Yes, 2 = No");
                        string favoriteInput = ReadLine();
                        if (favoriteInput == "1" || favoriteInput == "2")
                        {
                            isFavorite = favoriteInput == "1";
                            break;
                        }
                        WriteLine("Error: Please enter 1 for Yes or 2 for No.");
                    }

                    int id = ids.Count + 1;
                    ids.Add(id);
                    names.Add(id, name);
                    lastnames.Add(id, lastname);
                    addresses.Add(id, address);
                    telephones.Add(id, phone);
                    emails.Add(id, email);
                    favorites.Add(id, isFavorite);

                    WriteLine("Contact added successfully!");
                }
                break;

            case 2: // View Contacts
                {
                    if (ids.Count == 0)
                    {
                        WriteLine("There aren't any contacts added.");
                    }
                    else
                    {
                        WriteLine($"\n {"First Name",-15} {"Last Name", -15} {"Address", -15} {"Phone", -12} {"Email", -25} {"Favorite?", -10}");
                        WriteLine("______________________________________________________________________________________");
                        foreach (var id in ids)
                        {
                            string favStr = favorites[id] ? "Yes" : "No";
                            WriteLine($"{names[id],-15} {lastnames[id],-15} {addresses[id],-15} {telephones[id],-12} {emails[id],-25} {favStr,-10}");
                        }
                    }
                }
                break;

case 3: // Search Contacts
    {
        if (ids.Count == 0)
        {
            WriteLine("There aren't any contacts to search.");
        }
        else
        {
            WriteLine("Choose search option:");
            WriteLine("1. Search by Name (First or Last name)");
            WriteLine("2. Search by Phone Number");
            Write("Enter your choice (1 or 2): ");
            
            int searchOption = Convert.ToInt32(ReadLine());
            
            switch (searchOption)
            {
                case 1: // Search by Name
                    {
                        WriteLine("Type the first name or last name of the contact you're searching for:");
                        string search = ReadLine()?.ToLower() ?? "";
                        bool found = false;

                        WriteLine($"\n{"First Name",-15} {"Last Name",-15} {"Address",-15} {"Phone",-12} {"Email",-25} {"Favorite",-10}");
                        WriteLine("______________________________________________________________________________________");

                        foreach (var id in ids)
                        {
                            string fullName = $"{names[id]} {lastnames[id]}".ToLower();
                            string favStr = favorites[id] ? "Yes" : "No";

                            if (fullName.Contains(search))
                            {
                                found = true;
                                WriteLine($"{names[id],-15} {lastnames[id],-15} {addresses[id],-15} {telephones[id],-12} {emails[id],-25} {favStr,-10}");
                            }
                        }

                        if (!found)
                        {
                            WriteLine($"No contacts found matching: {search}");
                        }
                    }
                    break;

                case 2: // Search by Phone Number
                    {
                        WriteLine("Type the phone number (or part of it) you're searching for:");
                        string search = ReadLine()?.ToLower() ?? "";
                        bool found = false;

                        WriteLine($"\n{"First Name",-15} {"Last Name",-15} {"Address",-15} {"Phone",-12} {"Email",-25} {"Favorite",-10}");
                        WriteLine("______________________________________________________________________________________");

                        foreach (var id in ids)
                        {
                            string phone = telephones[id].ToLower();
                            string favStr = favorites[id] ? "Yes" : "No";

                            if (phone.Contains(search))
                            {
                                found = true;
                                WriteLine($"{names[id],-15} {lastnames[id],-15} {addresses[id],-15} {telephones[id],-12} {emails[id],-25} {favStr,-10}");
                            }
                        }

                        if (!found)
                        {
                            WriteLine($"No contacts found with phone number containing: {search}");
                        }
                    }
                    break;

                default:
                    WriteLine("Invalid search option. Please enter 1 or 2.");
                    break;
            }
        }
    }
    break;

            case 4: // Edit Contact
                {
                    if (ids.Count == 0)
                    {
                        WriteLine("There aren't any contacts to edit.");
                    }
                    else
                    {
                        Write("Enter the first name or last name of the contact to edit: ");
                        string search = ReadLine()?.ToLower() ?? "";
                        bool found = false;

                        foreach (var id in ids)
                        {
                            string fullName = $"{names[id]} {lastnames[id]}".ToLower();

                            if (fullName.Contains(search))
                            {
                                found = true;
                                bool editing = true;

                                while (editing)
                                {
                                    string favStr = favorites[id] ? "Yes" : "No";
                                    WriteLine($"\nContact found: {names[id]} {lastnames[id]}");
                                    WriteLine($"Address: {addresses[id]}");
                                    WriteLine($"Email: {emails[id]}");
                                    WriteLine($"Phone: {telephones[id]}");
                                    WriteLine($"Favorite: {favStr}");

                                    WriteLine("\nWhat do you want to edit? 1 - First Name 2 - Last Name 3 - Address 4 - Email 5 - Phone Number 6 - Favorite 7 - Finish Editing");
                                    Write("Enter an option: ");
                                    int typedOption = Convert.ToInt32(ReadLine());

                                    switch (typedOption)
                                    {
                                        case 1:
                                            {
                                                Write($"Current first name: {names[id]}. Enter new first name: ");
                                                string newName = ReadLine();
                                                if (!string.IsNullOrWhiteSpace(newName))
                                                {
                                                    names[id] = newName;
                                                    WriteLine("The contact has been updated.");
                                                }
                                                else
                                                {
                                                    WriteLine("Error: Name cannot be empty.");
                                                }
                                            }
                                            break;
                                        case 2:
                                            {
                                                Write($"Current last name: {lastnames[id]}. Enter new last name: ");
                                                string newLastname = ReadLine();
                                                if (!string.IsNullOrWhiteSpace(newLastname))
                                                {
                                                    lastnames[id] = newLastname;
                                                    WriteLine("The contact has been updated.");
                                                }
                                                else
                                                {
                                                    WriteLine("Error: Last name cannot be empty.");
                                                }
                                            }
                                            break;
                                        case 3:
                                            {
                                                Write($"Current address: {addresses[id]}. Enter new address: ");
                                                addresses[id] = ReadLine();
                                                WriteLine("The contact has been updated.");
                                            }
                                            break;
                                        case 4:
                                            {
                                                Write($"Current email: {emails[id]}. Enter new email: ");
                                                emails[id] = ReadLine();
                                                WriteLine("The contact has been updated.");
                                            }
                                            break;
                                        case 5:
                                            {
                                                Write($"Current phone number: {telephones[id]}. Enter new phone number: ");
                                                string newPhone = ReadLine();
                                                if (!string.IsNullOrWhiteSpace(newPhone) && newPhone.All(char.IsDigit))
                                                {
                                                    telephones[id] = newPhone;
                                                    WriteLine("The contact has been updated.");
                                                }
                                                else
                                                {
                                                    WriteLine("Error: Phone number must contain only digits.");
                                                }
                                            }
                                            break;
                                        case 6:
                                            {
                                                WriteLine($"Current favorite status: {(favorites[id] ? "Yes" : "No")}");
                                                Write("Type 1 for Yes or 2 for No: ");
                                                string favInput = ReadLine();
                                                if (favInput == "1" || favInput == "2")
                                                {
                                                    favorites[id] = (favInput == "1");
                                                    WriteLine("The contact has been updated.");
                                                }
                                                else
                                                {
                                                    WriteLine("Error: Please enter 1 for Yes or 2 for No.");
                                                }
                                            }
                                            break;
                                        case 7:
                                            editing = false;
                                            break;
                                        default:
                                            WriteLine("Invalid option. Please try again.");
                                            break;
                                    }
                                }
                                break; 
                            }
                        }
                        if (!found)
                        {
                            WriteLine($"No contact found matching {search}");
                        }
                    }
                }
                break;

            case 5: // Delete Contact
                {
                    if (ids.Count == 0)
                    {
                        WriteLine("There aren't any contacts to delete.");
                    }
                    else
                    {
                        Write("Type the first name or last name of the contact to delete: ");
                        string search = ReadLine()?.ToLower() ?? "";
                        bool found = false;

                        foreach (var id in ids.ToList()) 
                        {
                            string fullName = $"{names[id]} {lastnames[id]}".ToLower();
                            if (fullName.Contains(search))
                            {
                                found = true;
                                WriteLine($"Contact found: {names[id]} {lastnames[id]}");
                                Write("Are you sure you want to delete this contact? 1 = Yes, 2 = No: ");
                                int confirm = Convert.ToInt32(ReadLine());
                                if (confirm == 1)
                                {
                                    names.Remove(id);
                                    lastnames.Remove(id);
                                    addresses.Remove(id);
                                    telephones.Remove(id);
                                    emails.Remove(id);
                                    favorites.Remove(id);
                                    ids.Remove(id);
                                    WriteLine("Contact deleted successfully");
                                }
                                break;
                            }
                        }
                        if (!found)
                        {
                            WriteLine($"No contact found matching {search}");
                        }
                    }
                }
                break;

            case 6: // Exit
                running = false;
                break;

            default:
                WriteLine("Invalid option, please try again.");
                break;
        }
    }
    catch (FormatException)
    {
        WriteLine("Invalid input. Please enter a valid number.");
    }
    catch (KeyNotFoundException)
    {
        WriteLine("Error: Contact not found.");
    }
    catch (OverflowException)
    {
        WriteLine("Error: The number entered is too large or too small.");
    }
    catch (InvalidOperationException)
    {
        WriteLine("Error: The list was modified during the operation.");
    }
    catch (ArgumentNullException)
    {
        WriteLine("Error: A required field was left empty.");
    }
    catch (Exception ex)
    {
        WriteLine($"An unexpected error has occurred: {ex.Message}");
    }
} while (running);