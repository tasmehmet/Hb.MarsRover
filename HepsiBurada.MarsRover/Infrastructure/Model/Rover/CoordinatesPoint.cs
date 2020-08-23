using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.Infrastructure.Model.Rover
{
    public class CoordinatesPoint
    {
        public CoordinatesPoint(int x, int y)
        {
            X = x ;
            Y = y ;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void SetCoordinatesPoint(CoordinatesPoint point)
        {
            X = point.X;
            Y = point.Y;
        }
        public void SetForwardX()
        {
            X++;
        }
        public void SetForwardY()
        {
            Y++;
        }
        public void SetBackwardX()
        {
            X--;
        }
        public void SetBackwardY()
        {
            Y--;
        }
        public override string ToString()
        {
            return $"{X} {Y}";
        }
    }
}
