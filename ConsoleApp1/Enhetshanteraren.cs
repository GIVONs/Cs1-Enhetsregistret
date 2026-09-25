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
        string moms = "0.25m";

        string enhet1 = "Projektor";
        string enhetsTyp1 = "Projektor";
        string id1 = "ID-100";
        string status1 = "Aktiv";
        string price1 = "250";
       

        string enhet2 = "Samsung Display";
        string enhetsTyp2 = "Bildskärmsutrustning";
        string id2 = "ID-200";
        string status2 = "Aktiv";
        string price2 = "100";

        string enhet3 = "Laptop";
        string enhetsTyp3 = "Dator";
        string id3 = "ID-300";
        string status3 = "Service";
        string price3 = "800";

        // om jag har strings för priser här,
        // konverteras dem till decimal senare?
 
        // -----------------------------------------------------
        //              ENHET4; Startvärden
        string enhet4;
        string enhetstTyp4;
        string id4;
        string status4;
        decimal price4; 

        // -----------------------------------------------------


        public void Start() 
        {

            // ---------------- KALKYLERINGAR -------------------
            decimal totalPrice;
            //decimal momsPåPris = totalPrice * (1 * moms);
            //double bruttoPris = Convert.ToDouble(totalPrice + momsPåPris);

            double bruttoPrice4;

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
                UI.ShowMenu1();

                int valSiffra = Convert.ToInt16(Console.ReadLine());
                if (valSiffra == 1 || valSiffra == 2 || valSiffra == 3)
                {

                    switch (valSiffra)
                    {
                        case 1:
                            UI.ShowMenu2();
                            valSiffra = Convert.ToInt16((Console.ReadLine()));
                            if (valSiffra == 1 || valSiffra == 2 || valSiffra == 3 || valSiffra == 4)
                            {

                                switch (valSiffra) // Om du skrivit duglig svar:
                                {
                                    case 1:
                                        UI.ShowAllProducts(row1, row2, row3, row4);

                                        break;
                                    case 2:

                                        UI.InputEntity(enhet4, enhetstTyp4, id4, price4);
                                        // "row4" får värde vid denna punkt då, så den inte skrivs ut om inget värde finns.
                                        row4 = UI.ShowRow(id4, enhet4, enhetstTyp4, status4, price4, moms);

                                        break;
                                    case 3:

                                        break;
                                    case 4:

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
                            UI.ShowBetaMenu();

                            valSiffra = Convert.ToInt16((Console.ReadLine()));
                            switch (valSiffra)
                            {

                            }

                            break;
                        case 3:
                            programIsOn = false;
                            break;
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

             Console.WriteLine("Klicka på ENTER för att stänga programemt...");
            }
        }
    }
}
