using Brain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAnimations
{
	public partial class LandingPage
	{
		public LandingPage()
		{
			InitializeComponent();
		}

		public void ViewEasingButton_OnClick(object sender, EventArgs args)
		{
			Navigation.PushAsync(new EasingPage());
		}

		public async void DropButton_OnClick(object sender, EventArgs args)
		{
			await DropButton.Animate(new HingeAnimation { AnchorX = 0.2, AnchorY = 0.5 });

			await Task.Delay(1000);
			DropButton.ClearTransforms();
		}

		public async void FadeButton_OnClick(object sender, EventArgs args)
		{
			await FadeButton.Animate(new FadeOutAnimation());

            await Navigation.PushAsync(new FadeAnimationsPage());

			await Task.Delay(2000);

			FadeButton.ClearTransforms();
		}

	}
}
