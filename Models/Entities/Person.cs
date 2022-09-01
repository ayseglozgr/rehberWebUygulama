using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rehberWebUygulama.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [DisplayName("Ad")]
        public string name { get; set; }
        [DisplayName("Soyad")]
        public string surname { get; set; }
        [DisplayName("Ev Telefonu")]
        public string homePhone { get; set; }
        [DisplayName("Cep Telefonu")]
        public string mobilePhone { get; set; }
        [DisplayName("İş Telefonu")]
        public string officePhone { get; set; }
        [DisplayName("E-mail Adres")]
        public string emailaddress { get; set; }
        [DisplayName("Adres")]
        public string address { get; set; }
        [DisplayName("Şehir")]
        public int cityId { get; set; }

    
        public City city { get; set; }

    }
}