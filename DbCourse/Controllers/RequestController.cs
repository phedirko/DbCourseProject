//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using DbCourse.Data;
//using Microsoft.Data.Entity;
//using System.Data.SqlClient;

//namespace DbCourse.Controllers
//{
//    public class RequestController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public RequestController(ApplicationDbContext context)
//        {
//            _context = context;
//        }


//        [HttpPost]
//        public IActionResult Index(string request)
//        {
//            using (SqlConnection connection = new SqlConnection("(localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False)")
//            {
//                string queryString = "SELECT * FROM Clients;";
//                SqlCommand command = new SqlCommand(queryString, connection);
//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();

//                try
//                {

//                }
//                catch
//                {
//                }
//                finally
//                {
//                    reader.Close();
//                }
//            }
//            return View();
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}