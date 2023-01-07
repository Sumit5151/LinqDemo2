
using LinqDemo2.dal;
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
            var employee = db.Employees.SingleOrDefault();



            //Last
            //var employee =   db.Employees.Last();   
            //var employee = db.Employees.LastOrDefault();


            if (employee != null)
            {
                Console.WriteLine($"Id = {employee.Id}  Name = {employee.Name}");
            }

            return View();
        }


        public void Index2()
        {
            //List<int> numbers = new List<int>() { 1, 100, 2, 54, 3, 4, 5, 6, 7, 8};
            //List<string> states = new List<string>() { "Maharashtra","Goa","Karnatka"};
            //List<char> charList = new List<char>() { 'A','a','C','D'};

            //var lastNumber = numbers.Last();
            //Console.WriteLine($"Lastnumber= {lastNumber}");

            //var lastState = states.Last();
            //Console.WriteLine($"Last state in the list = {lastState}");
            ////This line will through the exception
            ////var number10 = numbers.Last(x => x == 10);


            //var number10 = numbers.LastOrDefault(x => x == 10);
            //var andhraState = states.LastOrDefault(x => x == "Andhara");
            //var emp = db.Employees.OrderBy(x=>x.Id).LastOrDefault(x=>x.Name == "Onkar");


            //Select operator, Projection operator

            //This will select all the columns from the DB
            //var employees =  db.Employees.ToList();

            //Q Select only the name column 
            //var employeeNames = db.Employees.Select(x => x.Name);


            //foreach (var empName in employeeNames)
            //{
            //    Console.WriteLine(empName);
            //}



            ////Q Select only the name and Email column 
            //var employeeNamesAndEmails = db.Employees.Select(x => new EmployeeNameAndEmails
            //                                                        {
            //                                                            Name1 = x.Name,
            //                                                            Email1 = x.Email
            //                                                        }

            //                                                    ).ToList();


            //foreach (var empNameAndEmail in employeeNamesAndEmails)
            //{
            //    Console.WriteLine($" {empNameAndEmail.Name1}   {empNameAndEmail.Email1} ");
            //}



            //Q Select only the name and Email and Salary column 

            //var employeeNameEmailSalary = db.Employees.Select(x => new
            //                                                    {
            //                                                       emploeeName = x.Name,
            //                                                       email = x.Email,
            //                                                       salary= x.Salary

            //                                                    }).ToList();


            //foreach (var emp in employeeNameEmailSalary)
            //{
            //    Console.WriteLine($" {emp.emploeeName}   {emp.email}  {emp.salary} ");
            //}



            //Aggreage function 

            //List<int> numbers = new List<int>() { 7, 10, 2, 54, 3, 4, 54, 6, 74, 8};


            //int max = numbers[0];

            //for (int i = 1; i < numbers.Count; i++)
            //{
            //    if(max < numbers[i])
            //    {
            //        max = numbers[i];
            //    }

            //}
            //Console.WriteLine($" Maximum number = {max}");


            //var maxNumber =  numbers.Max();
            //Console.WriteLine($" Maximum number = {maxNumber}");

            // var minNumber = numbers.Min();

            // var countOfNumber = numbers.Count();

            // var sumOfNumber = numbers.Sum();

            // var average  = numbers.Average();



            // var maxSalary = db.Employees.Select(x => x.Salary).Max();

            // var totalSalaryofItEmployees = db.Employees.Where(x=>x.DepartmentId == 2)
            //                                            .Select(x => x.Salary)
            //                                            .Max();

            // var employees = db.Employees.Where(x => x.City != "Pune" && x.Salary > 5000).ToList();


            //Aggreagate()


            //List<int> numbers = new List<int>() { 7, 10, 2, 54, 3, 4, 54, 6, 74, 8 };
            //var sumOfNubmers = numbers.Aggregate((a, b) => a + b);
            //var sum = numbers.Sum();

            //var mulOfNubmers = numbers.Aggregate((a, b) => a * b);



            //List<string> states = new List<string>() { "Maharashtra", "Goa", "Karnatka", "Jahrkhand", "Bihar", "Kashmir" };


            //var concatinatedStates = states.Aggregate((a, b) => a + ", " + b);

            //var employeeNames = db.Employees.Select(x => x.Name).ToList()
            //                                .Aggregate((a, b) => a + ", " + b);




            //orderby() orderByDesending

            //var employeesOrderBySalary = db.Employees.OrderBy(x => x.Salary).ToList();
            //var employeesOrderBySalary = db.Employees.OrderByDescending(x => x.Salary).ToList();

            //foreach (var emp in employeesOrderBySalary)
            //{
            //    Console.WriteLine($" {emp.Name}  {emp.Salary}  {emp.Gender}");
            //}


            //var employeesOrderByGender = db.Employees.OrderByDescending(x => x.Gender).ToList();

            //foreach (var emp in employeesOrderByGender)
            //{
            //    Console.WriteLine($" {emp.Name}  {emp.Salary}  {emp.Gender}");
            //}



            //ThenBy() ThenByDesending()


            //var employeesOrderBySalary = db.Employees.OrderBy(x => x.Gender).ThenByDescending(x=>x.Salary).ToList();
            var employeesOrderBySalary = db.Employees.OrderBy(x => x.Gender).ThenBy(x=>x.Name).ToList();

            foreach (var emp in employeesOrderBySalary)
            {
                Console.WriteLine($" {emp.Name}  {emp.Salary}  {emp.Gender}");
            }



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