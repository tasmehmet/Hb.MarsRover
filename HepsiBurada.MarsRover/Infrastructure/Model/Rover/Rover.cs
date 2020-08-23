using System;
using System.Collections.Generic;
using System.Text;
using HepsiBurada.MarsRover.Infrastructure.Model.Enums;
using HepsiBurada.MarsRover.Infrastructure.Model.Surface;

namespace HepsiBurada.MarsRover.Infrastructure.Model.Rover
{
    public class Rover : IRover
    {
        private CompassPoints _compassPoints;
        private CoordinatesPoint _coordinatesPoint;

        public Rover(CoordinatesPoint coordinatesPoint, CompassPoints compassPoints)
        {
            _compassPoints = compassPoints;
            _coordinatesPoint = coordinatesPoint;
        }

        public CompassPoints GetCompassPoints()
        {
            return _compassPoints;
        }

        public CoordinatesPoint GetCoordinatesPoint()
        {
            return _coordinatesPoint;
        }

        public void Move(IEnumerable<StringMovement> movements, IPlate plate)
        {
            var newCoordinatesPoint = new CoordinatesPoint(_coordinatesPoint.X, _coordinatesPoint.Y);
            switch (_compassPoints)
            {
                case CompassPoints.N:
                    newCoordinatesPoint.SetForwardY();
                    break;
                case CompassPoints.E:
                    newCoordinatesPoint.SetForwardX();
                    break;
                case CompassPoints.S:
                    newCoordinatesPoint.SetBackwardY();
                    break;
                case CompassPoints.W:
                    newCoordinatesPoint.SetBackwardX();
                    break;
                default:
                    break;
            }
        }
        public void MoveLeft()
        {
            switch (_compassPoints)
            {
                case CompassPoints.N:
                    _compassPoints = CompassPoints.W;
                    break;
                case CompassPoints.E:
                    _compassPoints = CompassPoints.N;
                    break;
                case CompassPoints.S:
                    _compassPoints = CompassPoints.E;
                    break;
                case CompassPoints.W:
                    _compassPoints = CompassPoints.S;
                    break;
                default:
                    break;
            }
        }
        public void MoveRight()
        {
            switch (_compassPoints)
            {
                case CompassPoints.N:
                    _compassPoints = CompassPoints.E;
                    break;
                case CompassPoints.E:
                    _compassPoints = CompassPoints.S;
                    break;
                case CompassPoints.S:
                    _compassPoints = CompassPoints.W;
                    break;
                case CompassPoints.W:
                    _compassPoints = CompassPoints.N;
                    break;
                default:
                    break;
            }
        }
        public override string ToString()
        {
            return $"{_coordinatesPoint} - {_compassPoints.ToString()}";
        }
    }
}
