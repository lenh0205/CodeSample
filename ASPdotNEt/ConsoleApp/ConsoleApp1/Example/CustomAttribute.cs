namespace ConsoleApp1.Example
{
    public class CustomAttribute : Attribute
    {
        public string Name { get; set; }

        public void Write()
        {
            Console.WriteLine("Hello CustomAttribute.");
        }
    }
}
