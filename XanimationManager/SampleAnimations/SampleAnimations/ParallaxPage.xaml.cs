using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Brain;
using Xamarin.Forms;

namespace SampleAnimations
{
	public partial class ParallaxPage : ContentPage
	{
		private Parallax _parallax;

		public ParallaxPage()
		{
			InitializeComponent();

			_parallax = new Parallax();

			_parallax.AddLayer(Box1, 1, UpdateBox);
			_parallax.AddLayer(Box2, 1.25, UpdateBox);
			_parallax.AddLayer(Box3, 1.5, UpdateBox);
			_parallax.AddLayer(Box4, 1.75, UpdateBox);
			_parallax.AddLayer(Box5, 2, UpdateBox);
		}

		private void UpdateBox(VisualElement element, double f)
		{
			element.TranslationX = f % (Bounds.Width - Box1.Width);
		}


		public void StepButton_OnClicked(object sender, EventArgs args)
		{
			_parallax.MoveBy((Bounds.Width - Box1.Width)/4, 1000, Easings.CubicOut);
		}

		public void AutoButton_OnClicked(object sender, EventArgs args)
		{
			_parallax.Auto((Bounds.Width - Box1.Width), 1000);
		}
	}
}
