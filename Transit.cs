using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISIO
{
    class Transit
    {
        public int ID { get; set; }
        public DateTime DateAndTime { get; set; }
        public int RoomIDFrom { get; set; }
        public int RoomIDTo { get; set; }
        public int PersonIDFrom { get; set; }
        public int PersonIDTo { get; set; }
        public int PrimaryResourceID { get; set; }
        public int Status { get; set; }

        public Room room_from { get; set; }
        public Room room_to { get; set; }
        public Person person_from { get; set; }
        public Person person_to { get; set; }
        public PrimaryResource primary_resource { get; set; }
    }
}
