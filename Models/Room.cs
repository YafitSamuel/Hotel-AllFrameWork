using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_AllFrameWork.Models
{
    public class Room
    {

        public int Id;
        public int roomNumber;
        public string roomType;
        public int price;
        public bool Isavailable;

        public Room(int Id, int roomNumber, string roomType, int price, bool Isavailable)
        {
            this.Id = Id;
            this.roomNumber = roomNumber;
            this.roomType = roomType;
            this.price = price;
            this.Isavailable = Isavailable;
        }
    }
}