using System;

namespace Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IRC - Intrisic risk calculator");
            try
            {
                Console.WriteLine($"{Platform.Id} Version.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Impossible to continue, Click any key to exit.");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }
    }
}
