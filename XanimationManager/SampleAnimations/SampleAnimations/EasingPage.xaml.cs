using Brain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAnimations
{
	public partial class EasingPage : ContentPage
	{
		public EasingPage()
		{
			InitializeComponent();
		}

		private async void AnimateBoxes(int direction)
		{
			var width = Layout.Width - 80;

			new Animation(x => LinearBox.TranslationX = x, 0, width, Easing.Linear).Commit(LinearBox, "", 16, 2000);
			new Animation(x => QuadraticBox.TranslationX = x, 0, width, direction == 0 ? Easings.QuadraticIn : direction == 1 ? Easings.QuadraticInOut : Easings.QuadraticOut).Commit(QuadraticBox, "", 16, 2000);
			new Animation(x => CubicBox.TranslationX = x, 0, width, direction == 0 ? Easings.CubicIn: direction == 1 ? Easings.CubicInOut: Easings.CubicOut).Commit(CubicBox, "", 16, 2000);
			new Animation(x => QuarticBox.TranslationX = x, 0, width, direction == 0 ? Easings.QuarticIn : direction == 1 ? Easings.QuarticInOut : Easings.QuarticOut).Commit(QuarticBox, "", 16, 2000);
			new Animation(x => QuinticBox.TranslationX = x, 0, width, direction == 0 ? Easings.QuinticIn : direction == 1 ? Easings.QuinticInOut : Easings.QuinticOut).Commit(QuinticBox, "", 16, 2000);
			new Animation(x => SinusoidalBox.TranslationX = x, 0, width, direction == 0 ? Easings.SinusoidalIn : direction == 1 ? Easings.SinusoidalInOut : Easings.SinusoidalOut).Commit(SinusoidalBox, "", 16, 2000);

			new Animation(x => CircularBox.TranslationX = x, 0, width, direction == 0 ? Easings.CircularIn : direction == 1 ? Easings.CircularInOut : Easings.CircularOut).Commit(CircularBox, "", 16, 2000);
			new Animation(x => ElasticBox.TranslationX = x, 0, width, direction == 0 ? Easings.ElasticIn : direction == 1 ? Easings.ElasticInOut : Easings.ElasticOut).Commit(ElasticBox, "", 16, 2000);
			new Animation(x => BackBox.TranslationX = x, 0, width, direction == 0 ? Easings.BackIn : direction == 1 ? Easings.BackInOut : Easings.BackOut).Commit(BackBox, "", 16, 2000);
			new Animation(x => BounceBox.TranslationX = x, 0, width, direction == 0 ? Easings.BounceIn : direction == 1 ? Easings.BounceInOut : Easings.BounceOut).Commit(BounceBox, "", 16, 2000);

			await Task.Delay(2500);

			LinearBox.ClearTransforms();
			QuadraticBox.ClearTransforms();
			CubicBox.ClearTransforms();
			QuarticBox.ClearTransforms();
			QuinticBox.ClearTransforms();
			SinusoidalBox.ClearTransforms();

			CircularBox.ClearTransforms();
			ElasticBox.ClearTransforms();
			BackBox.ClearTransforms();
			BounceBox.ClearTransforms();
		}


		public void InButton_OnClicked(object sender, EventArgs args)
		{
			AnimateBoxes(0);
		}

		public void InOutButton_OnClicked(object sender, EventArgs args)
		{
			AnimateBoxes(1);
		}

		public void OutButton_OnClicked(object sender, EventArgs args)
		{
			AnimateBoxes(2);
		}

	}
}
