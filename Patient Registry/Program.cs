using static System.Console;

WriteLine("~~~Welcome to the Patient Registration System~~~");

bool running = true;
List<int> patientIds = new List<int>();
Dictionary<int, string> patientNames = new Dictionary<int, string>();
Dictionary<int, string> patientLastNames = new Dictionary<int, string>();
Dictionary<int, int> patientAges = new Dictionary<int, int>();
Dictionary<int, string> patientGenders = new Dictionary<int, string>();
Dictionary<int, string> patientAddresses = new Dictionary<int, string>();
Dictionary<int, string> patientPhones = new Dictionary<int, string>();
Dictionary<int, string> patientEmails = new Dictionary<int, string>();
Dictionary<int, string> patientBloodTypes = new Dictionary<int, string>();
Dictionary<int, string> patientAllergies = new Dictionary<int, string>();
Dictionary<int, string> patientMedicalConditions = new Dictionary<int, string>();

do
{
    WriteLine("1. Register Patient     2. View Patients     3. Search Patients     4. Edit Patient     5. Delete Patient     6. Exit");
    Write("Select an option: ");
    try
    {
        int option = Convert.ToInt32(ReadLine());

        switch (option)
        {
            case 1:
                {
                    RegisterPatient(patientIds, patientNames, patientLastNames, patientAges, patientGenders, patientAddresses, patientPhones, patientEmails, patientBloodTypes, patientAllergies, patientMedicalConditions);
                }
                break;
            case 2:
                {
                    ViewPatients(patientIds, patientNames, patientLastNames, patientAges, patientGenders, patientAddresses, patientPhones, patientEmails, patientBloodTypes);
                }
                break;
            case 3:
                {
                    SearchPatient(patientIds, patientNames, patientLastNames, patientAges, patientGenders, patientAddresses, patientPhones, patientEmails, patientBloodTypes);
                }
                break;
            case 4:
                {
                    EditPatient(patientIds, patientNames, patientLastNames, patientAges, patientGenders, patientAddresses, patientPhones, patientEmails, patientBloodTypes, patientAllergies, patientMedicalConditions);
                }
                break;
            case 5:
                {
                    DeletePatient(patientIds, patientNames, patientLastNames, patientAges, patientGenders, patientAddresses, patientPhones, patientEmails, patientBloodTypes, patientAllergies, patientMedicalConditions);
                }
                break;
            case 6:
                {
                    running = false;
                    WriteLine("Exiting system...");
                }
                break;
            default:
                {
                    WriteLine("Invalid option. Please try again.");
                }
                break;
        }
    }
    catch (FormatException)
    {
        WriteLine("Invalid input. Please enter a valid number.");
    }
    catch (KeyNotFoundException)
    {
        WriteLine("Error: Patient not found.");
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



static void RegisterPatient(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastNames, Dictionary<int, int> ages, Dictionary<int, string> genders, Dictionary<int, string> addresses, Dictionary<int, string> phones, Dictionary<int, string> emails, Dictionary<int, string> bloodTypes, Dictionary<int, string> allergies, Dictionary<int, string> medicalConditions)
{
    WriteLine("\n=== REGISTER NEW PATIENT ===");
    string name;
    while (true)
    {
        Write("First Name: ");
        name = ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
            break;
        WriteLine("Error: First name cannot be empty.");
    }
    string lastName;
    while (true)
    {
        Write("Last Name: ");
        lastName = ReadLine();
        if (!string.IsNullOrWhiteSpace(lastName))
            break;
        WriteLine("Error: Last name cannot be empty.");
    }
    int age;
    while (true)
    {
        Write("Age: ");
        string ageInput = ReadLine();
        if (int.TryParse(ageInput, out age) && age > 0 && age < 150)
            break;
        WriteLine("Error: Please enter a valid age (1-149).");
    }
    string gender;
    while (true)
    {
        Write("Gender (M/F/O): ");
        gender = ReadLine()?.ToUpper();
        if (gender == "M" || gender == "F" || gender == "O")
            break;
        WriteLine("Error: Please enter M (Male), F (Female) or O (Other).");
    }
    Write("Address: ");
    string address = ReadLine();
    string phone;
    while (true)
    {
        Write("Phone: ");
        phone = ReadLine();
        if (!string.IsNullOrWhiteSpace(phone) && phone.All(char.IsDigit))
            break;
        WriteLine("Error: Phone must contain only numbers.");
    }
    Write("Email: ");
    string email = ReadLine();

    Write("Blood Type (e.g., A+, O-, etc.): ");
    string bloodType = ReadLine();

    Write("Allergies (separated by commas): ");
    string allergy = ReadLine();


    Write("Pre-existing Medical Conditions: ");
    string medicalCondition = ReadLine();

    int id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastNames.Add(id, lastName);
    ages.Add(id, age);
    genders.Add(id, gender);
    addresses.Add(id, address);
    phones.Add(id, phone);
    emails.Add(id, email);
    bloodTypes.Add(id, bloodType);
    allergies.Add(id, allergy);
    medicalConditions.Add(id, medicalCondition);

    WriteLine($"\n Patient registered successfully. ID: {id}");
}
static void ViewPatients(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastNames, Dictionary<int, int> ages, Dictionary<int, string> genders, Dictionary<int, string> addresses, Dictionary<int, string> phones, Dictionary<int, string> emails, Dictionary<int, string> bloodTypes)
{
    if (ids.Count == 0)
    {
        WriteLine("\nNo patients registered.");
        return;
    }

    WriteLine($"\n{"ID",-4} {"First Name",-15} {"Last Name",-15} {"Age",-5} {"Gender",-8} {"Phone",-12} {"Blood Type",-10}");
    WriteLine("========================================================================");

    foreach (var id in ids)
    {
        string genderDisplay = genders[id] switch
        {
            "M" => "Male",
            "F" => "Female",
            "O" => "Other",
            _ => "N/A"
        };

        WriteLine($"{id,-4} {names[id],-15} {lastNames[id],-15} {ages[id],-5} {genderDisplay,-8} {phones[id],-12} {bloodTypes[id],-10}");
    }
}

static void SearchPatient(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastNames, Dictionary<int, int> ages, Dictionary<int, string> genders, Dictionary<int, string> addresses, Dictionary<int, string> phones, Dictionary<int, string> emails, Dictionary<int, string> bloodTypes)
{
    if (ids.Count == 0)
    {
        WriteLine("\nNo patients to search.");
        return;
    }

    int searchOption;
    while (true)
    {
        WriteLine("\nSearch options:");
        WriteLine("1. Search by name/last name");
        WriteLine("2. Search by phone");
        WriteLine("Error: Please enter 1 or 2.");
    }

    switch (searchOption)
    {
        case 1:
            Write("Enter first name or last name: ");
            string nameSearch = ReadLine()?.ToLower() ?? "";
            bool foundName = false;

            WriteLine($"\n{"ID",-4} {"First Name",-15} {"Last Name",-15} {"Phone",-12} {"Email",-20}");
            WriteLine("================================================================");

            foreach (var id in ids)
            {
                string fullName = $"{names[id]} {lastNames[id]}".ToLower();
                if (fullName.Contains(nameSearch))
                {
                    foundName = true;
                    WriteLine($"{id,-4} {names[id],-15} {lastNames[id],-15} {phones[id],-12} {emails[id],-20}");
                }
            }

            if (!foundName)
                WriteLine($"No patients found matching: {nameSearch}");
            break;

        case 2:
            Write("Enter phone number: ");
            string phoneSearch = ReadLine() ?? "";
            bool foundPhone = false;

            WriteLine($"\n{"ID",-4} {"First Name",-15} {"Last Name",-15} {"Phone",-12} {"Address",-20}");
            WriteLine("================================================================");

            foreach (var id in ids)
            {
                if (phones[id].Contains(phoneSearch))
                {
                    foundPhone = true;
                    WriteLine($"{id,-4} {names[id],-15} {lastNames[id],-15} {phones[id],-12} {addresses[id],-20}");
                }
            }

            if (!foundPhone)
                WriteLine($"No patients found with phone: {phoneSearch}");
            break;
    }
}

static void EditPatient(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastNames, Dictionary<int, int> ages, Dictionary<int, string> genders, Dictionary<int, string> addresses, Dictionary<int, string> phones, Dictionary<int, string> emails, Dictionary<int, string> bloodTypes, Dictionary<int, string> allergies, Dictionary<int, string> medicalConditions)
{
    if (ids.Count == 0)
    {
        WriteLine("\nNo patients to edit.");
        return;
    }

    int idToEdit;
    while (true)
    {
        Write("Enter patient ID to edit: ");
        string idInput = ReadLine();

        if (!string.IsNullOrWhiteSpace(idInput) && int.TryParse(idInput, out idToEdit) && ids.Contains(idToEdit))
            break;
        WriteLine("Error: Please enter a valid patient ID.");
    }

    bool editing = true;
    while (editing)
    {
        WriteLine($"\nEditing patient: {names[idToEdit]} {lastNames[idToEdit]} (ID: {idToEdit})");
        WriteLine("1. First Name");
        WriteLine("2. Last Name");
        WriteLine("3. Age");
        WriteLine("4. Gender");
        WriteLine("5. Address");
        WriteLine("6. Phone");
        WriteLine("7. Email");
        WriteLine("8. Blood Type");
        WriteLine("9. Allergies");
        WriteLine("10. Medical Conditions");
        WriteLine("11. Finish editing");

        int fieldOption;
        while (true)
        {
            Write("Select field to edit: ");
            string input = ReadLine();

            if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out fieldOption) && fieldOption >= 1 && fieldOption <= 11)
                break;
            WriteLine("Error: Please enter a number between 1 and 11.");
        }

        switch (fieldOption)
        {
            case 1:
                string newName;
                while (true)
                {
                    Write($"Current first name: {names[idToEdit]}. New first name: ");
                    newName = ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                        break;
                    WriteLine("Error: First name cannot be empty.");
                }
                names[idToEdit] = newName;
                WriteLine("First name updated successfully.");
                break;

            case 2:
                string newLastName;
                while (true)
                {
                    Write($"Current last name: {lastNames[idToEdit]}. New last name: ");
                    newLastName = ReadLine();
                    if (!string.IsNullOrWhiteSpace(newLastName))
                        break;
                    WriteLine("Error: Last name cannot be empty.");
                }
                lastNames[idToEdit] = newLastName;
                WriteLine("Last name updated successfully.");
                break;

            case 3:
                int newAge;
                while (true)
                {
                    Write($"Current age: {ages[idToEdit]}. New age: ");
                    string ageInput = ReadLine();
                    if (!string.IsNullOrWhiteSpace(ageInput) && int.TryParse(ageInput, out newAge) && newAge > 0 && newAge < 150)
                        break;
                    WriteLine("Error: Please enter a valid age (1-149).");
                }
                ages[idToEdit] = newAge;
                WriteLine("Age updated successfully.");
                break;

            case 4:
                string newGender;
                while (true)
                {
                    Write($"Current gender: {genders[idToEdit]}. New gender (M/F/O): ");
                    newGender = ReadLine()?.ToUpper();
                    if (newGender == "M" || newGender == "F" || newGender == "O")
                        break;
                    WriteLine("Error: Please enter M (Male), F (Female) or O (Other).");
                }
                genders[idToEdit] = newGender;
                WriteLine("Gender updated successfully.");
                break;

            case 5:
                Write($"Current address: {addresses[idToEdit]}. New address: ");
                addresses[idToEdit] = ReadLine();
                WriteLine("Address updated successfully.");
                break;

            case 6:
                string newPhone;
                while (true)
                {
                    Write($"Current phone: {phones[idToEdit]}. New phone: ");
                    newPhone = ReadLine();
                    if (!string.IsNullOrWhiteSpace(newPhone) && newPhone.All(char.IsDigit))
                        break;
                    WriteLine("Error: Phone must contain only numbers.");
                }
                phones[idToEdit] = newPhone;
                WriteLine("Phone updated successfully.");
                break;

            case 7:
                Write($"Current email: {emails[idToEdit]}. New email: ");
                emails[idToEdit] = ReadLine();
                WriteLine("Email updated successfully.");
                break;

            case 8:
                Write($"Current blood type: {bloodTypes[idToEdit]}. New blood type: ");
                bloodTypes[idToEdit] = ReadLine();
                WriteLine("Blood type updated successfully.");
                break;

            case 9:
                Write($"Current allergies: {allergies[idToEdit]}. New allergies: ");
                allergies[idToEdit] = ReadLine();
                WriteLine("Allergies updated successfully.");
                break;

            case 10:
                Write($"Current medical conditions: {medicalConditions[idToEdit]}. New medical conditions: ");
                medicalConditions[idToEdit] = ReadLine();
                WriteLine("Medical conditions updated successfully.");
                break;

            case 11:
                editing = false;
                WriteLine("Finished editing patient.");
                break;
        }
    }
}

