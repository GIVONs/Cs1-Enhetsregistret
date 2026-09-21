using ConsoleApp1.UI.Helpers;
using System.Net;
using System.Security.Cryptography.X509Certificates;
// Startvärden:
double moms = 0.25;

string enhet1 = "Projektor";
string enhetsTyp1 = "Projektor";
string id1 = "ID-100";
string status1 = "Aktiv";
int price1 = 250;

string enhet2 = "Samsung Display";
string enhetsTyp2 = "Bildskärmsutrustning";
string id2 = "ID-200";
string status2 = "Aktiv";
int price2 = 100;

string enhet3 = "Laptop";
string enhetsTyp3 = "Dator";
string id3 = "ID-300";
string status3 = "Service";
int price3 = 800;

/* string enhet4;
string enhetstTyp4;
string id4;
string status4;
int price4; */

// Returnerar dessa värden till topp (ersätt dessa):
string result4 = null;
int totalPriceMed4 = 0;
double totalMomsPrisMed4 = 0;
double bruttoPrisMed4 = 0;

bool programIsOn = true;
Console.WriteLine("Välkommen till enhetsregistret!");
while (programIsOn)
{
    // Generella beräkningar
    int totalPrice = price1 + price2 + price3;
    double momsPåPris = totalPrice * (1 * moms);
    double bruttoPris = totalPrice + momsPåPris;

    int riskScore = 0;

    // -----------------------------------------
    Console.WriteLine("\n");
    UI.ShowMenu();

    int valSiffra = Convert.ToInt16(Console.ReadLine());
    if (valSiffra == 1 || valSiffra == 2 || valSiffra == 3)
    {

        switch (valSiffra)
        {
            case 1:
                // -----                ALL UTMATNING:                  ----
                Console.Clear();
                Console.WriteLine("------------- ENHETREGISTRET ------------");

                Console.WriteLine(UI.ShowRow(id1, enhet1, enhetsTyp1, status1, price1, moms));
                Console.WriteLine(UI.ShowRow(id2, enhet2, enhetsTyp2, status2, price2, moms));
                Console.WriteLine(UI.ShowRow(id3, enhet3, enhetsTyp3, status3, price3, moms));

                if (result4 != null)
                {
                    Console.WriteLine(result4);
                }

                Console.WriteLine("\n=============================================");
                Console.WriteLine("-------- SAMMANFATTNING TOTALT -------");
                if(result4 != null)
                {
                    Console.WriteLine("\nRegister: 4 enheter registerarde\n");
                    Console.WriteLine($"""
                        Total pris exkl. moms:              {totalPriceMed4} kr.
                        Total pris inkl. moms (brutto):     {bruttoPrisMed4} kr.            
                        """);
                    Console.WriteLine("=============================================");
                } else
                {
                    Console.WriteLine("\nRegister: 3 enheter registerarde\n");
                    Console.WriteLine($"""
                        Total pris exkl. moms:              {totalPrice} kr.
                        Total pris inkl. moms (brutto):     {bruttoPris} kr.            
                        """);
                    Console.WriteLine("=============================================");
                }
                break;

            case 2:
                //  --------------------------- ENHET 4 ----------------------------------
                string justExit = "exit";

                Console.WriteLine("\nMata in information om enhet 4.\nAnge namn på enheten: ");
                string enhet4 = Console.ReadLine();
                if (enhet4 == justExit.ToLower() || enhet4 == null || enhet4.Trim() == "")
                {
                    Console.WriteLine("\nFel inmatning.");
                    break;
                }

                Console.WriteLine("Ange ID: ");
                string id4 = Console.ReadLine();
                if (id4 == justExit.ToLower() || id4 == null || id4.Trim() == "")
                {
                    Console.WriteLine("\nFel inmatning.");
                    break;
                }

                Console.WriteLine("Ange pris: ");
                string inputPrice4 = Console.ReadLine();
                if (inputPrice4 == justExit.ToLower())
                {
                    Console.WriteLine("\nFel inmatning, vänligen skriv enbart siffror.");
                    break;
                }
                int price4 = 0; // The future return value after TryParse()
                if (int.TryParse(inputPrice4, out price4))
                {/*just continue without doing anything*/}
                else
                {
                    Console.WriteLine("\nFel inmatning, vänligen skriv enbart siffror.");
                    break;
                }

                Console.WriteLine("Ange status (Aktiv/Inaktiv/Service): ");
                string status4 = Console.ReadLine();
                status4 = status4.ToLower();
                if (status4 == justExit.ToLower() 
                    || status4 == null 
                    || status4.Trim() == "" 
                    || (status4 != "aktiv"
                    && status4 != "inaktiv"
                    && status4 != "service"))
                {
                    Console.WriteLine("\nFel inmatning.");
                    break;
                }

                Console.WriteLine("Vänligen ange typen av produkt [Dator/Projektor/Skärm/Nätverksutrustning] (om du är osäker skriv 'Övrigt')\nAnge svar: ");
                string enhetsTyp4 = Console.ReadLine();
                enhetsTyp4 = enhetsTyp4.ToLower();
                if (enhetsTyp4 == justExit.ToLower() 
                    || enhetsTyp4 == null 
                    || enhetsTyp4.Trim() == ""
                    || (enhetsTyp4 != "dator"
                    && enhetsTyp4 != "projektor"
                    && enhetsTyp4 != "skärm"
                    && enhetsTyp4 != "nätverksutrustning"
                    && enhetsTyp4 != "övrigt"))
                {
                    Console.WriteLine("\nFel inmatning.");
                    break;
                }

                Console.Clear(); // ------------------- KONTROLLFRÅGOR -------------------------------------
                Console.WriteLine("\nKontrollfrågor:");
                Console.WriteLine("Ska produkten markeras som 'kritsik'? [J/N]: ");
                string kritiskMarkör = Console.ReadLine();

                kritiskMarkör = kritiskMarkör.ToUpper();
                if (kritiskMarkör == null || kritiskMarkör.Trim() == "" || (kritiskMarkör != "J" && kritiskMarkör != "N"))
                {
                    Console.WriteLine("\nFel inmatning.");
                    break;
                }

                Console.WriteLine("Har enheten garanti? [J/N]: ");
                string garanti = Console.ReadLine();
                garanti = garanti.ToUpper();
                if (garanti == null || garanti.Trim() == "" || (garanti != "J" && garanti != "N"))
                {
                    Console.WriteLine("\nFel inmatning.");
                    break;
                }

                Console.WriteLine("Är enheten köpt på ramavtal? [J/N]: ");
                string ramAvtal = Console.ReadLine();
                ramAvtal = ramAvtal.ToUpper();
                if (ramAvtal == null || ramAvtal.Trim() == "" || (ramAvtal != "J" && ramAvtal != "N"))
                {
                    Console.WriteLine("\nFel inmatning.");
                    break;
                }

                // --------------------------- Beräkningar för Enhet 4 ------------------------------------
                double bruttoPrice4 = price4 * (1 + moms);

                bool priceWithRange = price4 > 300 && price4 <= 700;
                bool highPrice = price4 >= 900;
                bool prioProdukt = highPrice && status4 == "aktiv";

                bool isKritisk = kritiskMarkör == "J";
                bool omKritisk = status4 == "service" || isKritisk;
                bool högRisk = status4 == "service" && highPrice;
                bool medelRisk = status4 == "service" || status4 == "inaktiv";

                // Risknivå - Beräkningar
                bool lowRiskScore = riskScore <= 2;
                bool mediumRiskScore = riskScore >= 3 && riskScore <= 5;
                bool highRiskScore = riskScore >= 6 && riskScore <= 8;
                bool criticalRiskScore = riskScore >= 9;

                // Risksystem - Beräkningar
                bool checkScore = true;
                while (checkScore)
                {
                    switch (status4)
                    {
                        case "service":
                            riskScore += 3;
                            break;
                        case "inaktiv":
                            riskScore += 2;
                            break;
                    }
                    if(kritiskMarkör == "J") { riskScore += 4; }
                    if (kritiskMarkör == "J" && (enhetsTyp4 == "nätvekrsutrustning")) { riskScore += 3; }
                    if (enhetsTyp4 == "projektor" && (price4 >= 900)) { riskScore += 2; } else if(enhetsTyp4 == "övrigt") { riskScore += 1; }
                    if (highPrice) { riskScore += 2; }

                    checkScore = false;
                }

                // ------------------ REGLER (Utskrifter av Bedömningar) ------------------------

                string row4 = UI.ShowRow(id4, enhet4, enhetsTyp4, status4, price4, moms);

                Console.Clear();
                Console.WriteLine("\nNy enhet registrerat: ");
                Console.WriteLine($"{row4}");

                await Task.Delay(500);
                Console.WriteLine("\nALLMÄN BEDÖMNING\n");
                // Kostnadsbedömning:
                if (highPrice) { Console.WriteLine("Kostnadsbedömning: Produkten har hög kostnad.\n"); }
                else if (priceWithRange) { Console.WriteLine("Kostnadsbedömning: Prisen ligger i normal kostnad.\n"); }
                else { Console.WriteLine("Kostnadsbedömning: Produkten har låg kostnad.\n"); }

                // Prioritering:
                if (prioProdukt) { Console.WriteLine("Prioriteringsstatus: Prioriterad produkt!\n"); }
                else if (enhetsTyp4 == "övrigt" || status4 == "inaktiv") { Console.WriteLine("Prioriteringsstatus: Kontroll krävs\n"); }
                else { Console.WriteLine("Prioriteringsstatus: Produkten är i normal skick\n"); }

                // Riskbedömning (Del 8):
                if (högRisk) { Console.WriteLine("Riskbedömning: Kritisk\n"); }
                else if (medelRisk) { Console.WriteLine("Riskbedömning: Medelrisk\n"); }
                else { Console.WriteLine("Riskbedömning: Låg risk\n"); }

                // Kritisk bedömning:
                if (omKritisk) { Console.WriteLine("Kris status: Teknisk kontroll krävs\n"); }
                else if (status4 != "service" && isKritisk == false)
                { Console.WriteLine("Kris status: Ingen omedelbar åtgärd\n"); }
                else if (isKritisk && price4 >= 700)
                { Console.WriteLine(""); }
                else if (isKritisk && highPrice && (enhetsTyp4 == "projektor" || enhetsTyp4 == "dator"))
                { Console.WriteLine("VARNING: Kritisk dyr utrustning!\n"); }

                // TYPINFORMATION
                Console.WriteLine("\nTYPINFORMATION\n");
                switch (enhetsTyp4)
                {
                    case "dator":
                        Console.WriteLine("Produktbeskrivning: Utrustning för datorarbete.");
                        break;

                    case "projektor":
                        Console.WriteLine("Produktbeskrivning: Utrustning för presentation.");
                        break;

                    case "skärm":
                        Console.WriteLine("Produktbeskrivning: Bildskärmsutrustning.");
                        break;
                    case "nätverksutrustning":
                        Console.WriteLine("Produktbeskrivning: Utrustning för nätverk.");
                        break;

                    default:
                        Console.WriteLine("Produktbeskrivning: Annan registrerad uttrustning");
                        break;
                }

                // Servicebedömning
                Console.WriteLine("\nSERVICEBEDÖMNING\n");
                switch (status4)
                {
                    case "aktiv":
                        Console.WriteLine("""
                            Service status: Aktiv

                            ---------------------------------------------
                            """);
                        break;

                    case "inaktiv":
                        Console.WriteLine("""
                            Service status: Inaktiv

                            ---------------------------------------------
                            """);
                        break;

                    case "service":
                        Console.WriteLine("""
                            Service status: I servicebehov
                            
                            ---------------------------------------------
                            """);
                        break;

                    default:
                        Console.WriteLine("""
                            Service status: Okänd status

                            ---------------------------------------------
                            """);
                        break;
                }

                // Riskpoäng - Bedöminng
                await Task.Delay(500);
                Console.WriteLine("\nRISKBEDÖMNING\n");
                if(lowRiskScore) 
                {
                    Console.WriteLine($"""
                        Riskpoäng:  {riskScore}
                        Risknivå:   Låg
                        """);
                } else if(mediumRiskScore)
                {
                    Console.WriteLine($"""
                        Riskpoäng:  {riskScore}
                        Risknivå:   Medel
                        """);
                }
                else if(highRiskScore)
                {
                    Console.WriteLine($"""
                        Riskpoäng:  {riskScore}
                        Risknivå:   Hög
                        """);
                }
                else if (criticalRiskScore)
                {
                    Console.WriteLine($"""
                        Riskpoäng:  {riskScore}
                        Risknivå:   Kritisk
                        """);
                }

                // Serviceprioritet - Bedöminng
                Console.WriteLine("\nSERVICEBEDÖMNING\n");
                if (status4 == "service")
                {
                    Console.WriteLine($"""
                        Serviceprioritet: Normal.
                        """);
                }
                else if (highPrice && (status4 == "service"))
                {
                    Console.WriteLine($"""
                        Serviceprioritet: Hög.
                        """);
                }
                else if (criticalRiskScore && (status4 == "service") || criticalRiskScore && (status4 == "inaktiv"))
                {
                    Console.WriteLine($"""
                        Serviceprioritet: Akut.
                        """);
                }
                else
                {
                    Console.WriteLine($"""
                        Serviceprioritet: Ingen.
                        """);
                }
                Console.WriteLine("---------------------------------------------");

                // Returvärden
                totalPriceMed4 = price1 + price2 + price3 + price4;
                totalMomsPrisMed4 = (price1 + price2 + price3 + price4) * (1 * moms);
                bruttoPrisMed4 = totalPriceMed4 + totalMomsPrisMed4;
                result4 = row4;

                break; // break för "case 2:"
            case 3:
                programIsOn = false;
                break;
        }
    } else
    {
        Console.Clear();
        Console.WriteLine("""

            =========================================
            Fel inmatning, välj en siffra mellan 1-3.
            =========================================


            """);
    }

}
Console.WriteLine("Klicka på ENTER för att stänga programemt...");