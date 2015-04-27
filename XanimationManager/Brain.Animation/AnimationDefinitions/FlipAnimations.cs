using System;
using Xamarin.Forms;

namespace Brain
{
    public class FlipAnimation : AnimationDefinition
    {
        public override Xamarin.Forms.Animation CreateAnimation(VisualElement element)
        {
            var animation = new Xamarin.Forms.Animation();

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
		public Easing Easing { get; set; }

		public FlipInXAnimation()
        {
            OpacityFromZero = true;
			Easing = Easings.QuinticOut;
        }

        public override Xamarin.Forms.Animation CreateAnimation(VisualElement element)
        {
            var animation = new Xamarin.Forms.Animation();

            // CentreOfRotation = Centre
            animation.WithConcurrent( (f) => element.Opacity = f, 0.5, 1);
            animation.WithConcurrent((f) => element.RotationX = f, Reverse ? -90 : 90, 0, Easing);

            return animation;
        }
    }

    public class FlipOutXAnimation : AnimationDefinition
    {
        public bool Reverse { get; set; }
        public double Centre { get; set; }
		public Easing Easing { get; set; }

		public FlipOutXAnimation()
        {
            DurationMS = 400;
			Easing = Easings.QuinticOut;
        }

        public override Xamarin.Forms.Animation CreateAnimation(VisualElement element)
        {
            var animation = new Xamarin.Forms.Animation();

            // CentreOfRotation = Centre
            animation.WithConcurrent((f) => element.RotationX = f, 0, Reverse ? 90 : -90, Easing);
            animation.WithConcurrent((f) => element.Opacity = f, 1, 0);

            return animation;
        }
    }

    public class FlipInYAnimation : AnimationDefinition
    {
        public bool Reverse { get; set; }
        public Double Centre { get; set; }
		public Easing Easing { get; set; }

		public FlipInYAnimation()
        {
            OpacityFromZero = true;
			Easing = Easings.QuinticOut;
        }

        public override Xamarin.Forms.Animation CreateAnimation(VisualElement element)
        {
            var animation = new Xamarin.Forms.Animation();

            // CentreOfRotation = Centre
            animation.WithConcurrent((f) => element.Opacity = f, 0.5, 1);
            animation.WithConcurrent((f) => element.RotationY = f, Reverse ? -90 : 90, 0, Easing);

            return animation;
        }
    }

    public class FlipOutYAnimation : AnimationDefinition
    {
        public FlipOutYAnimation()
        {
            DurationMS = 400;
			Easing = Easings.QuinticOut;
        }

        public bool Reverse { get; set; }
        public Double Centre { get; set; }
		public Easing Easing { get; set; }


        public override Xamarin.Forms.Animation CreateAnimation(VisualElement element)
        {
            var animation = new Xamarin.Forms.Animation();

            // CentreOfRotation = Centre
            animation.WithConcurrent((f) => element.RotationY = f, 0, Reverse ? 90 : -90, Easing);
            animation.WithConcurrent((f) => element.Opacity = f, 1, 0);

            return animation;
        }
    }

}
