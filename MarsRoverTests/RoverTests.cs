using HepsiBurada.MarsRover.Infrastructure.Model.Enums;
using HepsiBurada.MarsRover.Infrastructure.Model.Rover;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RoverTests
    {
        [TestFixture]
        public class RoverConstructor
        {
            [Test]
            [TestCase(1, 2, CompassPoints.N)]
            [TestCase(3, 3, CompassPoints.E)]
            public void initialize_rover_with_point_and_direction(int x, int y, CompassPoints direction)
            {
                var point = new CoordinatesPoint(x, y);
                var rover = new Rover(point, direction);

                Assert.AreEqual(rover.GetCoordinatesPoint(), point);
                Assert.AreEqual(rover.GetCompassPoints(), direction);
            }
        }
    }
}