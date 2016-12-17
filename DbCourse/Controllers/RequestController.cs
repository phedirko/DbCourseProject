//<<<<<<< HEAD
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Threading.Tasks;
////using Microsoft.AspNetCore.Mvc;
////using DbCourse.Data;
////using Microsoft.Data.Entity;
////using System.Data.SqlClient;

////namespace DbCourse.Controllers
////{
////    public class RequestController : Controller
////    {
////        private readonly ApplicationDbContext _context;

////        public RequestController(ApplicationDbContext context)
////        {
////            _context = context;
////        }


////        [HttpPost]
////        public IActionResult Index(string request)
////        {
////            using (SqlConnection connection = new SqlConnection("(localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False)")
////            {
////                string queryString = "SELECT * FROM Clients;";
////                SqlCommand command = new SqlCommand(queryString, connection);
////                connection.Open();
////                SqlDataReader reader = command.ExecuteReader();

////                try
////                {

////                }
////                catch
////                {
////                }
////                finally
////                {
////                    reader.Close();
////                }
////            }
////            return View();
////        }

////        public IActionResult Index()
////        {
////            return View();
////        }
////    }
////}
//=======
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using System.Data.SqlClient;

//namespace DbCourse.Controllers
//{
//    public class RequestController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }


//        [HttpPost]
//        public IActionResult Index(string q)
//        {
//            List<List<string>> result = new List<List<string>>();
//            using (
//                SqlConnection connection =
//                    new SqlConnection(
//                        "Server=(localdb)\\mssqllocaldb;Database=aspnet-DbCourse-ef46caa3-980c-4e5d-b9a5-b965f3cff613;Trusted_Connection=True;MultipleActiveResultSets=true")
//            )
//            {
//                string queryString = q;
//                SqlCommand command = new SqlCommand(queryString, connection);
//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();


//                if (reader != null)
//                {
//                    result.Add(new List<string>());
//                    for (int i = 0; i < reader.FieldCount; ++i)
//                        result[0].Add(reader.GetName(i));
//                    int j = 1;
//                    while (reader.Read())
//                    {
//                        result.Add(new List<string>());
//                        for (int i = 0; i < reader.FieldCount; ++i)
//                            result[j].Add(reader[i].ToString());
//                        ++j;
//                    }
//                }
//            }

//            return View(result);
//        }



//    }
//}
//>>>>>>> 22ff1c58092e0359cfaa9c4aae5871c8104e8331
