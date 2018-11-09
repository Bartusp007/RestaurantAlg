using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Calendar.Model;

namespace Calendar.Service
{
    public interface IRequestAvaibility
    {
         
    }

    public class RequestAvaibility : IRequestAvaibility
    {
        public bool IsAvailable;
        public List<Table> TableList;

        public RequestAvaibility()
        {
            TableList = new List<Table>();
            TableList.Clear();
        }
    }
}