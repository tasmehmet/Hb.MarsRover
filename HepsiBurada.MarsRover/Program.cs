using HepsiBurada.MarsRover.Infrastructure.Model.Surface;
using HepsiBurada.MarsRover.Infrastructure.Operations.ParserOperation;
using System;
using System.Text;

namespace HepsiBurada.MarsRover
{
    class Program
    {

        public static void Main(string[] args)
        {
            string commandStr = BuildCommands();
            Parse parse = new Parse();
            parse.Parse(commandStr);

            Console.WriteLine(_plate.ToString());

            Console.ReadLine();
        }

        private static string BuildCommands()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");
            return commandStringBuilder.ToString();
        }
    }
}
