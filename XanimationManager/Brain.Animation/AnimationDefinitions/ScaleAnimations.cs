using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brain
{
    public class ScaleInAnimation : AnimationDefinition
    {
        public double StartScale = 0.7;

        public ScaleInAnimation()
        {
            DurationMS = 400;
            OpacityFromZero = true;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            animation.WithConcurrent((f) => element.Opacity = f, 0, 1, null, 0, 0.5);
            animation.WithConcurrent((f) => element.Scale = f, StartScale, 1, Easing.CubicOut);

            return animation;
        }

    }

    public class ScaleOutAnimation : AnimationDefinition
    {
        public double EndScale = 0.7;

        public ScaleOutAnimation()
        {
            DurationMS = 400;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            animation.WithConcurrent((f) => element.Opacity = f, 1, 0, null, 0.5, 1);
            animation.WithConcurrent((f) => element.Scale = f, element.Scale, EndScale, Easing.CubicIn);

            return animation;
        }
    }

    public class ScaleFromElementAnimation : AnimationDefinition
    {
        public VisualElement FromElement { get; set; }

        public ScaleFromElementAnimation()
        {
            OpacityFromZero = true;
            DurationMS = 400;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var toBounds = element.Bounds;
            var fromBounds = FromElement.Bounds;

            element.Layout(fromBounds);
            element.AnchorX = 0;
            element.AnchorY = 0;

            var animation = new Animation();

            animation.WithConcurrent((f) => element.Opacity = f, 0, 1, null, 0, 0.25);
            animation.WithConcurrent((f) =>
            {
                var newBounds = new Rectangle(
                                fromBounds.X + (toBounds.X - fromBounds.X) * f,
                                fromBounds.Y + (toBounds.Y - fromBounds.Y) * f,
                                fromBounds.Width + (toBounds.Width - fromBounds.Width) * f,
                                fromBounds.Height + (toBounds.Height - fromBounds.Height) * f);
                element.Layout(newBounds);
            });

            return animation;
        }

    }

}
