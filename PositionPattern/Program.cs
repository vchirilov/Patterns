namespace PositionPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MessageDetails details1 = new MessageDetails { Language = "english", DateTime = "evening", Status = "user" };
            string message = PositionPatternSimpleForm(details1);
            Console.WriteLine(message);  // Good evening
        }

        static string PositionPatternSimpleForm(MessageDetails details) => details switch
        {
            ("english", "morning", _) => "Good morning",    //This is actual positional pattern. Position pattern is available for classes with defined deconstructor
            ("english", "evening", _) => "Good evening",
            ("german", "morning", _) => "Guten Morgen",
            ("german", "evening", _) => "Guten Abend",
            (_, _, "admin") => "Hello, Admin",
            _ => "Not clear"
        };
    }


    class MessageDetails
    {
        public string Language { get; set; } = "";
        public string DateTime { get; set; } = "";
        public string Status { get; set; } = "";

        public void Deconstruct(out string lang, out string datetime, out string status)
        {
            lang = Language;
            datetime = DateTime;
            status = Status;
        }
    }
}