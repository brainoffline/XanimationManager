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

			var tasks = new List<Task> {
				BounceInBox.Animate(new BounceInAnimation ()),
				BounceOutBox.Animate(new BounceOutAnimation ()),

				BounceInDownBox.Animate(new BounceInDownAnimation ()),
				BounceInLeftBox.Animate(new BounceInLeftAnimation ()),
				BounceInRightBox.Animate(new BounceInRightAnimation ()),
				BounceInUpBox.Animate(new BounceInUpAnimation ()),

				CircleInTopLeftBox.Animate(new CircleInAnimation { FromDirection = CircleDirection.TopLeft }),
				CircleInTopRightBox.Animate(new CircleInAnimation { FromDirection = CircleDirection.TopRight }),
				CircleInBottomLeftBox.Animate(new CircleInAnimation { FromDirection = CircleDirection.BottomLeft }),
				CircleInBottomRightBox.Animate(new CircleInAnimation { FromDirection = CircleDirection.BottomRight }),
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
