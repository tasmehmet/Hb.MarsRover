using HepsiBurada.MarsRover.Infrastructure.Model.Surface;
using HepsiBurada.MarsRover.Infrastructure.Operations;
using HepsiBurada.MarsRover.Infrastructure.Operations.ParserOperation;
using MediatR.SimpleInjector;
using SimpleInjector;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace HepsiBurada.MarsRover
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please select the action you want to do.(1 or 2) \r\n 1) Use Test Input \r\n 2) Enter Nasa Input");
            int choose = Convert.ToInt32(Console.ReadLine());
            string commandStr = string.Empty;
            switch (choose)
            {
                case 1:
                    commandStr = BuildCommands();
                    break;
                case 2:
                    commandStr = RetrieveCommands();
                    break;
                default:
                    Console.WriteLine("Plase choose 1 or 2");
                    break;
            }

            var assembly = Assembly.GetExecutingAssembly();

            var container = new Container();
            container.BuildMediator(assembly);

            container.Register<IPlate, Plate>(Lifestyle.Singleton);
            container.Register<IParse, Parse>(Lifestyle.Singleton);
            container.Register<IRotateAndMoveOperation, RotateAndMoveOperation>(Lifestyle.Singleton);
            container.Verify();

            var commandExecutor = container.GetInstance<IParse>();
            commandExecutor.Parser(commandStr);
            var plateau = container.GetInstance<IPlate>();
            var status = plateau.ToString();

            Console.WriteLine(status);

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

        private static string RetrieveCommands()
        {
            var commandStringBuilder = new StringBuilder();
            var i = 0;
            while (i < 5)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine("Enter surface size:");
                        break;
                    case int n when n % 2 == 1:
                        Console.WriteLine("Enter rover landing coordinates:");
                        break;
                    case int n when n % 2 == 0:
                        Console.WriteLine("Enter commands:");
                        break;
                }

                commandStringBuilder.AppendLine(Console.ReadLine()?.ToUpper());
                i++;
            }

            return commandStringBuilder.ToString();
        }
    }
}
