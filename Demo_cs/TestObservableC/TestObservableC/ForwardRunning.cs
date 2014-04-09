using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Trik;

namespace TestObservableC
{
    public class ForwardRunning
    {
        public static void Running()
        {
            powerMotorLeft.SetPower(-30);
            powerMotorRight.SetPower(30);
        }

        private static PowerMotor powerMotorLeft = new PowerMotor(0x17);
        private static PowerMotor powerMotorRight = new PowerMotor(0x14);
    }
}
