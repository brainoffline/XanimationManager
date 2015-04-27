using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brain
{
	[DebuggerDisplay("Parallax Value = {Value}")]
	public class Parallax : BindableObject, IAnimatable
	{
		private class Layer
		{
			public VisualElement Element { get; set; }
			public double Factor { get; set; }
			public Action<VisualElement, double> UpdateAction { get; set; }
			public Action<VisualElement> FinishedAction { get; set; }
		}

		private readonly List<Layer> _layers = new List<Layer>();

		public static readonly BindableProperty ValueProperty = 
			BindableProperty.Create(
				"Value", 
				typeof(double), 
				typeof(Parallax), 
				(object)(double)0, 
				BindingMode.OneWay, 
				null,
				(bindable, oldValue, newValue) => { });

		public double Value
		{
			get { return (double)GetValue(ValueProperty); }
			set
			{
				SetValue(ValueProperty, value);
				RaiseValueChanged();
			}
		}

		public event EventHandler ValueChanged;

		protected virtual void RaiseValueChanged()
		{
			ValueChanged?.Invoke(this, EventArgs.Empty);
		}

		public void AddLayer(
			VisualElement element, 
			double factor, 
			Action<VisualElement, double> updateAction, 
			Action<VisualElement> finishedAction = null)
		{
			_layers.Add( new Layer
			{
				Element = element,
				Factor = factor,
				UpdateAction = updateAction,
				FinishedAction = finishedAction
			});
		}

		private void UpdateLayers(double value)
		{
			try
			{
				Value = value;
				foreach (var layer in _layers)
					layer.UpdateAction(layer.Element, value * layer.Factor);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				throw;
			}
		}

		private void RaiseFinished()
		{
			try
			{
				foreach (var layer in _layers)
				{
					layer.FinishedAction?.Invoke(layer.Element);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				throw;
			}
		}

		public Task<bool> MoveBy(double value, uint ms, Easing easing = null)
		{
			Stop();

			var tcs = new TaskCompletionSource<bool>();

			var animation = new Animation();
			animation.WithConcurrent(UpdateLayers, Value, Value + value, easing);
			animation.Commit(this, "", 16U, ms, easing, (d, cancelled) =>
			{
				RaiseFinished();
				tcs.SetResult(!cancelled);
			});

			return tcs.Task;
		}

		public void Auto(double value, uint ms)
		{
			Stop();

			var animation = new Animation();
			animation.WithConcurrent(UpdateLayers, Value, Value + value);
			animation.Commit(this, "", 16U, ms, null,
				(d, cancelled) =>
				{
					RaiseFinished();
					if (!cancelled)
						Auto(value, ms);
				});
		}

		public void Stop()
		{
			this.AbortAnimation("");
		}

		public void BatchBegin() { }
		public void BatchCommit() { }
	}
}
