namespace TuplePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string message1 = TuplePatternUsingSwitch("english", "evening");
            Console.WriteLine(message1);  // Good evening

            string message2 = TuplePatternUsingSwitchUsingUnderscore("english", "morning", "active");
            Console.WriteLine(message2);  // Good morning
        }

        static string TuplePatternUsingSwitch(string lang, string daytime) => (lang, daytime) switch
        {
            ("english", "morning") => "Good morning", //This is actually tuple pattern
            ("english", "evening") => "Good evening",
            ("german", "morning") => "Guten Morgen",
            ("german", "evening") => "Guten Abend",
            _ => "Здрасьть"
        };


        static string TuplePatternUsingSwitchUsingUnderscore(string lang, string daytime, string status) => (lang, daytime, status) switch
        {
            ("english", "morning", _) => "Good morning", //This is actually tuple pattern
            ("english", "evening", _) => "Good evening",
            ("german", "morning", _) => "Guten Morgen",
            ("german", "evening", _) => "Guten Abend",
            (_, _, "admin") => "Hello, Admin",
            _ => "Здрасьть"
        };
    }
}