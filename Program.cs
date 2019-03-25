using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // The data
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // The "normal" way
            List<int> evenNumbersList = new List<int>();
            foreach (int n in numbers)
            {
                if (n % 2 == 0)
                {
                    evenNumbersList.Add(n);
                }
            }

            // The LINQ way
            var evenNumbers = from num in numbers
                           where (num % 2) == 0
                           select num;

            int count = evenNumbers.Count();

            // Combined way "force immediate execution"

            List<int> numList = (from n in numbers
                                 where (n % 2) == 0
                                 select n
                                 ).ToList();

            // Implicit force immediate execution

            var numListAgain = (from n in numbers
                                where (n % 2) == 0
                                select n).ToArray();





            Console.WriteLine("Hello World!");

            Console.WriteLine(numbers.GetType());
            Console.WriteLine(evenNumbers.GetType());

            foreach (int num in evenNumbers)
            {
                
                Console.WriteLine("{0,1}", num);
            }


            Console.WriteLine("Hello World!");

            // IEnumerable makes it possible for the variable to be iterated with foreach and it makes an object's properties open for search
            // So the second line WHERE can do something like "where customer.City == "London"" 
            // Use var if you cannot be bothered to type out IEnumerable

            List<Square> squareList = new List<Square>();
            squareList.Add(new Square(10));
            squareList.Add(new Square(4));
            squareList.Add(new Square(7));
            squareList.Add(new Square(5));
            squareList.Add(new Square(2));
            squareList.Add(new Square(10));
            squareList.Add(new Square(3));
            squareList.Add(new Square(4));
            squareList.Add(new Square(10));

            // (1) Select all
            var allEntries = from sq in squareList select sq;

            // (2) select with conditional(s)
            IEnumerable<Square> squareQuery =
                from sq in squareList
                where sq.Area() % 2 == 0 && sq.x > 10
                select sq;

            foreach (Square sq in squareQuery)
            {
                Console.WriteLine(sq.x); // This will the even square areas' x length even though they were selected by their x^2
            }

            // (3) select with ordering
            var allEntries2 = from sq in squareList
                              where sq.Area() % 2 == 1
                              orderby sq.x ascending
                              select sq;

            Console.WriteLine("---");
            foreach (Square sq in allEntries2)
            {
                Console.WriteLine(sq.x);
            }

            // (4) grouping (must use var). better example is where x is something like a city to group the entries by city
            Console.WriteLine("---");
            var entries3 = from sq in squareList
                              group sq by sq.x;

            // Becomes nested list where you iterate over the group name first and then its members, so you have two lists (quadratic)
            
            foreach (var squareGroup in entries3)
            {
                Console.WriteLine("Key: " + squareGroup.Key);
                foreach (Square s in squareGroup)
                {
                    Console.WriteLine(s.x);
                }
            }

            // (5) Into eh? GROUP sq BY sq.x INTO sqGroup, transform the groups into a  single list for further LINQ
            // I am going to regret using crap variable names later. I am selecting the group rather than the entries, which relates to group, ahhh
            var entries4 = from sq in squareList
                           group sq by sq.x into xGroup
                           where xGroup.Count() > 2
                           orderby xGroup.Key
                           select xGroup;

            Console.WriteLine("---");
            foreach (var xG in entries4)
            {
                Console.WriteLine(xG.Key); //Only 10 should appear because there are > 2 entries in the List for 10
            }

            Console.WriteLine("---");

            // Circles and cylinders
            double radius = 10;
            double height = 5;

            Circle myCircle = new Circle(radius);
            Cylinder myCylinder = new Cylinder(radius, height);

            Console.WriteLine("Area of the circle = {0:F2}", myCircle.Area());
            Console.WriteLine("Area of the cylinder = {0:F2}", myCylinder.Area());
            Console.WriteLine("Volume of the cylinder = {0:F2}", myCylinder.Volume());

            // Join example. Not sure if it is a good example. Every employee is assigned a department, which is represented as an integer.
            // Using this integer, return the name of the department from the fact that there are two classes, Department where the dept's name resides and Employee
            List<Department> departments = new List<Department>();
            departments.Add(new Department(0, "Sales"));
            departments.Add(new Department(1, "Marketing"));
            departments.Add(new Department(2, "Development"));
            departments.Add(new Department(3, "Advertising"));

            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee(0, "Adam (s)", 0)); //
            employees.Add(new Employee(1, "Betty (d)", 2));
            employees.Add(new Employee(2, "Carl (d)", 2));
            employees.Add(new Employee(3, "David (a)", 3));
            employees.Add(new Employee(4, "Ellie (m)", 1));

            // Looks like departmentName is a new property of the Employee class. 
            // This is a new list of anonymous type and only 2 attributes (it pulled the employee's name and department name) as depicted select new {}
            var list = (from e in employees
                        //where e.employeeName[0] == 'E'
                        join d in departments
                        on e.deptID equals d.deptID
                        select new { employeeName = e.employeeName, departmentName = d.deptName }
                        );

            
            foreach (var emp in list)
            {
                Console.WriteLine(emp.GetType());
                Console.WriteLine("Employee name = {0} , of department = {1}", emp.employeeName, emp.departmentName);
            }

            // Sometimes OOP really makes this complex - this is the noob version
            string[] deptArray = { "Sales", "Marketing", "Etc" };

            Console.ReadKey();
        }
    }
}
