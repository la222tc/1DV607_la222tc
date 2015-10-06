using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BoatClub.Model.DLL
{
    class MemberDAL
    {
        private static string path = "../../Data/MemberList.bin";
        List<Member> listOfMembers = new List<Member>();

        public void addData(Member member)
        {
            listOfMembers.Add(member);
        }

        public List<Member> getMemberList()
        {
            return listOfMembers;
        }

        public void removeMember(Member member)
        {
            listOfMembers.Remove(member);
        }

        public void updateMemberName(Member member)
        {

            member.Name = Console.ReadLine();
            saveMember();
        }

        public void updateSnn(Member member)
        {

            member.Ssn = Console.ReadLine();
            saveMember();
        }

        public void saveMember()
        {
            //Using BinaryFormatter to serialize the data to the stream
            IFormatter formatter = new BinaryFormatter();

            //Open a stream for writing
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            try
            {
                formatter.Serialize(stream, listOfMembers);
              
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason" + e.Message);
            }
            finally
            {
                stream.Close();
                listOfMembers.Clear();
            }
            
        }

        public void getMembers()
        {

            listOfMembers.Clear();
            IFormatter formatter = new BinaryFormatter();
            // Opens the file containing the data to deserialize.
            Stream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            try
            {
                listOfMembers = (List<Member>)formatter.Deserialize(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                stream.Close();
            }
        }
    }
}
