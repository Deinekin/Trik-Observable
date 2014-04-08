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
        private static FileStream red = null;
        private static FileStream green = null;

        public static void LED(string path)
        {
            green = File.OpenWrite(path + "/led_green/brightness");
            red = File.OpenWrite(path + "/led_red/brightness");
        }

        public static void SetGreen(bool flag)
        {
            green.Write(new byte[] { Convert.ToByte(flag ? 49 : 48) }, 0, 1);
            green.Flush();
        }

        public static void SetRed(bool flag)
        {
            red.Write(new byte[] { Convert.ToByte(flag ? 49 : 48) }, 0, 1);
            red.Flush();
        }

        public static void SetOff()
        {
            SetGreen(false);
            SetRed(false);
        }

        static void Main(string[] args)
        {
            Helpers.I2C.init("/dev/i2c-2", 0x48, 1);
            Helpers.I2C.send(0x10, 0x1000, 2);
            Helpers.I2C.send(0x11, 0x1000, 2);

            var gyro = new Gyroscope(0, 32000, "/dev/input/by-path/platform-spi_davinci.1-event");
            var analogSensor = new AnalogSensor(0x24);

            var powerMotorLeft = new Trik.PowerMotor(0x17);
            var powerMotorRight = new Trik.PowerMotor(0x14);

            LED("/sys/class/leds");

            var reader = new StreamReader("Pipe");


            while (true)
            {
                string str = reader.ReadLine();
                if (str.Length != 0)
                    Console.WriteLine(str);
                Thread.Sleep(50);

                var forward = analogSensor.Read();
                Console.WriteLine(forward);

                if (str == "rus_forward")
                {
                    SetGreen(true);
                    powerMotorLeft.SetPower(100);
                    powerMotorRight.SetPower(-100);
                }

                if (str == "rus_stop")
                {
                    SetRed(true);
                    SetGreen(false);
                    powerMotorLeft.SetPower(0);
                    powerMotorRight.SetPower(0);
                }

                if (str == "rus_back")
                {
                    SetGreen(true);
                    powerMotorLeft.SetPower(-50);
                    powerMotorRight.SetPower(50);
                }

                if (forward > 10 && forward <= 40)
                {
                    SetRed(false);
                    powerMotorLeft.SetPower(100);
                    powerMotorRight.SetPower(-100);
                }
                else
                {
                    if (forward > 40 && forward < 60)
                    {
                        SetGreen(true);
                        SetRed(true);
                        powerMotorLeft.SetPower(30);
                        powerMotorRight.SetPower(-30);
                    }
                    else
                    {
                        if (forward >= 60 && forward < 80)
                        {
                            SetGreen(false);
                            powerMotorLeft.SetPower(0);
                            powerMotorRight.SetPower(0);
                        }
                        else
                        {
                            SetOff();
                            powerMotorLeft.SetPower(-50);
                            powerMotorRight.SetPower(50);
                        }
                    }
                }
            }
        }
    }
}