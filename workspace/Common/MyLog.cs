using System;

namespace Common
{
    public class MyLog : ILog
    {
        public void Debug(string message)
        {
            Console.WriteLine(message);
        }

        public void Debug(string message, Exception e)
        {
            Console.WriteLine(message);
        }

        public void Error(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string message, Exception e)
        {
            Console.WriteLine(message);
        }

        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Info(string message, Exception e)
        {
            Console.WriteLine(message);
        }

        public void Warn(string message)
        {
            Console.WriteLine(message);
        }

        public void Warn(string message, Exception e)
        {
            Console.WriteLine(message);
        }
    }
}
