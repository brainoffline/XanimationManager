using Brain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAnimations
{
	public partial class FlipAnimationsPage : ContentPage
	{
		public FlipAnimationsPage()
		{
			InitializeComponent();
		}

		private bool animating;
		public async void BeginButton_OnClicked(object sender, EventArgs args)
		{
			if (animating) return;

			animating = true;

			await Task.WhenAll(new[] {
					FlipBoxX.Animate(new FlipInXAnimation()),
					FlipBoxY.Animate(new FlipInYAnimation()),
				});
			await Task.Delay(250);

			await Task.WhenAll(new[] {
					FlipBoxX.Animate(new FlipOutXAnimation()),
					FlipBoxY.Animate(new FlipOutYAnimation()),
				});

			await Task.Delay(500);
			FlipBoxX.ClearTransforms();
			FlipBoxY.ClearTransforms();

			animating = false;
		}

	}
}
