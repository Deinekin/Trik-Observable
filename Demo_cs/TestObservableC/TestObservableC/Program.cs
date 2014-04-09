using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Trik;
using System.Threading;
using System.IO.Pipes;
using System.IO;

namespace TestObservableC
{
    public class Program
    {
        static void Main(string[] args)
        {
            Helpers.I2C.init("/dev/i2c-2", 0x48, 1);
            Helpers.I2C.send(0x10, 0x1000, 2);
            Helpers.I2C.send(0x11, 0x1000, 2);

            //RunningObstacle.Running();
            //ForwardRunning.Running();
            //Lights.LightDiode();
            RunningAlongWall.Running();
        }
    }
}