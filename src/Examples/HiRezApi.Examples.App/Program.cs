namespace HiRezApi.Examples.App
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Starting examples...");

            Paladins.Execute();
            RealmRoyale.Execute();

            Console.WriteLine("Finished examples");
            Console.ReadKey();
        }
    }
}