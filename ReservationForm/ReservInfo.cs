using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationForm
{
    class ReservInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip_code { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TypeOfRoom { get; set; }
        public string TypeOfFood { get; set; }
        public string Payment { get; set; }
        public DateTime ArrivialDate { get; set; }
        public DateTime EndOfStay { get; set; }
        public int Adults { get; set; }
        public int KidsUnderOf_6Years { get; set; }
        public int KidsUnderOf_3Years { get; set; }
    }
}
