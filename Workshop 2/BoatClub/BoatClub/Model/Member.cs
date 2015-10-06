using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BoatClub.Model
{
    [Serializable]
    class Member
    {
        private string n_name;
        private string s_ssn;
        private int u_unique;
        Regex regValidation = new Regex("^[12]{1}[90]{1}[0-9]{6}-[0-9]{4}$");

        private List<Boat> _boats = new List<Boat>();
        public List<Boat> Boats { get { return _boats; } }

        public string Name
        {
            get { return n_name; }

            set
            {
                if (value.Length < 1 )
                {
                    throw new ArgumentException("Namn får inte vara tomt, ange ett Namn!");
                }
                if (value.Length >= 50)
                {
                    throw new ArgumentException("Namnet du angett är ovanligt stort, ange ett kortare namn!");
                }

                n_name = value;
            }
        }

        // Social Security Number (Person Nummer)
        public string Ssn
        {
            get { return s_ssn; }
            
            set
            {
                if (!regValidation.IsMatch(value))
                {
                    throw new ArgumentException("Ange ett giltigt personnummer");
                }
                s_ssn = value;
            }
        }

        public int UniqueInt
        {
            get { return u_unique; }
            set
            {
                
                u_unique = value;
            }
            
        }

        public Member(string name, string ssn, int uniqueInt)
        {
            Name = name;
            Ssn = ssn;
            UniqueInt = uniqueInt;
        }

        public void addBoat(Boat boat)
        {
            _boats.Add(boat);
        }

        public void deleteBoat(int id)
        {
            _boats.Remove(_boats.ElementAt(id));
        }
    }
}
