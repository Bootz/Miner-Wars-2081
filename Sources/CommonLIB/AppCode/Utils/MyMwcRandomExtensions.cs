﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class MyMwcRandomExtensions
    {
        /// <summary>
        /// Return number from -3,3
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        public static float FloatNormal(this Random rnd)
        {
            // Use Box-Muller algorithm
            double u1 = rnd.NextDouble();
            double u2 = rnd.NextDouble();
            double r = Math.Sqrt(-2.0 * Math.Log(u1));
            double theta = 2.0 * Math.PI * u2;
            return (float)(r * Math.Sin(theta));
            //return (phi((float)rnd.NextDouble() * 2 - 1) - 0.15f) / 0.7f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rnd"></param>
        /// <param name="mean"></param>
        /// <param name="standardDeviation">0.2f gets numbers aprox from -1,1</param>
        /// <returns></returns>
        public static float FloatNormal(this Random rnd, float mean, float standardDeviation)
        {
            if (standardDeviation <= 0.0)
            {
                string msg = string.Format("Shape must be positive. Received {0}.", standardDeviation);
                throw new ArgumentOutOfRangeException(msg);
            }
            return mean + standardDeviation * FloatNormal(rnd);
        }

        public static float phi(float x)
        {
            const float a1 = 0.254829592f;
            const float a2 = -0.284496736f;
            const float a3 = 1.421413741f;
            const float a4 = -1.453152027f;
            const float a5 = 1.061405429f;
            const float p = 0.3275911f;

            float sign = 1;
            if (x < 0)
            {
                sign = -1;
            }
            x = (float)(Math.Abs(x) / Math.Sqrt(2.0f));

            //# A&S formula 7.1.26
            float t = 1.0f / (1.0f + p * x);
            float y = 1.0f - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * (float)Math.Exp(-x * x);

            return 0.5f * (1.0f + sign * y);
        }
    }
}
