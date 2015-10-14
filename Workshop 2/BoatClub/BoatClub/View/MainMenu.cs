using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.Model;

namespace BoatClub.View
{
    class MainMenu
    {
        public void show()
        {
            Console.WriteLine("Välkommen till båtklubben!");
            Console.WriteLine("");
            Console.WriteLine("Tryck 1 för att lägga till ny medlem");
            Console.WriteLine("Tryck 2 för att visa kompakt lista av medlemmar");
            Console.WriteLine("Tryck 3 för att visa detaljerad lista av medlemmar");
        }

        public void getName()
        {
            Console.Clear();
            Console.WriteLine("Skapa en ny Medlem");
            Console.WriteLine();
            Console.WriteLine("Ange Namn:");
         
        }

        public void getSnn()
        {
            Console.WriteLine("Ange Person Nummer");
        }

        public void showMembers(int i, string name, string ssn, int numbBoats )
        {
            
            Console.WriteLine("{0}. Namn:{1}\t\tPersonNummer:{2}\tBåtar:{3}", i, name, ssn, numbBoats);
        }

        public void SelectUser()
        {
            Console.WriteLine();
            Console.WriteLine("Ange vilket nummer för att Ändra/Kolla på Medlem");
        }

        public void showSelectedUser(string name, string ssn, int uniqueID)
        {
            Console.WriteLine("--------Medlem--------");
            Console.WriteLine();
            Console.WriteLine("Namn: {0}", name);
            Console.WriteLine("Person Nummer: {0}", ssn);
            Console.WriteLine("Member ID: {0}", uniqueID);
            Console.WriteLine();
        }

        public void displaySelectedMemberMenu()
        {
            Console.WriteLine("--------Meny--------");
            Console.WriteLine("1. Ta bort medlem");
            Console.WriteLine("2. Ändra medlem");
            Console.WriteLine("3. Lägg till båt");
            Console.WriteLine("4. Ta bort båt");
            Console.WriteLine("5. Ändra båt");
        }

        public void showUpdateMemberMenu()
        {
            Console.WriteLine("1. Ändra Namn");
            Console.WriteLine("2. Ändra Person Nummer");
        }

        public void showChangeMemberName()
        {
            Console.WriteLine("Ange nytt Namn:");
        }
        public void showChangeSnn()
        {
            Console.WriteLine("Ange nytt Person Nummer:");
        }

        public void boatTypeHeader()
        {
            Console.WriteLine("Välj en båt typ");
            Console.WriteLine();
        }
        public void boatTypes(int p, Object value)
        {
            Console.WriteLine("{0}: {1}", p, value);
        }

        public void showBoatLengthMenu(Boat.BoatType boatType)
        {
            Console.WriteLine();
            Console.WriteLine("Vald Båttyp: {0}", boatType);
            Console.WriteLine();
            Console.WriteLine("Ange en båt längd");
        }

        public void showMemberBoats(int id, Boat.BoatType boatType, float boatLength)
        {
            Console.WriteLine("{0}: {1}\t{2}", id, boatType, boatLength);
        }

        public void deleteBoatHeader()
        {
            Console.WriteLine("Välj vilken båt som skall raderas");
        }

        public void backToMember()
        {
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri knapp för att komma tillbaka till Main menu");
        }

        public void showChangeBoatMenu()
        {
            Console.WriteLine("1. Ändra Båt typ");
            Console.WriteLine("2. Ändra Båt längd");
        }

        public void changeBoatLength()
        {
            Console.WriteLine("Ange en ny båt längd");
        }

    }
}