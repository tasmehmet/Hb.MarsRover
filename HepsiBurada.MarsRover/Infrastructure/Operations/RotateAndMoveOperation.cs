using HepsiBurada.MarsRover.Infrastructure.Model.Enums;
using HepsiBurada.MarsRover.Infrastructure.Model.Rover;
using HepsiBurada.MarsRover.Infrastructure.Model.Surface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.Infrastructure.Operations
{
    public class RotateAndMoveOperation : IRotateAndMoveOperation
    {
        public readonly IPlate _plate;

        public RotateAndMoveOperation(IPlate plate)
        {
            _plate = plate;
        }

        public void Movement(IEnumerable<StringMovement> movements)
        {
            var lastRover = _plate.GetLastRover();
            lastRover.Move(movements, _plate);
        }

        public void SetLandingSurfaceSize(Plate plate)
        {
            _plate.SetSize(plate.Width,plate.Height);
        }

        public void SetRoverCurrentPosition(CoordinatesPoint point, CompassPoints cp)
        {
            var rover = new Rover(point, cp);
            _plate.AddRover(rover);
        }
    }
}
