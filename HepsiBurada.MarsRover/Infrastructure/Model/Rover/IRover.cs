using HepsiBurada.MarsRover.Infrastructure.Model.Enums;
using HepsiBurada.MarsRover.Infrastructure.Model.Surface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.Infrastructure.Model.Rover
{
    public interface IRover
    {
        CoordinatesPoint GetCoordinatesPoint();
        CompassPoints GetCompassPoints();
        void Move(IEnumerable<StringMovement> movements, IPlate plate);
    }
}
