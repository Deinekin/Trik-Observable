using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trik;
using System.IO;

namespace TestObservableC
{
    public class Linetracer
    {
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

        private static PowerMotor powerMotorLeft = new PowerMotor(0x17);
        private static PowerMotor powerMotorRight = new PowerMotor(0x14);
        private static StreamReader streamReader = new StreamReader(@"/tmp/dsp-detector.out.fifo");
    }
}