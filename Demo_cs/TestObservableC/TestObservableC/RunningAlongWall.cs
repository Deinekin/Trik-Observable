using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trik;

namespace TestObservableC
{
    public class RunningAlongWall
    {
        /// <summary>
        /// Initializing analof sensor
        /// </summary>
        private static AnalogSensor analogSensor = new AnalogSensor(0x22);

        /// <summary>
        /// Initializing both power motors
        /// </summary>
        private static PowerMotor powerMotorLeft = new PowerMotor(0x17);
        private static PowerMotor powerMotorRight = new PowerMotor(0x14);

        /// <summary>
        /// An example of using analog sensor and power motors. This code forces robot to run along wall
        /// </summary>
        public static void Running()
        {
            while (true)
            {
                var right = analogSensor.Read();
                Console.WriteLine(right);

                if (right > 20 && right < 60)
                {
                    powerMotorLeft.SetPower(-30);
                    powerMotorRight.SetPower(30);
                }
                else
                {
                    powerMotorLeft.SetPower(-30);
                    powerMotorRight.SetPower(70);
                }
            }
        }
    }
}
