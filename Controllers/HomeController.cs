using LinqDemo2.DAL;
using LinqDemo2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LinqDemo2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BrightDb3Context db;

        public HomeController(ILogger<HomeController> logger, BrightDb3Context _db)
        {
            _logger = logger;
            db = _db;
        }



        
 //  1) First() Vs FirstOrDefalut()
   
 //   if you dont found records in the database first will not handle null and it throws exception

 //   but FirtorDefalut will handle null and will not throw exception
	
	
 //  2) Single() Vs SingleOrDefault()
 //  if you dont found records in the database Single will not handle null and it throws exception

 //   but SingleOrDefault will handle null and will not throw exception
	
	
   
 //  3) First() Vs Single()
 //   if you found multiple matching records then first will return first matching records
	//if you found multiple matching records then Single will throw exception
	
   
   
   
 //  4) FirstOrDefalut() vs SingleOrDefalut()
 //  if you found multiple matching records then FirstOrDefalut will return first matching records
	//if you found multiple matching records then SingleOrDefalut will throw exception

        public IActionResult Index()
        {

            // Update the employee salary to 10000  and name =tom where id = 4012

            //First()

            //var employee=   db.Employees.First();  //THis will fetch the first record from the database

            //var employee =   db.Employees.First(x=>x.Id == 4012);  //THis will fetch the first record from the database 
            // with matching condition

            //This will throw error  this will not handle null
            //var employee =   db.Employees.First(x=>x.Email == "tom@gmal.com"); 

            //This handles null
            //var employee = db.Employees.FirstOrDefault(x => x.Email == "tom@gmal.com");  



            //Single
            //if it founds more than one matching records then throw errors
            //var employee = db.Employees.Single(x => x.Salary == 23000);
            //var employee = db.Employees.Single(x => x.Id == 5003);


            //singleOrDefault it handles null
            var employee = db.Employees.SingleOrDefault(x => x.Id == 1);


            //Last
            //var employee =   db.Employees.Last();   
            //var employee = db.Employees.LastOrDefault();


            if (employee != null)
            {
                Console.WriteLine($"Id = {employee.Id}  Name = {employee.Name}");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}