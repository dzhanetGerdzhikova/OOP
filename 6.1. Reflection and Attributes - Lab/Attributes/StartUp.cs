namespace AuthorAttribute
{
    [AuthorAttribute("Ventsi")]
    public class StartUp
    {
        [AuthorAttribute("Gosho")]
        public static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}