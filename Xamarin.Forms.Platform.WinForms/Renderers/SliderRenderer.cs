﻿using System;
using System.ComponentModel;

namespace Xamarin.Forms.Platform.WinForms
{
	public class SliderRenderer : ViewRenderer<Slider, System.Windows.Forms.TrackBar>
	{
		/*-----------------------------------------------------------------*/
		#region Event Handler

		protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				Control.ValueChanged += Platform.BlockRenter((s, e2) => Element.Value = Control.Value);
				Control.TickFrequency = 0;

				UpdateValue();
				UpdateMinimum();
				UpdateMaximum();
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == Slider.ValueProperty.PropertyName)
				UpdateValue();
			else if (e.PropertyName == Slider.MinimumProperty.PropertyName)
				UpdateMinimum();
			else if (e.PropertyName == Slider.MaximumProperty.PropertyName)
				UpdateMaximum();
			base.OnElementPropertyChanged(sender, e);
		}


		#endregion

		/*-----------------------------------------------------------------*/
		#region Internals

		void UpdateValue()
		{
			if (Control != null && Element != null)
			{
				Control.Value = (int)Element.Value;
			}
		}

		void UpdateMinimum()
		{
			if (Control != null && Element != null)
			{
				Control.Minimum = (int)Element.Minimum;
			}
		}

		void UpdateMaximum()
		{
			if (Control != null && Element != null)
			{
				Control.Maximum = (int)Element.Maximum;
			}
		}

		#endregion
	}
}