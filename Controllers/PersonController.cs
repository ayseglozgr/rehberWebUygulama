using rehberWebUygulama.Models.Context;
using rehberWebUygulama.Models.Entities;
using rehberWebUygulama.Models.PersonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rehberWebUygulama.Controllers
{
    public class PersonController : Controller
    {
        MvcDirectoryContext db = new MvcDirectoryContext();

        public List<City> Cities { get; private set; }

        // GET: Person
        public ActionResult Index()
        {
            var model = new PersonIndexViewModel
            {

                Persons = db.Persons.ToList(),
                Cities = db.Cities.ToList()
            };

            return View(model);
        }
        public ActionResult Add()
        {
            var model = new PersonAddViewModel
            {
                Persons = new Person(),
                Cities = db.Cities.ToList()
            };
            List<SelectListItem> cities = (from q in db.Cities
                                           select new SelectListItem

                                           {
                                               Value = q.plateCode.ToString(),
                                               Text = q.nameOfCity
                                           }).ToList();
            ViewBag.Cities = cities;
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(PersonAddViewModel person)
        {
            try
            {
                db.Persons.Add(person.Persons);
                db.SaveChanges();
                TempData["successedMessage"] = "succefully!";
            }
            catch (Exception)
            {
                TempData["failedMessage"] = "failed, try again!";
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var person = db.Persons.Find(id);
            if (person == null)
            {
                TempData["failedMessage"] = "güncellenmek istenen kayıt bulunamadı";
                return RedirectToAction("Index");
            }
            List<SelectListItem> cities = (from q in db.Cities
                                           select new SelectListItem

                                           {
                                               Value = q.plateCode.ToString(),
                                               Text = q.nameOfCity
                                           }).ToList();
            var model = new PersonUpdateViewModel
            {
                Person = person,
                Cities = db.Cities.ToList(),
            };
            ViewBag.Cities = cities;

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Person person)
        {
            var xPerson = db.Persons.Find(person.Id);
            if (xPerson == null)
            {
                TempData["failedMessage"] = "güncellenmek istenen kayıt bulunamadı";
                return RedirectToAction("Index");
            }
            xPerson.name = person.name;
            xPerson.surname = person.surname;
            xPerson.homePhone = person.homePhone;
            xPerson.mobilePhone = person.mobilePhone;
            xPerson.officePhone = person.officePhone;
            xPerson.emailaddress = person.emailaddress;
            xPerson.address = person.address;
            xPerson.cityId = person.cityId;
            db.SaveChanges();
            TempData["successedMessage"] = "successful!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detail(int Id)
        {
            var person = db.Persons.Find(Id);
            if (person == null)
            {
                TempData["failedMessage"] = "Kişi bulunamadı";
                return RedirectToAction("Index");
            }
            var model = new personDetailViewModel
            {
                Person = person,
                Cities = db.Cities.ToList()
            };
            return View(model);
        }
        public ActionResult Delete(int Id)
        {
            var person = db.Persons.Find(Id);
            if (person ==null)
            {
                TempData["failedMessage"] = "Kişi bulunamadı";
                return RedirectToAction("Index");
            }
            db.Persons.Remove(person);
            db.SaveChanges();
            TempData["successedMessage"] = "succesful!";
            return RedirectToAction("Index");
        }
        
        
    }
}