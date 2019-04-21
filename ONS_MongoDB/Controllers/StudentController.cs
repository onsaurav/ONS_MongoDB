using MongoDB.Driver;
using MongoDB.Driver.Builders;
using ONS_MongoDB.Models;
using ONS_MongoDB.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONS_MongoDB.Controllers
{    
    public class StudentController : Controller
    {
        MongoDatabase MDB;
        MongoCollection _MongoCollection;

        // GET: Student
        public ActionResult Index()
        {
            List<Student> list = new List<Student>();
            var MongoClient = new MongoClient(Settings.Default.MongoDBConnectionString);
            var MongoServer = MongoClient.GetServer();
            MDB = MongoServer.GetDatabase(Settings.Default.DBName);
            _MongoCollection = MDB.GetCollection<Student>("Students");

            var students = _MongoCollection.FindAs(typeof(Student), Query.NE("Name", "null"));
            foreach (Student std in students)
            {
                list.Add(new Student { _id = std._id, Name = std.Name, RollNo = std.RollNo, Address = std.Address });
            }

            return View(list);
        }

        // GET: Student/Details/5
        public ActionResult Details(object id)
        {
            var MongoClient = new MongoClient(Settings.Default.MongoDBConnectionString);
            var MongoServer = MongoClient.GetServer();
            MDB = MongoServer.GetDatabase(Settings.Default.DBName);
            Student _Student = (Student)MDB.GetCollection<Student>("Students").FindOneAs(typeof(Student), Query.EQ("_id", (MongoDB.Bson.BsonValue)id.ToString()));
            return View(_Student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student _Student)
        {
            try
            {
                if (_Student._id == null)
                    _Student._id = Guid.NewGuid();
                var MongoClient = new MongoClient(Settings.Default.MongoDBConnectionString);
                var MongoServer = MongoClient.GetServer();
                MDB = MongoServer.GetDatabase(Settings.Default.DBName);
                _MongoCollection = MDB.GetCollection<Student>("Students");
                _MongoCollection.Insert(_Student);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            var MongoClient = new MongoClient(Settings.Default.MongoDBConnectionString);
            var MongoServer = MongoClient.GetServer();
            MDB = MongoServer.GetDatabase(Settings.Default.DBName);
            Student _Student = (Student)MDB.GetCollection<Student>("Students").FindOneAs(typeof(Student), Query.EQ("_id", id));
            return View(_Student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(object id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(object id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(object id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
