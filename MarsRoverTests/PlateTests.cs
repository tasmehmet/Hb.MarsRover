using HepsiBurada.MarsRover.Infrastructure.Model.Enums;
using HepsiBurada.MarsRover.Infrastructure.Model.Rover;
using HepsiBurada.MarsRover.Infrastructure.Model.Surface;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PlateTests
    {
        [TestFixture]
        public class PlateauSize
        {
            [Test()]
            [TestCase(5, 5)]
            [TestCase(10, 10)]
            public void plateau_set_size(int width, int height)
            {
                var plateau = new Plate();
                plateau.SetSize(width, height);


                var plate = plateau.GetSize();
                var (w , h) = (plate.Width,plate.Height);
                Assert.AreEqual(h, h);
                Assert.AreEqual(w, w);
            }
        }
        [TestFixture]
        public class PlateauPoint
        {
            [Test()]
            [TestCase(5, 5, 2, 4)]
            [TestCase(10, 10, 9, 8)]
            public void set_size_and_check_point_in_boundaries_returns_true(int plateauW, int plateauH, int pointX,
                int pointY)
            {
                var plate = new Plate();
                plate.SetSize(plateauW, plateauH);
                var point = new CoordinatesPoint(pointX, pointY);
                var isValid = plate.IsValid(point);
                Assert.That(isValid);
            }

            [Test()]
            [TestCase(5, 5, 2, -4)]
            [TestCase(10, 10, 9, 11)]
            public void set_size_and_check_point_in_boundaries_returns_false(int plateauW, int plateauH, int pointX,
                int pointY)
            {
                var plateau = new Plate();
                plateau.SetSize(plateauW, plateauH);
                var point = new CoordinatesPoint(pointX, pointY);
                var isValid = plateau.IsValid(point);
                Assert.That(!isValid);
            }
        }
        [TestFixture]
        public class PlateauRover
        {
            [Test]
            public void add_rover_to_plateau_get_last_added()
            {
                var plateau = new Plate();
                plateau.SetSize(5, 5);

                const CompassPoints direction = CompassPoints.E;
                var roverPosition = new CoordinatesPoint(1, 2);
                var rover = new Rover(roverPosition, direction);
                plateau.AddRover(rover);
                var lastRover = plateau.GetLastRover();
                Assert.AreEqual(rover, lastRover);
            }
        }
    }
}