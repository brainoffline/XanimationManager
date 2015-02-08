using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brain
{
    public enum Side
    {
        Left, Right
    }

    public class HingeAnimation : AnimationDefinition
    {
        public Side Side { get; set; }
        public double Distance { get; set; }
		public double? AnchorX { get; set; }
		public double? AnchorY { get; set; }

		public HingeAnimation()
        {
            DurationMS = 1000;
            Side = Side.Left;
            Distance = 700;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();
            if (Side == Side.Left)
            {
				element.AnchorX = AnchorX.HasValue ? AnchorX.Value : 0;
				element.AnchorY = AnchorY.HasValue ? AnchorY.Value : 0;

                // Rotation
                animation.WithConcurrent((f) => element.Rotation = f, 0, 80, Easing.CubicInOut, 0, 0.2);
                animation.WithConcurrent((f) => element.Rotation = f, 80, 60, Easing.CubicInOut, 0.2, 0.4);
                animation.WithConcurrent((f) => element.Rotation = f, 60, 80, Easing.CubicInOut, 0.4, 0.6);
                animation.WithConcurrent((f) => element.Rotation = f, 80, 60, Easing.CubicInOut, 0.6, 0.8);
                animation.WithConcurrent((f) => element.Rotation = f, 60, 70, Easing.Linear, 0.8, 1);

                // Fall
                animation.WithConcurrent((f) => element.TranslationY = f, element.TranslationY, element.TranslationY + Distance, Easing.CubicIn, 0.7, 1);

                // Opacity
                animation.WithConcurrent((f) => element.Opacity = f, 1, 0, null, 0.9, 1);
            }
            else
            {
				element.AnchorX = AnchorX.HasValue ? AnchorX.Value : 1;
				element.AnchorY = AnchorY.HasValue ? AnchorY.Value : 0;

				// Rotation
				animation.WithConcurrent((f) => element.Rotation = f, 0, -80, Easing.CubicInOut, 0, 0.2);
                animation.WithConcurrent((f) => element.Rotation = f, -80, -60, Easing.CubicInOut, 0.2, 0.4);
                animation.WithConcurrent((f) => element.Rotation = f, -60, -80, Easing.CubicInOut, 0.4, 0.6);
                animation.WithConcurrent((f) => element.Rotation = f, -80, -60, Easing.CubicInOut, 0.6, 0.8);
                animation.WithConcurrent((f) => element.Rotation = f, -60, -70, Easing.Linear, 0.8, 1);

                // Fall
                animation.WithConcurrent((f) => element.TranslationY = f, element.TranslationY, element.TranslationY + Distance, Easing.CubicIn, 0.7, 1);

                // Opacity
                animation.WithConcurrent((f) => element.Opacity = f, 1, 0, null, 0.9, 1);
            }

            return animation;
        }
    }
}
