using Brain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAnimations
{
	public partial class LandingPage : ContentPage
	{
		public LandingPage()
		{
			InitializeComponent();
		}

		public async void DropButton_OnClick(object sender, EventArgs args)
		{
			await DropButton.Animate(new HingeAnimation { AnchorX = 0.2, AnchorY = 0.5 });

			await Task.Delay(1000);
			DropButton.ClearTransforms();
		}

		public async void EasingButton_OnClick(object sender, EventArgs args)
		{
			string animation = "";
			if (sender == EasingInButton)
				animation = "in";
			else if (sender == EasingOutButton)
				animation = "out";

			switch (animation)
			{
				case "in":
					new Animation(x => DropButton.TranslationX = x, 0, 200, Easings.QuadraticIn).Commit(DropButton, "", 16, 2000);
					new Animation(x => EasingInButton.TranslationX = x, 0, 200, Easings.CubicIn).Commit(EasingInButton, "", 16, 2000);
					new Animation(x => EasingOutButton.TranslationX = x, 0, 200, Easings.QuarticIn).Commit(EasingOutButton, "", 16, 2000);
					new Animation(x => EasingInOutButton.TranslationX = x, 0, 200, Easings.QuinticIn).Commit(EasingInOutButton, "", 16, 2000);
					//new Animation(x => lbl.TranslationX = x, 0, 200, Easings.CircularIn).Commit(lbl, "", 16, 2000);
					break;

				case "out":
					new Animation(x => DropButton.TranslationX = x, 0, 200, Easings.QuadraticOut).Commit(DropButton, "", 16, 2000);
					new Animation(x => EasingInButton.TranslationX = x, 0, 200, Easings.CubicOut).Commit(EasingInButton, "", 16, 2000);
					new Animation(x => EasingOutButton.TranslationX = x, 0, 200, Easings.QuarticOut).Commit(EasingOutButton, "", 16, 2000);
					new Animation(x => EasingInOutButton.TranslationX = x, 0, 200, Easings.QuinticOut).Commit(EasingInOutButton, "", 16, 2000);
					//new Animation(x => lbl.TranslationX = x, 0, 200, Easings.CircularOut).Commit(lbl, "", 16, 2000);
					break;

				default:
					new Animation(x => DropButton.TranslationX = x, 0, 200, Easings.QuadraticInOut).Commit(DropButton, "", 16, 2000);
					new Animation(x => EasingInButton.TranslationX = x, 0, 200, Easings.CubicInOut).Commit(EasingInButton, "", 16, 2000);
					new Animation(x => EasingOutButton.TranslationX = x, 0, 200, Easings.QuarticInOut).Commit(EasingOutButton, "", 16, 2000);
					new Animation(x => EasingInOutButton.TranslationX = x, 0, 200, Easings.QuinticInOut).Commit(EasingInOutButton, "", 16, 2000);
					//new Animation(x => lbl.TranslationX = x, 0, 200, Easings.CircularInOut).Commit(lbl, "", 16, 2000);
					break;
			}


			await Task.Delay(2500);

			DropButton.ClearTransforms();
			EasingInButton.ClearTransforms();
			EasingOutButton.ClearTransforms();
			EasingInOutButton.ClearTransforms();
			//lbl.ClearTransforms();
		}

	}
}
