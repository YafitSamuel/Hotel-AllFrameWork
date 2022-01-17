using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_AllFrameWork.Models
{
    public class Ceo
    {
       public int id;
        public string   fullName;
        public int age;
        public string email;
        public int payment;

        public Ceo(int id, string fullName, int age, string email, int payment)
        {
            this.id = id;
            this.fullName = fullName;
            this.age = age;
            this.email = email;
            this.payment = payment;

        }
    }
}