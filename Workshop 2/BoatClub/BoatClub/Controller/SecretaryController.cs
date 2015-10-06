using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.View;
using BoatClub.Model;
using BoatClub.Model.DLL;

namespace BoatClub.Controller
{
    class SecretaryController
    {
        MainMenu main_menu = new MainMenu();
        MemberDAL member_dal = new MemberDAL();
        private List<Member> listOfMembers = new List<Member>();
      
        public void run()
        {
            Console.Clear();
            main_menu.show();
            Random r = new Random();


            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                    //Pressed 1: Create new Member
                case ConsoleKey.D1:

                    main_menu.getName();
                    string name = Console.ReadLine();
                    main_menu.getSnn();
                    string snn = Console.ReadLine();

                    int randomNumber = 0;
                   do
                   {
                       randomNumber = r.Next(int.MaxValue);
                   } while (isSameUnique(randomNumber));

                   Member member = new Member(name, snn, randomNumber);
                

                   member_dal.getMembers();
                   member_dal.addData(member);
                   member_dal.saveMember();
                   run();
                   
                    break;

                    //Pressed 2: Show compact list of all Members
                case ConsoleKey.D2:
                    Console.Clear();
                    member_dal.getMembers();
                    membersFromFile();
                    int i = 0;
                    foreach (var m in member_dal.getMemberList())
                    {
                        main_menu.showMembers(i, m.Name, m.Ssn, m.Boats.Count);
                        i++;
                    }
                    main_menu.SelectUser();
                    int selectedUser = 0;
                    try
                    {
                        selectedUser = int.Parse(Console.ReadLine());
                        showSelectedUser(selectedUser);

                    }
                    catch (Exception)
                    {
                        run();
                        
                    }
                    Console.ReadLine();
                    break;

                    // KeyPress 3: Show detailed list of members
                case ConsoleKey.D3:
                    Console.Clear();
                    member_dal.getMembers();
                    membersFromFile();
                    foreach (var m in member_dal.getMemberList())
                    {
                        main_menu.showSelectedUser(m.Name, m.Ssn, m.UniqueInt);
                        memberBoats(m);
                    }
                    main_menu.backToMember();
                    Console.ReadLine();
                    run();
                    break;

                    //Exits the program
                default:
                    Environment.Exit(0);
                    break;
            }
        }


        //Shows the selected user with boats
        public void showSelectedUser(int selectedUser)
        {
            var member = listOfMembers.First();
            member = listOfMembers.ElementAt(selectedUser);

            main_menu.showSelectedUser(member.Name, member.Ssn, member.UniqueInt);
            memberBoats(member);
            main_menu.backToMember();
            selectedMemberMenu(member);
        }


