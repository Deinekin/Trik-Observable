using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trik;
using System.IO;

namespace TestObservableC
{
    /// <summary>
    /// Class used to show how to work with video module. In file there are values from video module.
    /// First(x) - divergence from the line, third(mass) - how many percents module camera can detect second we dont need.
    /// </summary>
    public class Linetracer
    {
        /// <summary>
        /// Method used to trace the line and run along it. Not the final version, required some fixes
        /// </summary>
        public static void Running()
        {
            while (true)
            {
                string[] words = streamReader.ReadLine().Split(' ');

                var x = Helpers.fastInt32Parse(words[1]);
                var mass = Helpers.fastInt32Parse(words[3]);
                Console.WriteLine(x);
                Console.WriteLine(mass);

                if (mass > 10)
                {
                    if (x > 0)
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

                else
                {
                    if (x > 0)
                    {
                        powerMotorLeft.SetPower(-30);
                        powerMotorRight.SetPower(70);
                    }
                    else
                    {
                        powerMotorLeft.SetPower(-70);
                        powerMotorRight.SetPower(30);
                    }
                }
            }
        }

        /// <summary>
        /// Initializing motors
        /// </summary>
        private static PowerMotor powerMotorLeft = new PowerMotor(0x17);
        private static PowerMotor powerMotorRight = new PowerMotor(0x14);

        /// <summary>
        /// Initializing reader from the file
        /// </summary>
        private static StreamReader streamReader = new StreamReader(@"/tmp/dsp-detector.out.fifo");
    }
}