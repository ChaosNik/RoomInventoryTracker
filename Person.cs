using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISIO
{
    public class Person
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string UIN { get; set; }
        public string Employment { get; set; }
        public string Contact { get; set; }
        public int CallingID { get; set; }
        public int Status { get; set; }

        public Calling calling { get; set; }

        public override string ToString()
        {
            return this.LastName + " " + this.FirstName;
        }
    }
}
