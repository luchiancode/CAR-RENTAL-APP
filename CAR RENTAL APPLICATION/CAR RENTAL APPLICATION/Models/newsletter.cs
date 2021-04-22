using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL_APPLICATION.Models
{
    public class newsletter
    {

        public int newsletterId { get; set; }

        public string title { get; set; }

        public ICollection<mailingList> MailingLists { get; set; }

        public contact contact { get; set; }

        public ICollection<contact> contacts { get; set; }

    }

    
}

