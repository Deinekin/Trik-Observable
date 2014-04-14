using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Trik;
using System.IO;

namespace TestObservableC
{
    /// <summary>
    /// Class which shows how to use analog sensor and light diode
    /// </summary>
    public class Lights
    {
        /// <summary>
        /// An example of using analog sensor and light diode. This code works like a light. 
        /// </summary>
        public static void LightDiode()
        {
            while (true)
            {
                var forward = analogSensor.Read();
                Console.WriteLine(forward);

                if (forward > 5 && forward <= 40)
                {
                    led.SetColor(LedColor.Green);
                }
                else
                {
                    if (forward > 40 && forward <= 60)
                    {
                        led.SetColor(LedColor.Orange);
                    }

                    else
                    {
                        if (forward > 60 && forward <= 80)
                        {
                            led.SetColor(LedColor.Red);
                        }

                        else
                            led.SetColor(LedColor.Off);
                    }
                }
            }
        }

        /// <summary>
        /// Initializing light diode
        /// </summary>
        private static Led led = new Led("/sys/class/leds");

        /// <summary>
        /// Initializing analog sensor
        /// </summary>
        private static AnalogSensor analogSensor = new AnalogSensor(0x21);
    }
}
