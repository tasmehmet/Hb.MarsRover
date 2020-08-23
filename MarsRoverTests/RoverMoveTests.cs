using System;
using System.Collections.Generic;
using HepsiBurada.MarsRover.Infrastructure.Model.Enums;
using HepsiBurada.MarsRover.Infrastructure.Model.Rover;
using HepsiBurada.MarsRover.Infrastructure.Model.Surface;
using NUnit.Framework;

namespace Tests
{
    public class RoverMoveTests
    {
        [TestFixture]
        public class Move
        {
            public IPlate _plate = new Plate();
            private static readonly object[] _sourceLists =
            {
                new object[]
                {
                    new CoordinatesPoint(1,2),
                    CompassPoints.N,
                    new List<StringMovement>
                    {
                        StringMovement.L, StringMovement.M, StringMovement.L, StringMovement.M, StringMovement.L,
                        StringMovement.M, StringMovement.L, StringMovement.M, StringMovement.M
                    },
                    1,
                    3,
                    CompassPoints.N
                },
                new object[]
                {
                    new CoordinatesPoint(3,3),
                    CompassPoints.E,
                    new List<StringMovement>
                    {
                        StringMovement.M, StringMovement.M, StringMovement.R, StringMovement.M, StringMovement.M,
                        StringMovement.R, StringMovement.M, StringMovement.R, StringMovement.R, StringMovement.M
                    },
                    5,
                    1,
                    CompassPoints.E
                }
            };

            [Test]
            [TestCaseSource("_sourceLists")]
            public void move_rover_for_12N(CoordinatesPoint coordinatesPoint,
                CompassPoints direction,
                IEnumerable<StringMovement> commands, int cX, int cY, CompassPoints cDirection)
            {
                var roverMove = new Rover(coordinatesPoint, cDirection);
                _plate.SetSize(5, 5);
                _plate.AddRover(roverMove);
               roverMove.Move(commands, _plate);

                var lastRover = _plate.GetLastRover();
                Assert.IsNotNull(lastRover);

                var currentPosition = lastRover.GetCoordinatesPoint();
                var currentDirection = lastRover.GetCompassPoints();

                Assert.IsNotNull(currentPosition);
                Assert.IsNotNull(currentDirection);
                Assert.AreEqual(cX, currentPosition.X);
                Assert.AreEqual(cY, currentPosition.Y);
                Assert.AreEqual(cDirection, currentDirection);
            }

        }
    }
}