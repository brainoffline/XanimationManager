using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brain.AnimationDefinitions
{
    public class TurnstileLeftOutAnimation : AnimationDefinition
    {
        public TurnstileLeftOutAnimation()
        {
            DurationMS = 300;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            // Center of rotation X = 0
            animation.WithConcurrent((f) => element.RotationY = f, 0, -80, Easing.CubicOut);
            animation.WithConcurrent((f) => element.Opacity = f, 1, 0, null, 0.8, 1);

            return animation;
        }

    }

    public class TurnstileLeftInAnimation : AnimationDefinition
    {
        public TurnstileLeftInAnimation()
        {
            DurationMS = 300;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            // Center of rotation X = 0
            animation.WithConcurrent((f) => element.RotationY = f, 80, 0, Easing.CubicOut);
            animation.WithConcurrent((f) => element.Opacity = f, 0, 1, null, 0, 0.01);

            return animation;
        }
    }

    public class TurnstileRightInAnimation : AnimationDefinition
    {
        public TurnstileRightInAnimation()
        {
            DurationMS = 300;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            // Center of rotation X = 1
            animation.WithConcurrent((f) => element.RotationY = f, -80, 0, Easing.CubicOut);
            animation.WithConcurrent((f) => element.Opacity = f, 0, 1, null, 0, 0.2);

            return animation;
        }
    }

    public class TurnstileRightOutAnimation : AnimationDefinition
    {
        public TurnstileRightOutAnimation()
        {
            DurationMS = 300;
        }

        public override Animation CreateAnimation(VisualElement element)
        {
            var animation = new Animation();

            // Center of rotation X = 1
            animation.WithConcurrent((f) => element.RotationY = f, 0, 80, Easing.CubicOut);
            animation.WithConcurrent((f) => element.Opacity = f, 1, 0, null, 0.99, 1);

            return animation;
        }
    }
}
