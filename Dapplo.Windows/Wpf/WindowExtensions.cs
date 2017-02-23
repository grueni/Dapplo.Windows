﻿using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using Dapplo.Windows.Desktop;

namespace Dapplo.Windows.Wpf
{
	/// <summary>
	/// Extensions for the WPF Window class
	/// </summary>
	public static class WindowExtensions
	{
		/// <summary>
		/// Handle DPI changes for the specified Window
		/// </summary>
		/// <param name="window">Window</param>
		/// <returns>DpiHandler</returns>
		public static DpiHandler HandleDpiChanges(this Window window)
		{
			var dpiHandler = new DpiHandler();
			var hwndSource = (HwndSource)PresentationSource.FromVisual(window);
			if (hwndSource == null)
			{
				throw new NotSupportedException("No HwndSource available?");
			}
			hwndSource.AddHook(dpiHandler.HandleMessages);
			// Add the layout transform action
			dpiHandler.OnDpiChangedAction = (dpi, scaleFactor) => window.UpdateLayoutTransform(scaleFactor);
			return dpiHandler;
		}

		/// <summary>
		/// This can be used to change the scaling of the FrameworkElement
		/// </summary>
		/// <param name="frameworkElement">FrameworkElement</param>
		/// <param name="scaleFactor">double with the factor (1.0 = 100% = 96 dpi)</param>
		public static void UpdateLayoutTransform(this FrameworkElement frameworkElement, double scaleFactor)
		{
			// Adjust the rendering graphics and text size by applying the scale transform to the top level visual node of the Window
			var child = VisualTreeHelper.GetChild(frameworkElement, 0);
			if (Math.Abs(scaleFactor - 1.0) < 3 * double.Epsilon)
			{
				var scaleTransform = new ScaleTransform(scaleFactor, scaleFactor);
				child.SetValue(FrameworkElement.LayoutTransformProperty, scaleTransform);
			}
			else
			{
				child.SetValue(FrameworkElement.LayoutTransformProperty, null);
			}
		}
	}
}