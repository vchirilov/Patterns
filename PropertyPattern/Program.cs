namespace PropertyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PropertyPatternSimplestForm();

            var person = new Person { Language = "english", Status = "user", Name = "Tom" };
            
            var text = PropertyPatternUsingSwitch(person);
            Console.WriteLine(text);

            var anotherText = PropertyPatternUsingSwitchUsingVariables(person);
            Console.WriteLine(anotherText);

            PropertyPatternUsingComplexProperties();

            Console.WriteLine("Hello, World!");
        }

        static void PropertyPatternSimplestForm() 
        {
            Person tom = new Person { Language = "english", Status = "user", Name = "Tom" };
            Person pierre = new Person { Language = "french", Status = "user", Name = "Pierre" };
            Person admin = new Person { Language = "english", Status = "admin", Name = "Admin" };

            SayHello(admin);    // Hello, admin
            SayHello(tom);      // Hello
            SayHello(pierre);   // Salut

            void SayHello(Person person)
            {
                if (person is Person { Language: "english", Status: "admin" }) //This is actualy property pattern
                {
                    Console.WriteLine("Hello, admin");
                }
                else if (person is Person { Language: "french" }) //This is actualy property pattern
                {
                    Console.WriteLine("Salut");
                }
                else
                {
                    Console.WriteLine("Hello");
                }
            }
        }

        static string PropertyPatternUsingSwitch(Person? p) => p switch
        {
            { Language: "english" } => "Hello!",
            { Language: "german", Status: "admin" } => "Hallo, admin!",
            { Language: "french" } => "Salut!",
            { } => "undefined",
            null => "null"       // если Person p = null
        };


        static string PropertyPatternUsingSwitchUsingVariables(Person? p) => p switch
        {
            { Language: "german", Status: "admin" } => "Hallo, admin!",
            { Language: "french", Name: var name } => $"Salut, {name}!", //Pay attention how variable is used here
            { Language: var lang } => $"Unknown language: {lang}",
            null => "null"       // если Person p = null
        };

        static void PropertyPatternUsingComplexProperties()
        {
            var microsoft = new Company("Microsoft");
            var google = new Company("Google");
            var tom = new Employee("Tom", microsoft);
            var bob = new Employee("Bob", google);

            PrintCompany(tom);    // 
            PrintCompany(bob);    // 

            void PrintCompany(Employee employee)
            {
                if (employee is Employee { Company: { Title: "Microsoft" } }) //Property pattern for a complex property, since C #10
                {
                    Console.WriteLine($"{employee.Name} works in Microsoft");
                }
                else
                {
                    Console.WriteLine($"{employee.Name} works someware");
                }
            }
        }
    }

    class Person
    {
        public string Name { get; set; } = ""; 
        public string Status { get; set; } = "";
        public string Language { get; set; } = "";
    }

    class Employee
    {
        public string Name { get; }
        public Company Company { get; set; }
        public Employee(string name, Company company)
        {
            Name = name;
            Company = company;
        }

    }
    class Company
    {
        public string Title { get; }
        public Company(string title) => Title = title;
    }
}