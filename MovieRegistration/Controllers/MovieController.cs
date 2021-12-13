using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieRegistration.Models;
using MySqlConnector;

namespace MovieRegistration.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index(UserModel model)
        {
            if (ModelState.IsValid)
            {
                List<UserModel> movieList = new List<UserModel>();
                using (var connect = new MySqlConnection(Secret.Connection))
                {
                    string Query = @"INSERT INTO movieregistration VALUES (@Id, @Title, @Genre, @Year, @RunTime)";
                    connect.Open();

                    string findQuery = "select * from movieregistration";

                    movieList = connect.Query<UserModel>(findQuery).ToList();
                    connect.Close();
                }
                return RedirectToAction("List");
            }
            return View(model);
        }
        public IActionResult List()
        {
            List<UserModel> movies = new List<UserModel>();
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string findQuery = "select * from movies";
                movies = connect.Query<UserModel>(findQuery).ToList();
                connect.Close();
            }
            return View(movies);
        }
       
        
        [HttpPost]
        public IActionResult Edit(UserModel m)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("List");
            }
            return View(m);
        }
        
        
    }
}
