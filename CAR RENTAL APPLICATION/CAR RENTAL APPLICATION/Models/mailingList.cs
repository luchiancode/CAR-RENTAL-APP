using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL_APPLICATION.Models
{
    public class mailingList
    {
        public int mailingListId { get; set; }
        public string email { get; set; }
        public string name { get; set; }

        public string address { get; set; }

        public string address2 { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public int zip { get; set; }

        public bool policy { get; set; }


        public int newsletterId { get; set; }

        public newsletter newsletter { get; set; }


    }
}
