using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brain
{
    public static class AnimationExtensions
    {
        public static Task<bool> Animate(this VisualElement visualElement, AnimationDefinition animationDefinition)
        {
            var tcs = new TaskCompletionSource<bool>();
            var weakReference = new WeakReference<VisualElement>(visualElement);
            var animation = animationDefinition.CreateAnimation(visualElement);

            // Prevent any opacity challenges when element starts hidden
            if (animationDefinition.OpacityFromZero) visualElement.Opacity = 0;

            if ((animationDefinition.PauseBeforeMS > 0) ||
                (animationDefinition.PauseAfterMS > 0) ||
                (animationDefinition.RepeatCount > 1) ||
                (animationDefinition.DelayMS > 0))
            {
                Task.Run(async () =>
                {
                    if (animationDefinition.PauseBeforeMS > 0)
                        await Task.Delay(animationDefinition.PauseBeforeMS);
                    animation.Commit(visualElement, "", 16, animationDefinition.DurationMS, null, 
                        async (f, a) => {
                            if (animationDefinition.PauseAfterMS > 0)
                                await Task.Delay(animationDefinition.PauseAfterMS);
                            tcs.SetResult(a);
                        }, null);
                });
            }
            else
                animation.Commit(visualElement, "", 16, animationDefinition.DurationMS, null, (f, a) => tcs.SetResult(a), null);

            return tcs.Task;
        }

        public static void ClearTransforms(this VisualElement visualElement)
        {
            visualElement.AbortAnimation("");

            visualElement.BatchBegin();
            visualElement.Opacity = 1;
            visualElement.TranslationX = 0;
            visualElement.TranslationY = 0;
            visualElement.Rotation = 0;
            visualElement.Scale = 1;
            visualElement.RotationX = 0;
            visualElement.RotationY = 0;
            visualElement.BatchCommit();
        }
    }
}
