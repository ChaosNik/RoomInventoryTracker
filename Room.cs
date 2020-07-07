using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISIO
{
    public class Room
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BuildingID { get; set; }
        public int Status { get; set; }

        public Building building { get; set; }

        public override string ToString()
        {
            return this.Name + "[" + this.Code + "]";
        }
    }
}
