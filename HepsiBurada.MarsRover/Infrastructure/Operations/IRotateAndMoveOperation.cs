
using HepsiBurada.MarsRover.Infrastructure.Model.Enums;
using HepsiBurada.MarsRover.Infrastructure.Model.Rover;
using HepsiBurada.MarsRover.Infrastructure.Model.Surface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.Infrastructure.Operations
{
    public interface IRotateAndMoveOperation
    {
        void SetLandingSurfaceSize(Plate plate);
        void SetRoverCurrentPosition(CoordinatesPoint point, CompassPoints cp);
        void Movement(IEnumerable<StringMovement> movements);
    }
}
