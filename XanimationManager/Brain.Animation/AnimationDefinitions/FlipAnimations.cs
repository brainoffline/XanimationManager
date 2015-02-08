using System;
using Xamarin.Forms;

namespace Brain
{
    public class FlipAnimation : AnimationDefinition
    {
        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            animation.WithConcurrent((f) => element.RotationY = f,   0, 170, null, 0, 0.4);
            animation.WithConcurrent((f) => element.RotationY = f, 170, 190, null, 0.4, 0.5);
            animation.WithConcurrent((f) => element.RotationY = f, 190, 360, null, 0.5, 0.8);

            // Scale to 1.1 then back again
            animation.WithConcurrent((f) => element.Scale = f, 1, 1.3, null, 0.5, 0.8);
            animation.WithConcurrent((f) => element.Scale = f, 1.3, 1, null, 0.8, 1);

            return animation;
        }

    }

    public class FlipInXAnimation : AnimationDefinition
    {
        public bool Reverse { get; set; }
        public double Centre { get; set; }

        public FlipInXAnimation()
        {
            OpacityFromZero = true;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            // CentreOfRotation = Centre
            animation.WithConcurrent( (f) => element.Opacity = f, 0, 1, Easing.CubicOut );

            if (Reverse)
            {
                animation.WithConcurrent((f) => element.RotationX = f, -90, 10, null, 0, 0.4);
                animation.WithConcurrent((f) => element.RotationX = f, 10, -10, null, 0.4, 0.7);
                animation.WithConcurrent((f) => element.RotationX = f, -10, 0, null, 0.7, 1);
            }
            else
            {
                animation.WithConcurrent((f) => element.RotationX = f, 90, -10, null, 0, 0.4);
                animation.WithConcurrent((f) => element.RotationX = f, -10, 10, null, 0.4, 0.7);
                animation.WithConcurrent((f) => element.RotationX = f, 10, 0, null, 0.7, 1);
            }

            return animation;
        }
    }

    public class FlipOutXAnimation : AnimationDefinition
    {
        public bool Reverse { get; set; }
        public double Centre { get; set; }

        public FlipOutXAnimation()
        {
            DurationMS = 400;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            // CentreOfRotation = Centre
            animation.WithConcurrent((f) => element.RotationX = f, 0, Reverse ? 90 : -90, Easing.CubicOut);
            animation.WithConcurrent((f) => element.Opacity = f, 1, 0, Easing.CubicIn);

            return animation;
        }
    }

    public class FlipInYAnimation : AnimationDefinition
    {
        public bool Reverse { get; set; }
        public Double Centre { get; set; }

        public FlipInYAnimation()
        {
            OpacityFromZero = true;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            // CentreOfRotation = Centre
            animation.WithConcurrent((f) => element.Opacity = f, 0, 1, Easing.CubicOut);

            if (Reverse)
            {
                animation.WithConcurrent((f) => element.RotationY = f, -90, 10, null, 0, 0.4);
                animation.WithConcurrent((f) => element.RotationY = f, 10, -10, null, 0.4, 0.7);
                animation.WithConcurrent((f) => element.RotationY = f, -10, 0, null, 0.7, 1);
            }
            else
            {
                animation.WithConcurrent((f) => element.RotationY = f, 90, -10, null, 0, 0.4);
                animation.WithConcurrent((f) => element.RotationY = f, -10, 10, null, 0.4, 0.7);
                animation.WithConcurrent((f) => element.RotationY = f, 10, 0, null, 0.7, 1);
            }

            return animation;
        }
    }

    public class FlipOutYAnimation : AnimationDefinition
    {
        public FlipOutYAnimation()
        {
            DurationMS = 400;
        }

        public bool Reverse { get; set; }
        public Double Centre { get; set; }


        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            // CentreOfRotation = Centre
            animation.WithConcurrent((f) => element.RotationY = f, 0, Reverse ? 90 : -90, Easing.CubicOut);
            animation.WithConcurrent((f) => element.Opacity = f, 1, 0, Easing.CubicIn);

            return animation;
        }
    }

}
