using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL_APPLICATION.Models
{
    public class contact
    {
        public int contactId { get; set; }

        public string email { get; set; }

        public string text { get; set; }

        public int mailingListId { get; set; }

        public mailingList mailingList { get; set; }


    }
}
