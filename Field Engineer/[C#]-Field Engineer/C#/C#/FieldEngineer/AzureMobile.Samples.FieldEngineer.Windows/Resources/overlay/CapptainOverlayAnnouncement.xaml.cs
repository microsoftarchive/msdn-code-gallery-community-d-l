/*
Copyright 2014 Capptain
   
  Licensed under the CAPPTAIN SDK LICENSE (the "License");
  you may not use this file except in compliance with the License.
  You may obtain a copy of the License at
   
    https://app.capptain.com/#tos
   
  This file is supplied "as-is." You bear the risk of using it.
  Capptain gives no express or implied warranties, guarantees or conditions.
  You may have additional consumer rights under your local laws which this agreement cannot change.
  To the extent permitted under your local laws, Capptain excludes the implied warranties of merchantability,
  fitness for a particular purpose and non-infringement.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Capptain.Overlay
{
  /// <summary>
  /// Capptain grid for overlay insertion of announcement
  /// </summary>
  public sealed partial class CapptainOverlayAnnoucement : Grid
  {
    private static CapptainOverlayAnnoucement instance;

    /// <summary>
    /// Singleton instance
    /// </summary>
    public static CapptainOverlayAnnoucement Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new CapptainOverlayAnnoucement();
        }
        return instance;
      }
    }

    /// <summary>
    /// Use to create the overlay
    /// </summary>
    private CapptainOverlayAnnoucement()
    {
      this.InitializeComponent();
    }

    /// <summary>
    /// Allow webview script to notify system
    /// </summary>
    /// <param name="sender">Event originator</param>
    /// <param name="e">Notify Event argument</param>
    private void scriptEvent(object sender, NotifyEventArgs e)
    {
    }
    
    /// <summary>
    /// Attach the SizeChanged handler
    /// </summary>
    public void SetHandler()
    {
      Window.Current.SizeChanged += DisplayProperties_OrientationChanged;
    }

    /// <summary>
    /// Detach the SizeChanged handler
    /// </summary>
    public void UnsetHandler()
    {
      Window.Current.SizeChanged -= DisplayProperties_OrientationChanged;
    }

    /// <summary>
    /// Set your webview elements to the correct size external use
    /// </summary>
    public void SetWebView()
    {
      this.capptain_announcement_content.Width = Window.Current.Bounds.Width;
      this.capptain_announcement_content.Height = Window.Current.Bounds.Height;
    }

    /// <summary>
    /// Set your webview elements to the correct size internal use
    /// </summary>
    /// <param name="width">The width of your current display</param>
    /// <param name="height">The height of your current display</param>
    private void SetWebView(double width, double height)
    {
      this.capptain_announcement_content.Width = width;
      this.capptain_announcement_content.Height = height;
    }

    /// <summary>
    /// Handler that takes the Windows.Current.SizeChanged, it indicates that webview have to be resized
    /// </summary>
    /// <param name="sender">Event originator</param>
    /// <param name="e">Window Size Changed Event argument</param>
    private void DisplayProperties_OrientationChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
    {
      double width = e.Size.Width;
      double height = e.Size.Height;
      SetWebView(width, height);
    }
  }
}
