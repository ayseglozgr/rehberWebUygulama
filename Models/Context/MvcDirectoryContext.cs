using rehberWebUygulama.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace rehberWebUygulama.Models.Context
{
    public class MvcDirectoryContext : DbContext
    {
        public MvcDirectoryContext() : base("Server=.;Database=MvcDirectoryDB;Trusted_Connection=true")
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}