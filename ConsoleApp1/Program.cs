string enhet1 = "Laptopsal 1";
string id1 = "D-100";
string status1 = "Aktiv";
int price1 = 250;

string enhet2 = "Laptopsal 1";
string id2 = "D-200";
string status2 = "Aktiv";
int price2 = 100;

string enhet3 = "Laptopsal 1";
string id3 = "D-300";
string status3 = "Aktiv";
int price3 = 800;

// Rad 2 i vår register 
string row2 = "ID "
    + id2 + " | "
    + enhet2 + " | "
    + price2
    + "Status: "
    + status2;


Console.WriteLine("Emnhetsregistret:");
Console.WriteLine("=======================");

Console.WriteLine($"\nID-100 | Namn : {enhet1} | Price: {price1} | Status : {status1.ToString()}");
Console.WriteLine($"ID-200 | Namn : {enhet2} | Price: {price2} | Status : {status2.ToString()}");
Console.WriteLine($"ID-300 | Namn : {enhet3} | Price: {price3} | Status : {status3.ToString()}");

Console.WriteLine("\n=======================");

Console.WriteLine("2 enheter registerarde");
