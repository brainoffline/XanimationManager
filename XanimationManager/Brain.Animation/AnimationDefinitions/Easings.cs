using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


/// <summary>
/// Inspiration from 
///     http://gizma.com/easing/
///     http://www.robertpenner.com/easing/penner_easing_as1.txt
///     http://docs.phaser.io/Easing.js.html
/// </summary>

namespace Brain
{
    public static class Easings
    {
        public static Easing QuadraticIn = QuadraticEasing.In;
        public static Easing QuadraticOut = QuadraticEasing.Out;
        public static Easing QuadraticInOut = QuadraticEasing.InOut;

        public static Easing CubicIn = CubicEasing.In;
        public static Easing CubicOut = CubicEasing.Out;
        public static Easing CubicInOut = CubicEasing.InOut;

        public static Easing QuarticIn = QuarticEasing.In;
        public static Easing QuarticOut = QuarticEasing.Out;
        public static Easing QuarticInOut = QuarticEasing.InOut;

        public static Easing QuinticIn = QuinticEasing.In;
        public static Easing QuinticOut = QuinticEasing.Out;
        public static Easing QuinticInOut = QuinticEasing.InOut;

        public static Easing SinusoidalIn = SinusoidalEasing.In;
        public static Easing SinusoidalOut = SinusoidalEasing.Out;
        public static Easing SinusoidalInOut = SinusoidalEasing.InOut;

        public static Easing ExponentialIn = ExponentialEasing.In;
        public static Easing ExponentialOut = ExponentialEasing.Out;
        public static Easing ExponentialInOut = ExponentialEasing.InOut;

        public static Easing CircularIn = CircularEasing.In;
        public static Easing CircularOut = CircularEasing.Out;
        public static Easing CircularInOut = CircularEasing.InOut;

        public static Easing ElasticIn = ElasticEasing.In;
        public static Easing ElasticOut = ElasticEasing.Out;
        public static Easing ElasticInOut = ElasticEasing.InOut;

        public static Easing BackIn = BackEasing.In;
        public static Easing BackOut = BackEasing.Out;
        public static Easing BackInOut = BackEasing.InOut;

        public static Easing BounceIn = BounceEasing.In;
        public static Easing BounceOut = BounceEasing.Out;
        public static Easing BounceInOut = BounceEasing.InOut;

    }

    /// <summary>
    /// Easing: t^2
    /// </summary>
    internal class QuadraticEasing
    {
        public static Easing In = new Easing(x => x * x);
        public static Easing Out = new Easing(x => x * (2 - x));
        public static Easing InOut = new Easing(x =>
        {
            if ((x *= 2) < 1) return 0.5 * x * x;
            return -0.5 * (--x * (x - 2) - 1);
        });
    }

    /// <summary>
    /// Easing: t^3
    /// </summary>
    internal class CubicEasing
    {
        public static Easing In = new Easing(x => x * x * x);
        public static Easing Out = new Easing(x => --x * x * x + 1);
        public static Easing InOut = new Easing(x =>
        {
            if ((x *= 2) < 1) return 0.5 * x * x * x;
            return 0.5 * ((x -= 2) * x * x + 2);
        });
    }

    /// <summary>
    /// Easing: t^4
    /// </summary>
    internal class QuarticEasing
    {
        public static Easing In = new Easing(x => x * x * x * x);
        public static Easing Out = new Easing(x => 1 - (--x * x * x * x));
        public static Easing InOut = new Easing(x =>
        {
            if ((x *= 2) < 1) return 0.5 * x * x * x * x;
            return -0.5 * ((x -= 2) * x * x * x - 2);
        });
    }

    /// <summary>
    /// Easing: t^5
    /// </summary>
    internal class QuinticEasing
    {
        public static Easing In = new Easing(x => x * x * x * x * x);
        public static Easing Out = new Easing(x => --x * x * x * x * x + 1);
        public static Easing InOut = new Easing(x =>
        {
            if ((x *= 2) < 1) return 0.5 * x * x * x * x * x;
            return 0.5 * ((x -= 2) * x * x * x * x + 2);
        });
    }


    /// <summary>
    /// Easing: Sinusoidal
    /// </summary>
    internal class SinusoidalEasing
    {
        public static Easing In = new Easing(x =>
        {
            if (x == 0) return 0;
            if (x == 1) return 1;
            return 1 - Math.Cos(x * Math.PI / 2);
        });
        public static Easing Out = new Easing(x =>
        {
            if (x == 0) return 0;
            if (x == 1) return 1;
            return Math.Sin(x * Math.PI / 2);
        });
        public static Easing InOut = new Easing(x =>
        {
            if (x == 0) return 0;
            if (x == 1) return 1;
            return 0.5 * (1 - Math.Cos(Math.PI * x));
        });
    }

