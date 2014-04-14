using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Trik;
using System.Threading;
using System.IO;

namespace TestObservableC
{
    /// <summary>
    /// This class used to show how to use light diode, analog sensor and power motors
    /// </summary>
    public class RunningObstacle
    {
        /// <summary>
        /// An example of using power motors, analog sensor and light diode. This code forces robot to stop if it runs too close to an obstacle
        /// </summary>
        public static void Running()
        {
            while (true)
            {
                var forward = analogSensor.Read();
                Console.WriteLine(forward);

                if (forward > 5 && forward <= 40)
                {
                    led.SetColor(LedColor.Green);
                    powerMotorLeft.SetPower(-100);
                    powerMotorRight.SetPower(100);
                }
                else
                {
                    if (forward > 40 && forward < 60)
                    {
                        led.SetColor(LedColor.Orange);
                        powerMotorLeft.SetPower(-30);
                        powerMotorRight.SetPower(30);
                    }
                    else
                    {
                        if (forward >= 60 && forward < 80)
                        {
                            led.SetColor(LedColor.Red);
                            powerMotorLeft.SetPower(0);
                            powerMotorRight.SetPower(0);
                        }
                        else
                        {
                            led.SetColor(LedColor.Off);
                            powerMotorLeft.SetPower(50);
                            powerMotorRight.SetPower(-50);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializing power motors
        /// </summary>
        private static PowerMotor powerMotorLeft = new PowerMotor(0x17);
        private static PowerMotor powerMotorRight = new PowerMotor(0x14);

        /// <summary>
        /// Initializing analog sensor
        /// </summary>
        private static AnalogSensor analogSensor = new AnalogSensor(0x21);

        /// <summary>
        /// Initializing light diode
        /// </summary>
        private static Led led = new Led("/sys/class/leds");
    }
}
