using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Trik;
using System.IO;

namespace TestObservableC
{
    public class Lights
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

        public static void LightDiode()
        {
            LED("/sys/class/leds");

            while (true)
            {
                var forward = analogSensor.Read();
                Console.WriteLine(forward);

                if (forward > 10 && forward <= 40)
                {
                    SetGreen(true);
                    SetRed(false);
                }
                else
                {
                    if (forward > 40 && forward <= 60)
                    {
                        SetRed(true);
                        SetGreen(true);
                    }

                    else
                    {
                        if (forward > 60 && forward <= 80)
                        {SetGreen(false);
                            SetRed(true);
                            }

                        else
                            SetOff();
                    }
                }
            }
        }

        private static AnalogSensor analogSensor = new AnalogSensor(0x21);
        private static FileStream red = null;
        private static FileStream green = null;
    }
}
