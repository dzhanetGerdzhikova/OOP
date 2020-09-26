namespace SantaWorkshop.IO
{
    using System;

    using SantaWorkshop.IO.Contracts;

    public class Reader : IRepository
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}