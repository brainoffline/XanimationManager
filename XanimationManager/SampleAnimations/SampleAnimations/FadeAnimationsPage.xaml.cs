using Brain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAnimations
{
	public partial class FadeAnimationsPage : ContentPage
	{
		public FadeAnimationsPage()
		{
			InitializeComponent();
		}

		public async void BeginButton_OnClicked(object sender, EventArgs args)
		{
			var tasks = new List<Task> {
				FadeInBox.Animate(new FadeInAnimation { DurationMS = 2000 }),
				FadeOutBox.Animate(new FadeOutAnimation {DurationMS = 2000 }),

				FadeInDownBox.Animate(new FadeInDownAnimation ()),
				FadeInLeftBox.Animate(new FadeInLeftAnimation ()),
				FadeInRightBox.Animate(new FadeInRightAnimation ()),
				FadeInUpBox.Animate(new FadeInUpAnimation ()),
			};

			await Task.WhenAll(tasks);
			await Task.Delay(500);

			FadeInBox.ClearTransforms();
			FadeOutBox.ClearTransforms();

			FadeInDownBox.ClearTransforms();
			FadeInLeftBox.ClearTransforms();
			FadeInRightBox.ClearTransforms();
			FadeInUpBox.ClearTransforms();
		}

	}
}
