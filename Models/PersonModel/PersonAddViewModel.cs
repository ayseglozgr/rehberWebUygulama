using rehberWebUygulama.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rehberWebUygulama.Models.PersonModel
{
    public class PersonAddViewModel
    {
        public Person Persons { get; set; }
        public List<City> Cities { get; set; }

        
    }
}