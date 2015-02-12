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
			await FlipBox.Animate(new FlipInXAnimation());
			await FlipBox.Animate(new FlipOutXAnimation());

			await Task.Delay(500);
			FlipBox.ClearTransforms();

			await FlipBox.Animate(new FlipInYAnimation());
			await FlipBox.Animate(new FlipOutYAnimation());

			await Task.Delay(500);

			FlipBox.ClearTransforms();
			animating = false;
		}

	}
}
