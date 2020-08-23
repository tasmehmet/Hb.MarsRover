using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HepsiBurada.MarsRover.Infrastructure.Model.Rover;

namespace HepsiBurada.MarsRover.Infrastructure.Model.Surface
{
    public class Plate : IPlate
    {
        private readonly List<IRover> _rovers;

        public Plate()
        {
            _rovers = new List<IRover>();
        }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public void AddRover(IRover rover) 
        {
            if (rover == null)
                throw new ArgumentNullException("argument");
            _rovers.Add(rover);
        }

        public IRover GetLastRover()
        {
            return _rovers.LastOrDefault();
        }

        public Plate GetSize()
        {
            return this;
        }

        public void SetSize(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var rover in _rovers) stringBuilder.AppendLine(rover.ToString());

            return stringBuilder.ToString();
        }
        public bool IsValid(CoordinatesPoint point)
        {
            var widthControl = point.X <= Width && point.X >= 0;
            var heightControl = point.Y <= Height && point.Y >= 0;
            var roverControl = _rovers.Any(p => Equals(p.GetCompassPoints(), point));

            return widthControl && heightControl && !roverControl;
        }
    }
}
