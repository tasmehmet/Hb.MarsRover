using HepsiBurada.MarsRover.Infrastructure.Model.Enums;
using HepsiBurada.MarsRover.Infrastructure.Model.Rover;
using HepsiBurada.MarsRover.Infrastructure.Model.Surface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HepsiBurada.MarsRover.Infrastructure.Operations.ParserOperation
{
    public class Parse : IParse
    {
        private readonly IRotateAndMoveOperation _rotateAndMove;

        public Parse(IRotateAndMoveOperation rotateAndMove)
        {
            _rotateAndMove = rotateAndMove;
        }

        void IParse.Parser(string input)
        {
            var commandList = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < commandList.Length; i++)
            {
                var command = commandList[i];
                switch (i)
                {
                    case 0:
                        var plate = ParseSurface(command);
                        _rotateAndMove.SetLandingSurfaceSize(plate);
                        break;
                    case int n when i % 2 == 1:
                        (CoordinatesPoint point, CompassPoints cp) = ParseCurrentPosition(command);
                        _rotateAndMove.SetRoverCurrentPosition(point, cp);
                        break;
                    case int n when i % 2 == 0:
                        var movements = ParseMovement(command);
                        _rotateAndMove.Movement(movements);
                        break;
                    default:
                        throw new NotImplementedException();

                }
            }
        }
        private static Plate ParseSurface(string input)
        {
            var commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Plate point = new Plate();
            point.SetSize(int.Parse(commands[0]), int.Parse(commands[1]));
            return point;
        }

        private static (CoordinatesPoint point, CompassPoints cp) ParseCurrentPosition(string input)
        {
            var commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            CoordinatesPoint point = new CoordinatesPoint(int.Parse(commands[0]), int.Parse(commands[1]));
            var d = (CompassPoints)Enum.Parse(typeof(CompassPoints), commands[2]);

            return (point, d);
        }

        private static IEnumerable<StringMovement> ParseMovement(string input)
        {
            return input.Select(p => (StringMovement)Enum.Parse(typeof(StringMovement), p.ToString()));
        }
    }
}
