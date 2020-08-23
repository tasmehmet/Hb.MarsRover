using HepsiBurada.MarsRover.Infrastructure.Model.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.Infrastructure.Model.Surface
{
    public interface IPlate
    {
        IRover GetLastRover();
        void AddRover(IRover rover);
        void SetSize(int width, int height);
        Plate GetSize();
    }
}
