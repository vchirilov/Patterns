namespace Relational_Logical_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var result = RelationalPattern(50);

        }

        static decimal RelationalPattern(decimal sum)
        {
            return sum switch
            {
                <= 0 => 0,
                < 50 => sum * 0.05m, //This is relational pattern
                < 100 => sum * 0.1m,
                _ => sum * 0.2m
            };
        }

        static string LogicalPattern(int age)
        {
            return age switch
            {
                < 1 or > 110    => "The age is wrong", //This is logical pattern. Actually, logical pattern is relational, plus and/or logical operations
                >= 1 and < 18   => "Access is allowed",
                _ => "Access not allowed"
            };
        }
    }
}