        //Shows the menu of what to change on the member
        public void updateMember(Member member)
        {
            Console.Clear();
            main_menu.showUpdateMemberMenu();
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    main_menu.showChangeMemberName();
                    member_dal.updateMemberName(member);
                    listOfMembers.Clear();
                    run();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    main_menu.showChangeSnn();
                    member_dal.updateSnn(member);
                    listOfMembers.Clear();
                    run();
                    break;
                //Back to Main Menu
                default:
                    run();
                    break;
            }
            
        }

        //Shows the list of boats from the enum that are available 
        public void listOfBoatTypes()
        {
            int p = 1;

            var boatTypes = Enum.GetValues(typeof(Boat.BoatType));
            foreach (var type in boatTypes)
            {
                if (p <= boatTypes.Length)
                {
                    main_menu.boatTypes(p, type);
                    p++;
                }
            }
            

        }

        //Adds a boat to the specific member by first choosing the boat type, 
        //then the lenght of the boat
        public void addBoatToMember(Member member)
        {
            Console.Clear();
            main_menu.boatTypeHeader();
            listOfBoatTypes();


            Boat.BoatType boatType = Boat.BoatType.Other;

            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    boatType = Boat.BoatType.Salilboat;
                    break;
                case ConsoleKey.D2:
                    boatType = Boat.BoatType.Motorsailer;
                    break;
                case ConsoleKey.D3:
                    boatType = Boat.BoatType.Kayak_Canoe;
                    break;
                case ConsoleKey.D4:
                    boatType = Boat.BoatType.Other;
                    break;
                //Back to Main Menu
                default:
                    run();
                    break;
            }

            main_menu.showBoatLengthMenu(boatType);
            try
            {
                int boatLength = int.Parse(Console.ReadLine());

                member.addBoat(new Boat(boatType, boatLength));
                member_dal.saveMember();
                listOfMembers.Clear();
                run();
            }
            catch (Exception)
            {
                run();
            }
           

        }

        //Shows the boats that the specific member owns
        public void memberBoats(Member member)
        {
            int id = 0;
            foreach (var boat in member.Boats)
            {
                main_menu.showMemberBoats(id, boat.BoatTypeProp, boat.BoatLenght);
                id++;
            }
        }

        public void removeBoat(Member member)
        {
            Console.Clear();
            main_menu.deleteBoatHeader();
            memberBoats(member);
            main_menu.backToMember();

            try
            {
                int id = int.Parse(Console.ReadLine());
                member.deleteBoat(id);
                member_dal.saveMember();
                listOfMembers.Clear();
                run();
            }
            catch (Exception)
            {
                run();
            }
          
        }

        //Shows a menu for the selected member
        public void selectedMemberMenu(Member member)
        {
            main_menu.displaySelectedMemberMenu();

            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            {
                    // Delete member
                case ConsoleKey.D1:
                    member_dal.removeMember(member);
                    listOfMembers.Remove(member);
                    member_dal.saveMember();
                    listOfMembers.Clear();
                    run();
                    break;

                    //Update member
                case ConsoleKey.D2:
                    updateMember(member);
                    break;
                    //Add boat to member
                case ConsoleKey.D3:
                    addBoatToMember(member);
                    break;
                    //Remove boat
                case ConsoleKey.D4:
                    removeBoat(member);
                    break;
                case ConsoleKey.D5:
                    updateBoat(member);
                    break;

                    //Back to Main Menu
                default:
                    run();
                    break;
            }
        }

        //Change's the boat type
        public void updateBoatType(Boat boat)
        {
            Console.Clear();
            listOfBoatTypes();
            Boat.BoatType boatType = Boat.BoatType.Other;

            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    boatType = Boat.BoatType.Salilboat;
                    break;
                case ConsoleKey.D2:
                    boatType = Boat.BoatType.Motorsailer;
                    break;
                case ConsoleKey.D3:
                    boatType = Boat.BoatType.Kayak_Canoe;
                    break;
                case ConsoleKey.D4:
                    boatType = Boat.BoatType.Other;
                    break;
                default:
                    run();
                    break;
            }
            
            boat.BoatTypeProp = (Boat.BoatType)boatType;
            member_dal.saveMember();
            listOfMembers.Clear();
            run();

        }

        //Gets the member boats and let the user choose what boat to update
        public void updateBoat(Member member)
        {
            Console.Clear();
            memberBoats(member);
            try
            {
                int id = int.Parse(Console.ReadLine());
                updateBoatMenu(member.Boats.ElementAt(id));
            }
            catch (Exception)
            {
                run();
            }
       

            
           
        }

        public void updateBoatLength(Boat boat)
        {
            main_menu.changeBoatLength();
            try
            {
                boat.BoatLenght = float.Parse(Console.ReadLine());
                member_dal.saveMember();
                listOfMembers.Clear();
                run();
            }
            catch (Exception)
            {
                run();
            }
          
            
        }

        //Shows a menu of what to update on the selected boat
        public void updateBoatMenu(Boat boat)
        {
            main_menu.showChangeBoatMenu();

            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    updateBoatType(boat);
                    break;

                case ConsoleKey.D2:
                    updateBoatLength(boat);
                    break;
                default:
                    run();
                    break;

            }
        }


        //Checks if the unique id is the same as anyone elses
        public bool isSameUnique(int uniqueID)
        {
            foreach (var m in member_dal.getMemberList())
            {
                if (uniqueID == m.UniqueInt)
                {
                    return true;
                }
            }
            return false;
        }

        public void membersFromFile()
        {
            var fileMembers = member_dal.getMemberList();
            foreach (var m in fileMembers)
            {
                listOfMembers.Add(m);
            }
        }
    }
}