static void DeletePatient(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastNames, Dictionary<int, int> ages, Dictionary<int, string> genders, Dictionary<int, string> addresses, Dictionary<int, string> phones, Dictionary<int, string> emails, Dictionary<int, string> bloodTypes, Dictionary<int, string> allergies, Dictionary<int, string> medicalConditions)
{
    if (ids.Count == 0)
    {
        WriteLine("\nNo patients to delete.");
        return;
    }

    int idToDelete;
    while (true)
    {
        Write("Enter patient ID to delete: ");
        string idInput = ReadLine();

        if (!string.IsNullOrWhiteSpace(idInput) && int.TryParse(idInput, out idToDelete) && ids.Contains(idToDelete))
            break;
        WriteLine("Error: Please enter a valid patient ID.");
    }

    WriteLine($"Patient found: {names[idToDelete]} {lastNames[idToDelete]}");

    int confirm;
    while (true)
    {
        Write("Are you sure you want to delete this patient? 1 = Yes, 2 = No: ");
        string confirmInput = ReadLine();

        if (!string.IsNullOrWhiteSpace(confirmInput) && int.TryParse(confirmInput, out confirm) && (confirm == 1 || confirm == 2))
            break;
        WriteLine("Error: Please enter 1 for Yes or 2 for No.");
    }

    if (confirm == 1)
    {
        names.Remove(idToDelete);
        lastNames.Remove(idToDelete);
        ages.Remove(idToDelete);
        genders.Remove(idToDelete);
        addresses.Remove(idToDelete);
        phones.Remove(idToDelete);
        emails.Remove(idToDelete);
        bloodTypes.Remove(idToDelete);
        allergies.Remove(idToDelete);
        medicalConditions.Remove(idToDelete);
        ids.Remove(idToDelete);
        WriteLine("Patient deleted successfully.");
    }
    else
    {
        WriteLine("Deletion cancelled.");
    }
}