using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brain
{
    public class FadeInAnimation : AnimationDefinition
    {
        public double DistanceX { get; set; }
        public double DistanceY { get; set; }

        public FadeInAnimation()
        {
            DurationMS = 400;
            OpacityFromZero = true;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            animation.WithConcurrent((f) => element.Opacity = f);

            if (Math.Abs(DistanceX) > 0)
            {
                animation.WithConcurrent(
                    (f) => element.TranslationX = f,
                    element.TranslationX + DistanceX, element.TranslationX,
                    Easing.CubicOut);
            }
            if (Math.Abs(DistanceY) > 0)
            {
                animation.WithConcurrent(
                    (f) => element.TranslationY = f,
                    element.TranslationY + DistanceY, element.TranslationY,
                    Easing.CubicOut);
            }

            return animation;
        }
    }

    public class FadeOutAnimation : AnimationDefinition
    {
        public double DistanceX { get; set; }
        public double DistanceY { get; set; }

        public FadeOutAnimation()
        {
            DurationMS = 400;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            animation.WithConcurrent(
                (f) => element.Opacity = f,
                1, 0);

            if (Math.Abs(DistanceX) > 0)
            {
                animation.WithConcurrent(
                    (f) => element.TranslationX = f,
                    element.TranslationX, element.TranslationX + DistanceX);
            }
            if (Math.Abs(DistanceY) > 0)
            {
                animation.WithConcurrent(
                    (f) => element.TranslationY = f,
                    element.TranslationY, element.TranslationY + DistanceY);
            }

            return animation;
        }
    }


    public class FadeInUpAnimation : FadeInAnimation
    {
        public double Distance
        {
            get { return DistanceY; }
            set { DistanceY = value; }
        }

        public FadeInUpAnimation()
        {
            Distance = 20;
        }
    }


    public class FadeInDownAnimation : FadeInAnimation
    {
        public double Distance
        {
            get { return DistanceY; }
            set { DistanceY = value; }
        }

        public FadeInDownAnimation()
        {
            Distance = -20;
        }
    }


    public class FadeInLeftAnimation : FadeInAnimation
    {
        public double Distance
        {
            get { return DistanceX; }
            set { DistanceX = value; }
        }

        public FadeInLeftAnimation()
        {
            Distance = 20;
        }
    }


    public class FadeInRightAnimation : FadeInAnimation
    {
        public double Distance
        {
            get { return DistanceX; }
            set { DistanceX = value; }
        }

        public FadeInRightAnimation()
        {
            Distance = -20;
        }
    }



    public class FadeOutUpAnimation : FadeOutAnimation
    {
        public double Distance
        {
            get { return DistanceY; }
            set { DistanceY = value; }
        }

        public FadeOutUpAnimation()
        {
            Distance = -20;
        }
    }


    public class FadeOutDownAnimation : FadeOutAnimation
    {
        public double Distance
        {
            get { return DistanceY; }
            set { DistanceY = value; }
        }

        public FadeOutDownAnimation()
        {
            Distance = 20;
        }
    }


    public class FadeOutLeftAnimation : FadeOutAnimation
    {
        public double Distance
        {
            get { return DistanceX; }
            set { DistanceX = value; }
        }

        public FadeOutLeftAnimation()
        {
            Distance = -20;
        }
    }


    public class FadeOutRightAnimation : FadeOutAnimation
    {
        public double Distance
        {
            get { return DistanceY; }
            set { DistanceY = value; }
        }

        public FadeOutRightAnimation()
        {
            Distance = 20;
        }
    }
}
