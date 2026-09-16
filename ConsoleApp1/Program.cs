using System.Net;
using System.Security.Cryptography.X509Certificates;

string enhet1 = "Projektor";
//string enhetstyp1 = "Projektor";
string id1 = "ID-100";
string status1 = "Aktiv";
int price1 = 250;

string enhet2 = "Samsung Display";
//string enhetstyp2 = "Bildskärmsutrustning";
string id2 = "ID-200";
string status2 = "Aktiv";
int price2 = 100;

string enhet3 = "Laptop";
// string enhetstyp3 = "Dator";
string id3 = "ID-300";
string status3 = "Service";
int price3 = 800;

bool programIsOn = true;

while (programIsOn)
{
    // -----------------------------------------
    Console.WriteLine("""
        Välkommen till enhetsregistret, du har 3 val:

        [1] - Visa alla produkter

        [2] - Mata in ny produkt

        [3] - Stäng programmet

        """);

    int valSiffra = Convert.ToInt16(Console.ReadLine());
    switch (valSiffra)
    {
        case 1:
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

            // -----                ALL UTMATNING:                  ----
            Console.WriteLine("=======================");
            Console.WriteLine("ENHETREGISTRET");
            Console.WriteLine($"{row1}");
            Console.WriteLine($"{row2}");
            Console.WriteLine($"{row3}");

            // Sammanfattning (Del9):
            Console.WriteLine("\n=======================");
            Console.WriteLine("\nSAMMANFATTNING TOTALT ");
            Console.WriteLine("\nRegister: 4 enheter registerarde\n");
            break;
        case 2:
            
            // Enhet 4 - med inmatning och felhantering för inmatning:
            Console.WriteLine("\nMata in information om enhet 4.\nAnge namn på enheten: ");
            string enhet4 = Console.ReadLine();
            Console.WriteLine("Ange ID: ");
            string id4 = Console.ReadLine();
            Console.WriteLine("Ange pris: ");
            int price4 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Ange status (Aktiv/Inaktiv/Service): ");
            string status4 = Console.ReadLine();
            Console.WriteLine("Är pdorukten en Dator, Projektor eller Skärm? (om du är osäker skriv 'Övrigt')\nAnge svar: ");
            string enhetstyp4 = Console.ReadLine();
            Console.WriteLine("Kontrollfrågor:\n");

            Console.WriteLine("Ska produkten markeras som 'kritsik'? [J/N]");
            string kritiskPin = Console.ReadLine();
          

            // Beräkningar:
            double moms = 0.25;
            double bruttoPrice4 = price4 * (1 + moms);

            bool priceWithRange = price4 > 300 && price4 <= 700;
            bool highPrice = price4 >= 700;
            bool prioProdukt = highPrice && status4 == "Aktiv";

            bool isKritisk = kritiskPin == "J"; // kan använda ToLower här och i andra bools
            bool omKritisk = status4 == "Service" || isKritisk;
            bool högRisk = status4 == "Service" && highPrice;
            bool medelRisk = status4 == "Service" || status4 == "Inaktiv";

            // Kostnadsbedömning:
            Console.WriteLine("KOSTNADSBEDÖMNING");
            if (highPrice) { Console.WriteLine("Produkten har hög kostnad."); }
            else if (priceWithRange) { Console.WriteLine("Prisen ligger i normal kostnad."); }
            else { Console.WriteLine("Produkten har låg kostnad."); }

            // Prioritering:
            Console.WriteLine("PRIORITERINGSSTATUS");
            if (prioProdukt) { Console.WriteLine("Prioriterad produkt!"); }
            else if (enhetstyp4 == "Övrigt" || status4 == "Inaktiv") { Console.WriteLine("Kontroll krävs"); }
            else { Console.WriteLine("Produkten är i normal skick"); }

            // Riskbedömning (Del 8):
            Console.WriteLine("RISKBEDÖMNING");
            if (högRisk) { Console.WriteLine("Riskbedömning: Kritisk"); }
            else if (medelRisk) { Console.WriteLine("Riskbedömning: Medelrisk"); }
            else { Console.WriteLine("Riskbedömning: Låg risk"); }
           
            // Kritisk bedömning:
            Console.WriteLine("KRIS STATUS:");
            if (omKritisk) { Console.WriteLine("Teknisk kontroll krävs"); }
            else if (status4 != "Service" && isKritisk == false)
            { Console.WriteLine("Ingen omedelbar åtgärd"); }
            else if (isKritisk && price4 >= 700)
            { Console.WriteLine(""); }
            else if (isKritisk && highPrice && (enhetstyp4 == "Porjektor" || enhetstyp4 == "Dator"))
            { Console.WriteLine("VARNING: Kritisk dyr utrustning"); }

            // Rad 4
            string row4 =
            id4 + " | "
            + "Namn: " + enhet4 + " | "
            + "Pris exkl. moms: " + price4
            + " kr | Pris inkl.moms: "
            + bruttoPrice4 + " kr | "
            + "Status: " + status4;

            int totalPrice = price1 + price2 + price3 + price4;
            double bruttoPris = (price1 + price2 + price3 + price4) * (1 * moms);

            Console.WriteLine("\n=======================");
            Console.WriteLine("\nNy enhet registrerat: ");
            Console.WriteLine($"{row4}");

            // TYPINFORMATION
            Console.WriteLine("\nTYPINFORMATION");
            switch (enhetstyp4)
            {
                case "Dator":
                    Console.WriteLine("Produktbeskrivning: Utrustning för datorarbete.");
                    break;
                case "Projektor":
                    Console.WriteLine("Produktbeskrivning: Utrustning för presentation.");
                    break;
                case "Skärm":
                    Console.WriteLine("Produktbeskrivning: Bildskärmsutrustning.");
                    break;
                default:
                    Console.WriteLine("Produktbeskrivning: Annan registrerad uttrustning");
                    break;
            }

            // Servicebedömning
            Console.WriteLine("SERVICEBEDÖMNING");
            switch (status4)
            {
                case "Aktiv":
                    Console.WriteLine("Service status: Aktiv");
                    break;
                case "Inaktiv":
                    Console.WriteLine("Service status: Inaktiv.");
                    break;
                case "Service":
                    Console.WriteLine("Service status: I servicebehov");
                    break;
                default:
                    Console.WriteLine("Service status: Okänd status.");
                    break;
            }
            break;
        case 3:
            programIsOn = false;
            break;
    }

    // -----------------------------------------
}










/*Console.WriteLine($"Totalt värde exkl. moms: {totalPrice} kr.");*/

