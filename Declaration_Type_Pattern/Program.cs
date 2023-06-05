namespace Declaration_Type_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ConstantPattern();
            TypeDecalartionPatternSimplestForm();            
            TypeDecalartionPatternUsingSwitch();

            Console.WriteLine("Hello, World!");            
        }

        static void ConstantPattern()
        {
            var message = "hello"; //This is actually constant pattern

            if (message is "hello")
            {
                Console.WriteLine("hello");
            }
        }

        static void TypeDecalartionPatternSimplestForm()
        {
            Employee tom = new Manager();
            UseEmployee(tom);

            void UseEmployee(Employee emp)
            {
                if (emp is Manager manager && manager.IsOnVacation == false) //This is actually type and declaration pattern
                {
                    manager.Work();
                }
                else
                {
                    Console.WriteLine("Преобразование не допустимо");
                }
            }
        }
        
        static void TypeDecalartionPatternUsingSwitch()
        {
            Employee bob = new Manager() { IsOnVacation = true };
            Employee tom = new Manager() { IsOnVacation = false };
            UseEmployee(tom);   // Manager works
            UseEmployee(bob);   // Employee does not work

            void UseEmployee(Employee? emp)
            {
                switch (emp)
                {
                    case Manager manager when !manager.IsOnVacation: //This is actually type and declaration pattern
                        manager.Work();
                        break;
                    case null:
                        Console.WriteLine("Employee is null");
                        break;
                    default:
                        Console.WriteLine("Employee does not work");
                        break;
                }
            }
        }
    }


    class Employee
    {
        public virtual void Work() => Console.WriteLine("Employee works");
    }

    class Manager : Employee
    {
        public override void Work() => Console.WriteLine("Manager works");
        public bool IsOnVacation { get; set; }
    }
}