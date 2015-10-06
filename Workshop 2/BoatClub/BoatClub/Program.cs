using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.Controller;

namespace BoatClub
{
    class Program : BoatClub.Controller.SecretaryController
    {
        static void Main(string[] args)
        {
            SecretaryController cont = new SecretaryController();
            cont.run();
        }
    }
}
