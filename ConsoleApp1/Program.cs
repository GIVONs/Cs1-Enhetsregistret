//                              Dag 1 & 2

string enhet1 = "Laptopsal 1";
string id1 = "ID-100";
string status1 = "Aktiv";
int price1 = 250;

string enhet2 = "Laptopsal 1";
string id2 = "ID-200";
string status2 = "Aktiv";
int price2 = 100;

string enhet3 = "Laptopsal 1";
string id3 = "ID-300";
string status3 = "Aktiv";
int price3 = 800;

// Rad 2 i vår register 
string row2 =
    id2 + " | "
    + "Namn: " + enhet2 + " | "
    + "Price: " + price2 + " kr | "
    + "Status: " + status2;

// Rad 3 i vår register
string row3 =
    id3 + " | "
    + "Namn: " + enhet3 + " | "
    + "Price: " + price3 + " kr | "
    + "Status: " + status3;


// ---------------------------------------------------------------

//                      Dag 3 - Självstudier 9 Sept
Console.WriteLine("\nMata in information om enhet 4:\nAnge ID: ");
string id4 = Console.ReadLine();

Console.WriteLine("Ange namn: ");
string enhet4 = Console.ReadLine();

Console.WriteLine("Ange pris: ");
int price4 = Convert.ToInt16(Console.ReadLine());

Console.WriteLine("Ange status: ");
string status4 = Console.ReadLine();

// Rad 4

string row4 =
    id4 + " | "
    + "Namn: " + enhet4 + " | "
    + "Price: " + price4 + " kr | "
    + "Status: " + status4;


// -----                ALL UTMATNING:                ----
Console.WriteLine("Emnhetsregistret:");
Console.WriteLine("=======================");

Console.WriteLine($"\n{id1} | Namn: {enhet1} | Price: {price1} kr | Status: {status1.ToString()}");
Console.WriteLine(Convert.ToString(row2));
Console.WriteLine($"{row3}");

Console.WriteLine("\nNy enhet:");
Console.WriteLine(Convert.ToString(row4));

Console.WriteLine("\n=======================");

Console.WriteLine("2 enheter registerarde");

