﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL_APPLICATION.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Colour { get; set; }
        public string Capacity { get; set; }
        public string NumberOfDoors { get; set; }
        public string FabricationYear { get; set; }
        [Display(Name = "Choose a photo for the car")]
        [Required]
        public string CarImagePath { get; set; }
    }
}
