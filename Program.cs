using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SaleTimeout
{
    public static class Program
    {
        private static readonly object Lock = new object();

        public static void Main(string[] args)
        {
            try
            {
                JsonConvert.DefaultSettings = () => new JsonSerializerSettings { Converters = { new StringEnumConverter() } };
                var pos = new PointOfSale();
                pos.Run();
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex);
                Console.ResetColor();
                Console.ReadLine();
            }
        }

        public static string Prompt(string prompt)
        {
            while (true)
            {
                WriteLine(prompt, ConsoleColor.Yellow);
                var command = Console.ReadLine();
                if (!string.IsNullOrEmpty(command)) return command;
            }
        }

        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.Gray)
        {
            lock (Lock)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

        public static void WriteLine(string message, object value, ConsoleColor color = ConsoleColor.Gray)
        {
            lock(Lock)
            {
                Console.ForegroundColor = color;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($" {JsonConvert.SerializeObject(value)}");
                Console.ResetColor();
            }
        }
    }
}
