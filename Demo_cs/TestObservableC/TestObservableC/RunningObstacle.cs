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
    public class RunningObstacle
    {
        private static void LED(string path)
        {
            green = File.OpenWrite(path + "/led_green/brightness");
            red = File.OpenWrite(path + "/led_red/brightness");
        }

        private static void SetGreen(bool flag)
        {
            green.Write(new byte[] { Convert.ToByte(flag ? 49 : 48) }, 0, 1);
            green.Flush();
        }

        private static void SetRed(bool flag)
        {
            red.Write(new byte[] { Convert.ToByte(flag ? 49 : 48) }, 0, 1);
            red.Flush();
        }

        private static void SetOff()
        {
            SetGreen(false);
            SetRed(false);
        }

        public static void Running()
        {
            LED("/sys/class/leds");

            while (true)
            {
                var forward = analogSensor.Read();
                Console.WriteLine(forward);

                if (forward > 10 && forward <= 40)
                {
                    SetRed(false);
                    SetGreen(true);
                    powerMotorLeft.SetPower(-100);
                    powerMotorRight.SetPower(100);
                }
                else
                {
                    if (forward > 40 && forward < 60)
                    {
                        SetGreen(true);
                        SetRed(true);
                        powerMotorLeft.SetPower(-30);
                        powerMotorRight.SetPower(30);
                    }
                    else
                    {
                        if (forward >= 60 && forward < 80)
                        {
                            SetGreen(false);
                            SetRed(true);
                            powerMotorLeft.SetPower(0);
                            powerMotorRight.SetPower(0);
                        }
                        else
                        {
                            SetOff();
                            powerMotorLeft.SetPower(50);
                            powerMotorRight.SetPower(-50);
                        }
                    }
                }
            }
        }

        private static FileStream red = null;
        private static FileStream green = null;
        private static PowerMotor powerMotorLeft = new PowerMotor(0x17);
        private static PowerMotor powerMotorRight = new PowerMotor(0x14);
        private static AnalogSensor analogSensor = new AnalogSensor(0x21);
    }
}
