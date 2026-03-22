//Gabriela A. Ramirez, 2025-0993

Console.WriteLine("Bienvenido a mi lista de Contactes");

bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contacto     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 2:
            ShowContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 3:
            SearchContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 4:
            ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 5:
            DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 6:
            runing = false;
            break;

        default:
            Console.WriteLine("Ytsb");
            break;
    }
}

// MÉTODOS

static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
    Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
    Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el nombre de la persona");
    string name = Console.ReadLine();
    Console.WriteLine("Digite el apellido de la persona");
    string lastname = Console.ReadLine();
    Console.WriteLine("Digite la dirección");
    string address = Console.ReadLine();
    Console.WriteLine("Digite el telefono de la persona");
    string phone = Console.ReadLine();
    Console.WriteLine("Digite el email de la persona");
    string email = Console.ReadLine();
    Console.WriteLine("Digite la edad de la persona en números");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);

    Console.WriteLine("Contacto agregado exitosamente.");
}

static void ShowContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
    Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
    Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    if (ids.Count == 0)
    {
        Console.WriteLine("No hay contactos registrados.");
        return;
    }

    Console.WriteLine($"{"ID",-5} {"Nombre",-15} {"Apellido",-15} {"Dirección",-20} {"Telefono",-15} {"Email",-25} {"Edad",-6} {"Mejor Amigo?"}");
    Console.WriteLine(new string('_', 110));

    foreach (var id in ids)
    {
        string isBestFriendStr = bestFriends[id] ? "Si" : "No";
        Console.WriteLine($"{id,-5} {names[id],-15} {lastnames[id],-15} {addresses[id],-20} {telephones[id],-15} {emails[id],-25} {ages[id],-6} {isBestFriendStr}");
    }
}

static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
    Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
    Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el nombre del contacto que desea buscar");
    string searchName = Console.ReadLine().ToLower();

    bool found = false;

    foreach (var id in ids)
    {
        if (names[id].ToLower().Contains(searchName) || lastnames[id].ToLower().Contains(searchName))
        {
            string isBestFriendStr = bestFriends[id] ? "Si" : "No";
            Console.WriteLine($"\nContacto encontrado:");
            Console.WriteLine($"  ID:           {id}");
            Console.WriteLine($"  Nombre:       {names[id]} {lastnames[id]}");
            Console.WriteLine($"  Dirección:    {addresses[id]}");
            Console.WriteLine($"  Telefono:     {telephones[id]}");
            Console.WriteLine($"  Email:        {emails[id]}");
            Console.WriteLine($"  Edad:         {ages[id]}");
            Console.WriteLine($"  Mejor Amigo:  {isBestFriendStr}");
            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine("No se encontró ningún contacto con ese nombre.");
    }
}

static void ModifyContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
    Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
    Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    if (ids.Count == 0)
    {
        Console.WriteLine("No hay contactos registrados.");
        return;
    }

    ShowContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

    Console.WriteLine("\nDigite el ID del contacto que desea modificar");
    int id = Convert.ToInt32(Console.ReadLine());

    if (!ids.Contains(id))
    {
        Console.WriteLine("No existe un contacto con ese ID.");
        return;
    }

    Console.WriteLine("Ingrese el nuevo nombre (deje vacío para mantener el actual)");
    string newName = Console.ReadLine();
    if (!string.IsNullOrEmpty(newName)) names[id] = newName;

    Console.WriteLine("Ingrese el nuevo apellido (deje vacío para mantener el actual)");
    string newLastname = Console.ReadLine();
    if (!string.IsNullOrEmpty(newLastname)) lastnames[id] = newLastname;

    Console.WriteLine("Ingrese la nueva dirección (deje vacío para mantener la actual)");
    string newAddress = Console.ReadLine();
    if (!string.IsNullOrEmpty(newAddress)) addresses[id] = newAddress;

    Console.WriteLine("Ingrese el nuevo telefono (deje vacío para mantener el actual)");
    string newPhone = Console.ReadLine();
    if (!string.IsNullOrEmpty(newPhone)) telephones[id] = newPhone;

    Console.WriteLine("Ingrese el nuevo email (deje vacío para mantener el actual)");
    string newEmail = Console.ReadLine();
    if (!string.IsNullOrEmpty(newEmail)) emails[id] = newEmail;

    Console.WriteLine("Ingrese la nueva edad (0 para mantener la actual)");
    int newAge = Convert.ToInt32(Console.ReadLine());
    if (newAge != 0) ages[id] = newAge;

    Console.WriteLine("¿Es mejor amigo? 1. Si, 2. No, 0. Mantener actual");
    int bestFriendOption = Convert.ToInt32(Console.ReadLine());
    if (bestFriendOption == 1) bestFriends[id] = true;
    else if (bestFriendOption == 2) bestFriends[id] = false;

    Console.WriteLine("Contacto modificado exitosamente.");
}

static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
    Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
    Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    if (ids.Count == 0)
    {
        Console.WriteLine("No hay contactos registrados.");
        return;
    }

    ShowContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

    Console.WriteLine("\nDigite el ID del contacto que desea eliminar");
    int id = Convert.ToInt32(Console.ReadLine());

    if (!ids.Contains(id))
    {
        Console.WriteLine("No existe un contacto con ese ID.");
        return;
    }

    Console.WriteLine($"¿Está seguro que desea eliminar a {names[id]} {lastnames[id]}? 1. Si, 2. No");
    int confirm = Convert.ToInt32(Console.ReadLine());

    if (confirm == 1)
    {
        ids.Remove(id);
        names.Remove(id);
        lastnames.Remove(id);
        addresses.Remove(id);
        telephones.Remove(id);
        emails.Remove(id);
        ages.Remove(id);
        bestFriends.Remove(id);

        Console.WriteLine("Contacto eliminado exitosamente.");
    }
    else
    {
        Console.WriteLine("Operación cancelada.");
    }
}

