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
                           orderby num
                           select num;

            IEnumerable<int> evenNumbers2 = numbers.Where(num => num % 2 == 0).OrderBy(n => n);

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

            // (1) Select all. You can also concat another list var list = (LINQ1).Concat(LINQ2)
            var allEntries = from sq in squareList select sq;

            // (2) select with conditional(s) - select even squares bigger than 10
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

            //var entries4b = squareList.GroupBy(g => g.x).OrderBy(o => o);

            Console.WriteLine("Group By---");
            foreach (var xG in entries4)
            {
                Console.WriteLine(xG.Key); //Only 10 should appear because there are > 2 entries in the List for 10
            }

            Console.WriteLine("Group By again---");

            //foreach (var group in entries4b)
            //{
            //    Console.WriteLine(group.Key);
            //}

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
            // This is a NEW list of anonymous type and only 2 attributes (it pulled the employee's name and department name) as depicted select new {}
            var innerJoin = (from e in employees
                        //where e.employeeName[0] == 'E'
                        join d in departments
                        on e.deptID equals d.deptID
                        select new { employeeName = e.employeeName, departmentName = d.deptName }
                        );

            

            // Inner join is a new transient object variable with just two properties, the employee name (existing) and department name (new)
            foreach (var emp in innerJoin)
            {
                Console.WriteLine(emp.GetType());
                Console.WriteLine("Employee name = {0} , of department = {1}", emp.employeeName, emp.departmentName);
            }

            // Sometimes OOP really makes this complex - this is the noob version
            string[] deptArray = { "Sales", "Marketing", "Etc" };

            // Just use LINQ to sort for now. None of this XML or SQL data transformation. Or even performing operations like multiply, divide, etc.

            /// Did you know there is a Table class, so the below could be something like Table<Person> persons = db.GetTable<Persons>();
            /// //Do I even have a database context? I do in the MVC app but for the desktop app, how is that done? db = what? Do I need a connection?

            List<string> names = new List<string> { "Ann", "Bob", "Cara", "Dave", "Ed" };
            List<string> names2 = new List<string> { "Alan", "Bill", "Cath", "Dot", "Elle" };

            IEnumerable<string> nameQuery = (from name in names
                                             where name[0] == 'B'
                                             select name).Concat(from n in names2
                                                                 where n[0] == 'B'
                                                                 select n);

            IEnumerable<string> nameQuery2 = names
                .Where(n => n[0] == 'C' || n[0] == 'D')
                .Concat(names2.Where(n => n[0] == 'C' || n[0] == 'D'))
                .OrderByDescending(x => x);

            Console.WriteLine("---");

            foreach (string name in nameQuery)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("---");

            foreach (string name in nameQuery2)
            {
                Console.WriteLine(name);
            }

            // Linq and method arguments using .Select as a method to return the number, must use var
            // Noob way would be to use a loop and do the thing, push to an array or replace existing array then print
            // E.g. square each number in numbers array in one line using lambda and the LINQ .Select
            var squaredNumbers = numbers.Select(x => x * x);
            Console.WriteLine(string.Join(", ", squaredNumbers));


            // Func lambda delegate? versus a good old fashioned method?
            Func<int, string> myIntToString = x => (x*2).ToString();
            Func<string, string> myStringSurround = x => "(" + x + ")";
            Func<int, string> combined = x => myStringSurround(myIntToString(x));

            Console.WriteLine(combined(55));

            // Another example of two separate functions
            float intToFloatTimes3 (int x) => x * 3.0f;
            bool isFloatBiggerThan15half(float x) => (x > 15.5f);

            // It is possible to write a third function to do the above in one go. Which is fine if the functions are simple as this example, but rarely is in reality
            bool possibleCombo (int x) => (x * 3.0f > 15.5);

            // But you also deny access to the two initial functions. It is possible to join those two initial functions.
            // Which I have been doing all the time anyway. The next two Console.WriteLine are using function composition already
            bool possibleCombo2(int x) => isFloatBiggerThan15half(intToFloatTimes3(x));

            // Also what is this kind of notation? This is madness. Lambdas are killing me.
            Console.WriteLine(possibleCombo2(4));
            Console.WriteLine(possibleCombo2(6));

            // The question is when to use a good old fashioned method, a Func (delegate?) as above, or this weird lambda thing that I just learned
            // Anyway on to the Compose bit which I don't understand too well, but let's have a go
            Func<int, float> fff = x => x * 3.0f;
            Func<float, bool> ggg = y => (y > 15.5f);

            Func<int, bool> hhh = ggg.Compose(fff); 
            //I had to make my own class to add the method .Compose
            //But I did learn how to make a method which utilises the . 

            Console.WriteLine("-===-");

            Console.WriteLine(hhh(2));
            Console.WriteLine(hhh(3));
            Console.WriteLine(hhh(7));

            ////// Enough func for now

            // LINQ can be used in examples like:
            // List of students, with properties: .year and an .examScore. Find the average grade for each year

            ////var queryResult = from s in students // s in array students
            ////                  group s by s.year into studentGroup // I.e. new studentYear
            ////                  select new { yearLevel = studentGroup.Key, averageGrade = studentGroup.Average(x => x.examScore.Average()) }; 
            ///// Something like this, the average formula might be wrong


            Console.ReadKey();
        }
    }
}
