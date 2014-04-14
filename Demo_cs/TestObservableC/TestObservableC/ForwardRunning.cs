using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Trik;

namespace TestObservableC
{
    /// <summary>
    /// Class used to show how to use power motors
    /// </summary>
    public class ForwardRunning
    {
        /// <summary>
        /// An example of using power motors
        /// </summary>
        public static void Running()
        {
            powerMotorLeft.SetPower(-30);
            powerMotorRight.SetPower(30);
        }

        /// <summary>
        /// Initializing power motors
        /// </summary>
        private static PowerMotor powerMotorLeft = new PowerMotor(0x17);
        private static PowerMotor powerMotorRight = new PowerMotor(0x14);
    }
}