    /// <summary>
    /// Easing: Exponential
    /// </summary>
    internal class ExponentialEasing
    {
        public static Easing In = new Easing(x => x == 0 ? 0 : Math.Pow(1024, x - 1));
        public static Easing Out = new Easing(x => x == 1 ? 1 : 1 - Math.Pow(2, -10 * x));
        public static Easing InOut = new Easing(x =>
        {
            if (x == 0) return 0;
            if (x == 1) return 1;
            if ((x *= 2) < 1) return 0.5 * Math.Pow(1024, x - 1);
            return 0.5 * (-Math.Pow(2, -10 * (x - 1)) + 2);
        });
    }


    /// <summary>
    /// Easing : Circular
    /// </summary>
    internal class CircularEasing
    {
        public static Easing In = new Easing(x => 1 - Math.Sqrt(1 - x * x));
        public static Easing Out = new Easing(x => Math.Sqrt(1 - (--x * x)));
        public static Easing InOut = new Easing(x =>
        {
            if ((x *= 2) < 1) return -0.5 * (Math.Sqrt(1 - x * x) - 1);
            return 0.5 * (Math.Sqrt(1 - (x -= 2) * x) + 1);
        });
    }

    /// <summary>
    /// Easing : Elastic
    /// </summary>
    internal class ElasticEasing
    {
        public static Easing In = new Easing(x =>
        {
            double s = 0.0, a = 0.1, p = 0.4;
            if (x == 0) return 0;
            if (x == 1) return 1;
            //if (!a || a < 1) { a = 1; s = p / 4; }
            if (a < 1) { a = 1; s = p / 4; }
            else s = p * Math.Asin(1 / a) / (2 * Math.PI);
            return -(a * Math.Pow(2, 10 * (x -= 1)) * Math.Sin((x - s) * (2 * Math.PI) / p));
        });
        public static Easing Out = new Easing(x =>
        {
            double s = 0.0, a = 0.1, p = 0.4;
            if (x == 0) return 0;
            if (x == 1) return 1;
            //if (!a || a < 1) { a = 1; s = p / 4; }
            if (a < 1) { a = 1; s = p / 4; }
            else s = p * Math.Asin(1 / a) / (2 * Math.PI);
            return (a * Math.Pow(2, -10 * x) * Math.Sin((x - s) * (2 * Math.PI) / p) + 1);
        });
        public static Easing InOut = new Easing(x =>
        {
            double s = 0.0, a = 0.1, p = 0.4;
            if (x == 0) return 0;
            if (x == 1) return 1;
            //if (!a || a < 1) { a = 1; s = p / 4; }
            if (a < 1) { a = 1; s = p / 4; }
            else s = p * Math.Asin(1 / a) / (2 * Math.PI);
            if ((x *= 2) < 1) return -0.5 * (a * Math.Pow(2, 10 * (x -= 1)) * Math.Sin((x - s) * (2 * Math.PI) / p));
            return a * Math.Pow(2, -10 * (x -= 1)) * Math.Sin((x - s) * (2 * Math.PI) / p) * 0.5 + 1;
        });
    }


    internal class BackEasing
    {
        public static Easing In = new Easing(x => {
            var s = 1.70158;
            return x * x * ((s + 1) * x - s);
        });
        public static Easing Out = new Easing(x => {
            var s = 1.70158;
            return --x * x * ((s + 1) * x + s) + 1;
        });
        public static Easing InOut = new Easing(x => {
            var s = 1.70158 * 1.525;
            if ((x *= 2) < 1) return 0.5 * (x * x * ((s + 1) * x - s));
            return 0.5 * ((x -= 2) * x * ((s + 1) * x + s) + 2);
        });
    }

    internal class BounceEasing
    {
        private static Func<double, double> Bounce = x =>
        {
            if (x < (1 / 2.75))
                return 7.5625 * x * x;

            if (x < (2 / 2.75))
                return 7.5625 * (x -= (1.5 / 2.75)) * x + 0.75;

            if (x < (2.5 / 2.75))
                return 7.5625 * (x -= (2.25 / 2.75)) * x + 0.9375;

            return 7.5625 * (x -= (2.625 / 2.75)) * x + 0.984375;
        };

		public static Easing In = new Easing(x => 1 - Bounce(1-x));
        public static Easing Out = new Easing(x => Bounce(x));
        public static Easing InOut = new Easing(x => {
            if (x < 0.5)
                return 0.5 - (Bounce( 1 - (x * 2)) * 0.5);

            return Bounce(x * 2 - 1) * 0.5 + 0.5;
        });
    }

    public class PowerEasing
    {
        private static Func<double, double, double> P = (x, p) => Math.Pow(x, p);

        private double _power;
        public PowerEasing(double power)
        {
            _power = power;
        }

        public Func<double, double> In
        {
            get { return (x) => Math.Pow(x, _power); }
        }
        public Func<double, double> Out
        {
            get { return (x) => 1 - Math.Pow(--x, _power); }
        }
        public Func<double, double> InOut
        {
            get
            {
                return (x) =>
                {
                    if ((x *= 2) < 1) return 0.5 * (Math.Pow(x, _power));
                    //return 0.5 + (0.5 * Math.Pow(--x, _power));     // I havn't found the formula yet
                    //return 1 - Math.Pow(--x, _power);
                    return 0.5;
                };
            }
        }


    }

}
