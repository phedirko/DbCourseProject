using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DbCourse.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string q)
        {
            List<List<string>> result = new List<List<string>>();
            using (
                SqlConnection connection =
                    new SqlConnection(
                        "Server=(localdb)\\mssqllocaldb;Database=aspnet-DbCourse-ef46caa3-980c-4e5d-b9a5-b965f3cff613;Trusted_Connection=True;MultipleActiveResultSets=true")
            )
            {
                string queryString = q;
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                if (reader != null)
                {
                    result.Add(new List<string>());
                    for (int i = 0; i < reader.FieldCount; ++i)
                        result[0].Add(reader.GetName(i));
                    int j = 1;
                    while (reader.Read())
                    {
                        result.Add(new List<string>());
                        for (int i = 0; i < reader.FieldCount; ++i)
                            result[j].Add(reader[i].ToString());
                        ++j;
                    }
                }
            }

            return View(result);
        }



    }
}