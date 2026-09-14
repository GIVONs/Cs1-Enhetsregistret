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

//-----------------------------
// Enhet 4 - med inmatning
Console.WriteLine("\nMata in information om enhet 4:\nAnge ID: ");
string id4 = Console.ReadLine();

Console.WriteLine("Ange namn: ");
string enhet4 = Console.ReadLine();

Console.WriteLine("Ange pris: ");
int price4 = Convert.ToInt16(Console.ReadLine());

Console.WriteLine("Ange status: ");
string status4 = Console.ReadLine();
// ---------------------------

// Beräkningar:
double moms = 0.25;
double bruttoPrice4 = price4 * (1 + moms);

// Rows:
string row1 =
    id1 + " | "
    + "Namn: " + enhet1 + " | "
    + "Price: " + price1 + " kr | "
    + "Status: " + status1;
string row2 =
    id2 + " | "
    + "Namn: " + enhet2 + " | "
    + "Price: " + price2 + " kr | "
    + "Status: " + status2;
string row3 =
    id3 + " | "
    + "Namn: " + enhet3 + " | "
    + "Price: " + price3 + " kr | "
    + "Status: " + status3;
string row4 =
    id4 + " | "
    + "Namn: " + enhet4 + " | "
    + "Pris exkl. moms: " + price4 
    + " kr | Pris inkl.moms: " 
    + bruttoPrice4 + " kr | " 
    + "Status: " + status4;


// -----                ALL UTMATNING:        -        ----
Console.WriteLine("Emnhetsregistret:");
Console.WriteLine("=======================");

Console.WriteLine($"\n{row1}");
Console.WriteLine($"{row2}");
Console.WriteLine($"{row3}");
Console.WriteLine("\nNy enhet registrerat: ");
Console.WriteLine($"{row4}");

Console.WriteLine("\n=======================");

Console.WriteLine("4 enheter registerarde");

int totalPrice = price1 + price2 + price3 + price4;
double bruttoPris = (price1 + price2 + price3 + price4) * (1 * moms);

Console.WriteLine($"\nTotalt värde exkl. moms: {totalPrice} kr.");

// Dag 3:
bool priceWithRange = price4 > 300 && price4 <= 700;
bool highPrice = price4 >= 700;

if (highPrice)
{
    Console.WriteLine("\nProdukten har hög kostnad.");
}
else if (priceWithRange)
{
    Console.WriteLine("\nPrisen ligger i normal kostnad.");
}
else
{
    Console.WriteLine("\nProdukten har låg kostnad.");
}

// Switch sats:
switch (status4) // Vi vill läsa av värdet på status4 (Oftast jämföra strängvärden men också andra saker)
{
    case "Aktiv":
        Console.WriteLine("Status är aktiv");
        break;
    case "Inaktiv":
        Console.WriteLine("Status är inaktiv.");
        break;
    case "Service":
        Console.WriteLine("Åtgärder behövs");
        break;
    default:
        Console.WriteLine("Nu valde du en status som inte finns.");
        break;
}