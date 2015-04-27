using Brain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAnimations
{
	public partial class BounceAnimationsPage : ContentPage
	{
		public BounceAnimationsPage()
		{
			InitializeComponent();
		}

		private bool animating;
		public async void BeginButton_OnClicked(object sender, EventArgs args)
		{
			if (animating) return;
			animating = true;

			uint duration = 1000;

			var tasks = new List<Task> {
				BounceInBox.Animate(new BounceInAnimation () { DurationMS = duration }),
				BounceOutBox.Animate(new BounceOutAnimation (){ DurationMS = duration }),

				BounceInDownBox.Animate(new BounceInDownAnimation (){ DurationMS = duration }),
				BounceInLeftBox.Animate(new BounceInLeftAnimation (){ DurationMS = duration }),
				BounceInRightBox.Animate(new BounceInRightAnimation (){ DurationMS = duration }),
				BounceInUpBox.Animate(new BounceInUpAnimation (){ DurationMS = duration }),

				CircleInTopLeftBox.Animate(new CircleInAnimation { FromDirection = CircleDirection.TopLeft, DurationMS = duration}),
				CircleInTopRightBox.Animate(new CircleInAnimation { FromDirection = CircleDirection.TopRight, DurationMS = duration }),
				CircleInBottomLeftBox.Animate(new CircleInAnimation { FromDirection = CircleDirection.BottomLeft, DurationMS = duration }),
				CircleInBottomRightBox.Animate(new CircleInAnimation { FromDirection = CircleDirection.BottomRight, DurationMS = duration }),
			};

			await Task.WhenAll(tasks);
			await Task.Delay(500);

			BounceInBox.ClearTransforms();
			BounceOutBox.ClearTransforms();

			BounceInDownBox.ClearTransforms();
			BounceInLeftBox.ClearTransforms();
			BounceInRightBox.ClearTransforms();
			BounceInUpBox.ClearTransforms();

			animating = false;
		}

	}
}
