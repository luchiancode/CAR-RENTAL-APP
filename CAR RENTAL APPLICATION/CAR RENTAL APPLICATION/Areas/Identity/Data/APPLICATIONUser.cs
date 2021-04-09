using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CAR_RENTAL_APPLICATION.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the APPLICATIONUser class
    public class APPLICATIONUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string firstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string lastName { get; set; }



    }
}
