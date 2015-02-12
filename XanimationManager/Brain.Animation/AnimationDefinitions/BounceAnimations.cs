using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brain
{
    public enum ZDirection
    {
        Away, Closer, Steady
    }


	public enum CircleDirection
	{
		TopLeft, TopRight, BottomRight, BottomLeft
	}

	public class CircleInAnimation : AnimationDefinition
	{
		public CircleDirection FromDirection { get; set; }
		public ZDirection FromZDirection { get; set; }
		public double Distance { get; set; }
		private double DistanceX { get; set; }
		private double DistanceY { get; set; }


		public CircleInAnimation()
		{
			DurationMS = 400;
			OpacityFromZero = true;
			FromDirection = CircleDirection.BottomLeft;
			FromZDirection = ZDirection.Away;
			Distance = 200;
			DistanceX = 0;
			DistanceY = 0;
		}

		public override Animation CreateAnimation(VisualElement element)
		{
			var translation = GetTranslation(element);
			var animation = new Animation();

			if (FromZDirection != ZDirection.Steady)
			{
				animation.WithConcurrent(
					f => element.Scale = f,
					(FromZDirection == ZDirection.Away ? 0.3 : 2.0), 1,
					Easings.BackOut, 0, 1);
			};
			animation.WithConcurrent(
				(f) => element.Opacity = f,
				0, 1,
				null,
				0, 0.25);

			switch (FromDirection)
			{
				case CircleDirection.TopLeft:
					DistanceX = Distance * -0.5;
					DistanceY = -Distance;
					break;
				case CircleDirection.TopRight:
					DistanceX = Distance * 0.5;
					DistanceY = -Distance;
					break;
				case CircleDirection.BottomLeft:
					DistanceX = Distance * -0.5;
					DistanceY = Distance;
					break;
				case CircleDirection.BottomRight:
					DistanceX = Distance * 0.5;
					DistanceY = Distance;
					break;
			}

			animation.WithConcurrent(
				(f) => element.TranslationX = f,
				element.TranslationX + DistanceX, element.TranslationX,
				Easings.QuinticOut,
				0, 0.7);

			animation.WithConcurrent(
				(f) => element.TranslationY = f,
				element.TranslationY + DistanceY, element.TranslationY,
				Easings.BackOut,
				0, 1);

			return animation;
		}
	}

	public class BounceInAnimation : AnimationDefinition
    {
        public ZDirection FromDirection { get; set; }
        public double DistanceX { get; set; }
        public double DistanceY { get; set; }

        public BounceInAnimation()
        {
            DurationMS = 400;
            OpacityFromZero = true;
            FromDirection = ZDirection.Away;
            DistanceX = 0;
            DistanceY = 0;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var translation = GetTranslation(element);
            var animation = new Animation();

            if (FromDirection != ZDirection.Steady)
            {
                animation.WithConcurrent(
                    f => element.Scale = f, 
                    (FromDirection == ZDirection.Away ? 0.3 : 2.0), 1, 
                    Easings.BackOut, 0, 1);
            };
            animation.WithConcurrent(
                (f) => element.Opacity = f,
                0, 1, 
                null, 
                0, 0.25);

            if (Math.Abs(DistanceX) > 0)
            {
                animation.WithConcurrent(
                    (f) => element.TranslationX = f,
                    element.TranslationX + DistanceX, element.TranslationX,
                    Easings.BackOut,
                    0, 1);
            }
            if (Math.Abs(DistanceY) > 0)
            {
                animation.WithConcurrent(
                    (f) => element.TranslationY = f,
                    element.TranslationY + DistanceY, element.TranslationY,
                    Easings.BackOut,
                    0, 1);
            }

            return animation;
        }
    }

    public class BounceInUpAnimation : BounceInAnimation
    {
        public double Distance
        {
            get { return DistanceY; }
            set { DistanceY = value; }
        }

        public BounceInUpAnimation()
        {
            Distance = 500;
        }
    }

    public class BounceInDownAnimation : BounceInAnimation
    {
        public double Distance
        {
            get { return DistanceY; }
            set { DistanceY = value; }
        }

        public BounceInDownAnimation()
        {
            Distance = -500;
        }
    }

    public class BounceInLeftAnimation : BounceInAnimation
    {
        public double Distance
        {
            get { return DistanceX; }
            set { DistanceX = value; }
        }

        public BounceInLeftAnimation()
        {
            Distance = 500;
        }
    }

    public class BounceInRightAnimation : BounceInAnimation
    {
        public double Distance
        {
            get { return DistanceX; }
            set { DistanceX = value; }
        }

        public BounceInRightAnimation()
        {
            Distance = -500;
        }
    }

    public class BounceOutAnimation : AnimationDefinition
    {
        public ZDirection ToDirection { get; set; }
        public double Amplitude { get; set; }
        public double DistanceX { get; set; }
        public double DistanceY { get; set; }

        public BounceOutAnimation()
        {
            DurationMS = 400;
            ToDirection = ZDirection.Away;
            Amplitude = 0.4;
            DistanceX = 0;
            DistanceY = 0;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var translation = GetTranslation(element);
            var animation = new Animation();

            element.Opacity = 1;
            animation.WithConcurrent(
                (f) => element.Opacity = f,
                1, 0,
                null, 
                0.5, 1);

            if (ToDirection != ZDirection.Steady)
            {
                animation.WithConcurrent(
                    (f) => element.Scale = f,
                    1, (ToDirection == ZDirection.Away ? 0.3 : 2.0),
                    Easings.BackIn, 0, 1);
            }
            if (Math.Abs(DistanceX) > 0)
            {
                animation.WithConcurrent(
                    (f) => element.TranslationX = f,
                    element.TranslationX, element.TranslationX + DistanceX,
                    Easings.BackIn,
                    0, 1);
            }
            if (Math.Abs(DistanceY) > 0)
            {
                animation.WithConcurrent(
                    (f) => element.TranslationX = f,
                    element.TranslationY, element.TranslationY + DistanceY,
                    Easings.BackIn,
                    0, 1);
            }

            return animation;
        }
    }

    public class BounceOutUpAnimation : BounceOutAnimation
    {
        public double Distance
        {
            get { return DistanceY; }
            set { DistanceY = value; }
        }

        public BounceOutUpAnimation()
        {
            Distance = -500;
        }
    }

    public class BounceOutDownAnimation : BounceOutAnimation
    {
        public double Distance
        {
            get { return DistanceY; }
            set { DistanceY = value; }
        }

        public BounceOutDownAnimation()
        {
            Distance = 500;
        }
    }

    public class BounceOutLeftAnimation : BounceOutAnimation
    {
        public double Distance
        {
            get { return DistanceX; }
            set { DistanceX = value; }
        }

        public BounceOutLeftAnimation()
        {
            Distance = -500;
        }
    }

    public class BounceOutRightAnimation : BounceOutAnimation
    {
        public double Distance
        {
            get { return DistanceX; }
            set { DistanceX = value; }
        }

        public BounceOutRightAnimation()
        {
            Distance = 500;
        }
    }

}
