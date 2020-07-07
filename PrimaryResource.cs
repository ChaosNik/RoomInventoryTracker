using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISIO
{
    public class PrimaryResource
    {
        public int ID { get; set; }
        public string InventoryNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public double Value { get; set; }
        public double Ammortization { get; set; }
        public string Location { get; set; }
        public int CategoryID { get; set; }
        public int RoomID { get; set; }
        public int PersonID { get; set; }
        public int ConditionID { get; set; }

        public Category category { get; set;}
        public Condition condition { get; set; }
        public Room room { get; set; }
        public Person person { get; set; }

        public override string ToString()
        {
            return this.Name + "[" + this.InventoryNumber + "]";
        }
    }
}
