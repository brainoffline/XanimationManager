using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brain
{
    public class KeyFrame<T>
    {
        public double MilliSeconds { get; set; }
        public T Value { get; set; }
        public Easing Easing { get; set; }
    }

    public abstract class AnimationDefinition
    {
        public uint DurationMS { get; set; }
        public int PauseBeforeMS { get; set; }
        public int PauseAfterMS { get; set; }
        public double SpeedRatio { get; set; }
        public double RepeatCount { get; set; }
        public int RepeatDurationMS { get; set; }
        public int DelayMS { get; set; }
        public bool AutoReverse { get; set; }
        public bool Forever { get; set; }

        public bool OpacityFromZero { get; protected set; }

        protected AnimationDefinition()
        {
            DurationMS = 1000;
        }

        protected Tuple<double, double> GetTranslation(VisualElement element)
        {
            var x = element.TranslationX;
            var y = element.TranslationY;
            return new Tuple<double, double>(x, y);
        }

        public abstract Xamarin.Forms.Animation CreateAnimation(VisualElement element);
    }
}
