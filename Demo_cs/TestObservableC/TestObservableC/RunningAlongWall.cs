using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trik;

namespace TestObservableC
{
    public class RunningAlongWall
    {
        private static AnalogSensor analogSensor = new AnalogSensor(0x22);
        private static PowerMotor powerMotorLeft = new PowerMotor(0x17);
        private static PowerMotor powerMotorRight = new PowerMotor(0x14);

        public static void Running()
        {
            while (true)
            {
                var forward = analogSensor.Read();
                Console.WriteLine(forward);

                if (forward > 20 && forward < 60)
                {
                    powerMotorLeft.SetPower(-50);
                    powerMotorRight.SetPower(30);
                }
                else
                {
                    powerMotorLeft.SetPower(-30);
                    powerMotorRight.SetPower(50);
                }

            }

        }

    }
}
