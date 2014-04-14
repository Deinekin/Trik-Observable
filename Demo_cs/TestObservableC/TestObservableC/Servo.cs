using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trik;

namespace TestObservableC
{
    /// <summary>
    /// Class which allows to use servo motors
    /// </summary>
    public class Servo
    {
        /// <summary>
        /// Initializing servo motor
        /// </summary>
        private static Servomotor servo = new Servomotor("/sys/class/pwm/ehrpwm.0:1", ServoMotor.Servo2);

        /// <summary>
        /// Initializing analog sensor
        /// </summary>
        private static AnalogSensor sensor = new AnalogSensor(0x21);

        /// <summary>
        /// An example of using servo motor and analog sensor. This code spin servo motor in dependence of statements of analog sensor
        /// </summary>
        public static void Running()
        {
            while (true)
            {
                var forward = sensor.Read();
                Console.WriteLine(forward);

                if (forward > 10 && forward < 50)
                    servo.SetPower(30);
                else
                {
                    if (forward >= 50 && forward < 80)
                        servo.SetPower(-60);
                }
            }
        }
    }
}
