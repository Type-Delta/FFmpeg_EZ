using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFmpeg_EZ
{
    internal class Animation
    {
        /// <summary>
        /// Curve function for Animation, see https://easings.net/ for more cool curve function
        /// </summary>
        public class Curve
        {
            /// <summary>
            /// fast-in slow-out with Lv 3 intensity
            /// </summary>
            /// <param name="keyFrame"></param>
            /// <returns></returns>
            public static double easeOutCubic(double keyFrame)
            {
                return 1 - Math.Pow(1 - keyFrame, 3);
            }

            /// <summary>
            /// fast-in slow-out with Lv 6 intensity
            /// </summary>
            /// <param name="keyFrame"></param>
            /// <returns></returns>
            public static double easeOutExpo(double keyFrame)
            {
                return keyFrame == 1 ? 1 : 1 - Math.Pow(2, -10 * keyFrame);
            }
        }

        /// <summary>
        /// Convert & Handle Animtion curve to automation
        /// Drive backwards when speed is negative 
        /// </summary>
        /// <param name="KeyFrameHolder">KeyFrameAddress KeyFrame must be number between 0-1</param>
        /// <param name="AnimationSpeed">number which will be added each iteration must be number between 0-1; if negative swap End & Start</param>
        /// <param name="AnimationFunction">curve Function</param>
        /// <param name="end"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static unsafe int Driver(
            double* KeyFrameHolder,
            double AnimationSpeed,
            Func<double, double> AnimationFunction,
            int end,
            int start = 0
        )
        {
            if(AnimationSpeed < 0)
            {
                (end, start) = (start, end); //swap using tuple!
                AnimationSpeed *= -1;
            }

            int delta;
            *KeyFrameHolder += AnimationSpeed;
            if (end >= start)
            {
                delta = end - start;
                return (int)((AnimationFunction(*KeyFrameHolder) * delta) + start);
            }
            else {
                delta = start - end;
                int res = (int)(
                    start - (AnimationFunction(*KeyFrameHolder) * delta)            
                ); 
                return res;
            }
            
        }
    }
}
 
