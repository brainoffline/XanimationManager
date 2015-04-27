using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brain
{
    public enum RotateAnimationDirection
    {
        RotateUp, RotateDown
    }

    public class RotateAnimation : AnimationDefinition
    {
        public double? StartRotation { get; set; }
        public double? EndRotation { get; set; }
        public Easing Easing { get; set; }

        public RotateAnimation()
        {
            DurationMS = 1000;
            StartRotation = 0.0;
            Easing = Easing.SinIn;
        }

        public override Xamarin.Forms.Animation CreateAnimation(VisualElement element)
        {
            double startRotation = 0.0;
            double endRotation;

            if (StartRotation.HasValue)
                startRotation = StartRotation.Value;
            else
                startRotation = element.Rotation;
            if (EndRotation.HasValue)
                endRotation = EndRotation.Value;
            else
                endRotation = startRotation + 360.0;

            var animation = new Xamarin.Forms.Animation();

            element.AnchorX = 0.5;
            element.AnchorY = 0.5;

            animation.WithConcurrent((f) => element.Rotation = f, startRotation, endRotation, Easing);

            return animation;
        }
    }

    public class RotateInAnimation : AnimationDefinition
    {
        public RotateAnimationDirection RotateDirection;

        public RotateInAnimation()
        {
            DurationMS = 400;
            OpacityFromZero = true;
        }

        public override Xamarin.Forms.Animation CreateAnimation(VisualElement element)
        {
            var animation = new Xamarin.Forms.Animation();

            if (RotateDirection == RotateAnimationDirection.RotateUp)
            {
                element.AnchorX = 0;
                element.AnchorY = 1.5;

                animation.WithConcurrent((f) => element.Rotation = f, 45, 0, Easing.SinIn);
            }
            else
            {
                element.AnchorX = 0;
                element.AnchorY = -0.5;

                animation.WithConcurrent((f) => element.Rotation = f, -45, 0, Easing.SinIn);
            }
            animation.WithConcurrent((f) => element.Opacity = f, 0, 1, Easing.SinIn, 0, 0.25);

            return animation;
        }

    }

    public class RotateOutAnimation : AnimationDefinition
    {
        public RotateAnimationDirection RotateDirection;

        public RotateOutAnimation()
        {
            DurationMS = 400;
        }

        public override Xamarin.Forms.Animation CreateAnimation(VisualElement element)
        {
            var animation = new Xamarin.Forms.Animation();

            if (RotateDirection == RotateAnimationDirection.RotateUp)
            {
                element.AnchorX = 0;
                element.AnchorY = 1.5;

                animation.WithConcurrent((f) => element.Rotation = f, 0, 45, Easing.SinOut);
            }
            else
            {
                element.AnchorX = 0;
                element.AnchorY = -0.5;

                animation.WithConcurrent((f) => element.Rotation = f, 0, -45, Easing.SinOut);
            }
            animation.WithConcurrent((f) => element.Opacity = f, 1, 0, Easing.SinOut, 0.5, 1);

            return animation;
        }

    }
}
