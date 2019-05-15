using System;
using UnitTesting.Twitter.Interfaces;

namespace UnitTesting.Twitter.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}
