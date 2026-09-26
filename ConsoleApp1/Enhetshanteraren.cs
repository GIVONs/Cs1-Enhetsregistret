using ConsoleApp1.Helpers;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    public class Enhetshanteraren
    {
        // Public (att den är åtkommlig), Static (att den behöver inte instansieras, bara anropa).
        // -------------------------------- STARTVÄRDEN -----------------------
        // Ignorera "make variables readonly" meddelandet, readonly är för konstanta värden, inte flexibla.
        //  Readonly påpekar bara att dessa värden är inte användna än (dem blir färgade när dem används).
        //  Detta händer när du först försöker skapa dessa startvärden, innan du ens använder dem i senare kod.

        string enhet1 = "Projektor";
        string enhetsTyp1 = "Projektor";
        string id1 = "ID-100";
        string status1 = "Aktiv";
        decimal price1 = 250;

        string enhet2 = "Samsung Display";
        string enhetsTyp2 = "Bildskärmsutrustning";
        string id2 = "ID-200";
        string status2 = "Aktiv";
        decimal price2 = 100;

        string enhet3 = "Laptop";
        string enhetsTyp3 = "Dator";
        string id3 = "ID-300";
        string status3 = "Service";
        decimal price3 = 800;

        // ENHET4; Startvärden
        string enhet4;
        string enhetstTyp4;
        string id4;
        string status4;
        decimal price4;


        public void Start() 
        {

            // ---------------- KALKYLRESURSER -------------------
            decimal moms = 0.25m;
           

            // --------------- Värden ----------------------------
            string row1 = UI.ShowRow(id1, enhet1, enhetsTyp1, status1, price1, moms);
            string row2 = UI.ShowRow(id2, enhet2, enhetsTyp2, status2, price2, moms);
            string row3 = UI.ShowRow(id3, enhet3, enhetsTyp3, status3, price3, moms);
            string row4 = null;

            bool programIsOn = true;
            Console.WriteLine("Välkommen till enhetsregistret!");
            
            while (programIsOn)
            {

                Console.WriteLine("\n");
                UI.ShowMenu1(); //------------------------------------------------------------------- MENY 1

                int valSiffra = Convert.ToInt16(Console.ReadLine());
                if (valSiffra == 1 || valSiffra == 2 || valSiffra == 3)
                {

                    switch (valSiffra)
                    {
                        case 1:
                            UI.ShowMenu2(); //-------------------------------------------------------------------- Enhetshanteraren

                            valSiffra = Convert.ToInt16((Console.ReadLine()));
                            if (valSiffra == 1 || valSiffra == 2 || valSiffra == 3)
                            {
                                switch (valSiffra) 
                                {
                                    case 1:
                                        UI.ShowAllProducts(row1, row2, row3, row4);
                                        break;

                                    case 2:
                                        UI.EntityRegistryMenu();//-------------------------------------------------------- Datameny för nya enheten

                                        valSiffra = Convert.ToInt16((Console.ReadLine()));
                                        if (valSiffra == 1 || valSiffra == 2 || valSiffra == 3)
                                        {
                                            switch (valSiffra)
                                            {
                                                case 1:
                                                    Console.WriteLine("\nMata in enhetens namn: ");
                                                    enhet4 = UI.ReadString(enhet4);

                                                    Console.WriteLine("\nMata in enhetens ID: ");
                                                    id4 = UI.ReadString(id4);

                                                    Console.WriteLine("\nMata in enhetens typ: ");
                                                    enhetstTyp4 = UI.ReadString(enhetstTyp4);

                                                    Console.WriteLine("\nAnge status (Aktiv / Inaktiv / Service): ");
                                                    status4 = UI.ReadString(status4);

                                                    Console.WriteLine("\nMata in enhetens pris: ");
                                                    price4 = UI.ReadDecimal(); // behöver inte en input argument 

                                                    row4 = UI.ShowRow(id4, enhet4, enhetstTyp4, status4, price4, moms);

                                                    Console.WriteLine(row4);
                                                    Console.ReadKey();
                                                    break;

                                                case 2:

                                                    break;

                                                case 3: // ----- Priserreduceringar index
                                                    if (enhet4 != null)
                                                    {
                                                        UI.ShowSaleMenu();
                                                        valSiffra = Convert.ToInt16((Console.ReadLine()));
                                                        if (valSiffra == 1 || valSiffra == 2)
                                                        {
                                                            switch (valSiffra)
                                                            {
                                                                case 1: // ----- Pris index


                                                                    break;

                                                                case 2:

                                                                    continue;

                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Du måste mata in data för en enhet först.\n");

                                                        Console.WriteLine("Klicka på valfri tangent för att återvända.");
                                                        Console.ReadKey();
                                                        continue;
                                                    }
                                                    break;

                                                case 4:

                                                    break;

                                            }
                                        }
                                        break;

                                    case 3:
                                        continue; // 

                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(
                                    """

                                    =========================================
                                    Fel inmatning, välj en siffra mellan 1-3.
                                    =========================================

                                    """);
                            }

                            break;
                        case 2:
                            UI.ShowBetaMenu(); //------------------------------------------------------------------- BETA MENY

                            valSiffra = Convert.ToInt16((Console.ReadLine()));
                            switch (valSiffra)
                            {

                            }

                            break;
                        case 3:
                            programIsOn = false;
                            continue; // 
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(
                        """

                        =========================================
                        Fel inmatning, välj en siffra mellan 1-3.
                        =========================================

                        """);
                }

             Console.WriteLine("""


                 =========================================
                 Klicka på ENTER för att stänga programemt...
                 =========================================
                 

                 """);
            }
        }
    }
}
