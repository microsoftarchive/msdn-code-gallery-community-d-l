# Dynamic Image Button in WPF
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- custom controls
- Button
- Image Button
## Updated
- 09/11/2011
## Description

<p><em>&nbsp;</em></p>
<p><em><img src="42380-untitled.png" alt="" width="655" height="350"></em></p>
<p><em>&nbsp;</em>&nbsp;</p>
<h1>Introduction</h1>
<p>A sample in WPF to design an Image Button, like the Mac system DashBorad button, when the mouse over it, it can be scaled.</p>
<h1>Building the Sample</h1>
<p>Build it in Visual Studio 2010, WPF 4 project. Please rewrite your style for this button in the Theme/Generic.xaml, we can add new styles and features.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>A sample in WPF to design an Image Button, like the Mac system DashBorad button, when the mouse over it, it can be scaled, and this button has its inverted image (use the VisualImage to copy the original content). When we click it, a visual will show over
 the button：</p>
<p><img src="42381-untitled1.png" alt="" width="474" height="233"></p>
<p>I paste the code here:</p>
<p>XAML of the button style:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">  &lt;Style TargetType=&quot;{x:Type local:DynamicImageButton}&quot;&gt;
    &lt;Setter Property=&quot;Foreground&quot; Value=&quot;Black&quot;/&gt;
    &lt;Setter Property=&quot;Focusable&quot; Value=&quot;True&quot;/&gt;
    &lt;Setter Property=&quot;Template&quot;&gt;
      &lt;Setter.Value&gt;
        &lt;ControlTemplate TargetType=&quot;{x:Type local:DynamicImageButton}&quot;&gt;
          &lt;Grid&gt;
            &lt;Grid.RowDefinitions&gt;
              &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
              &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
            &lt;/Grid.RowDefinitions&gt;
            &lt;Grid x:Name=&quot;ICON_IMG&quot;&gt;
              &lt;Grid.ColumnDefinitions&gt;
                &lt;ColumnDefinition Width=&quot;Auto&quot;/&gt;
                &lt;ColumnDefinition Width=&quot;*&quot;/&gt;
              &lt;/Grid.ColumnDefinitions&gt;

              &lt;Grid Grid.ColumnSpan=&quot;2&quot; Background=&quot;Transparent&quot; x:Name=&quot;PART_BORDER&quot; Opacity=&quot;0&quot;&gt;
                &lt;Grid.RowDefinitions&gt;
                  &lt;RowDefinition Height=&quot;*&quot;/&gt;
                  &lt;RowDefinition Height=&quot;*&quot;/&gt;
                &lt;/Grid.RowDefinitions&gt;
                &lt;Rectangle RadiusX=&quot;10&quot; RadiusY=&quot;10&quot; Grid.RowSpan=&quot;2&quot;&gt;
                  &lt;Rectangle.Fill&gt;
                    &lt;LinearGradientBrush StartPoint=&quot;0.5,0&quot; EndPoint=&quot;0.5,1&quot;&gt;
                      &lt;LinearGradientBrush.GradientStops&gt;
                        &lt;GradientStop Color=&quot;#FF000000&quot; Offset=&quot;0&quot;/&gt;
                        &lt;GradientStop Color=&quot;#FF000000&quot; Offset=&quot;1&quot;/&gt;
                      &lt;/LinearGradientBrush.GradientStops&gt;
                    &lt;/LinearGradientBrush&gt;
                  &lt;/Rectangle.Fill&gt;
                &lt;/Rectangle&gt;
                &lt;Rectangle Grid.Row=&quot;0&quot; RadiusX=&quot;8&quot; RadiusY=&quot;8&quot; StrokeThickness=&quot;0&quot; Margin=&quot;1&quot;&gt;
                  &lt;Rectangle.Fill&gt;
                    &lt;LinearGradientBrush StartPoint=&quot;0.5,0&quot; EndPoint=&quot;0.5,1&quot;&gt;
                      &lt;LinearGradientBrush.GradientStops&gt;
                        &lt;GradientStop Color=&quot;#FFFFFFFF&quot; Offset=&quot;0&quot;/&gt;
                        &lt;GradientStop Color=&quot;#00FFFFFF&quot; Offset=&quot;0.9&quot;/&gt;
                      &lt;/LinearGradientBrush.GradientStops&gt;
                    &lt;/LinearGradientBrush&gt;
                  &lt;/Rectangle.Fill&gt;
                &lt;/Rectangle&gt;
                &lt;Rectangle Grid.Row=&quot;1&quot; RadiusX=&quot;8&quot; RadiusY=&quot;8&quot; StrokeThickness=&quot;0&quot; Margin=&quot;1&quot; Opacity=&quot;1&quot;&gt;
                  &lt;Rectangle.Fill&gt;
                    &lt;LinearGradientBrush StartPoint=&quot;0.5,0&quot; EndPoint=&quot;0.5,1&quot;&gt;
                      &lt;LinearGradientBrush.GradientStops&gt;
                        &lt;GradientStop Color=&quot;#00FFFFFF&quot; Offset=&quot;0.1&quot;/&gt;
                        &lt;GradientStop Color=&quot;#FFFFFFFF&quot; Offset=&quot;1&quot;/&gt;
                      &lt;/LinearGradientBrush.GradientStops&gt;
                    &lt;/LinearGradientBrush&gt;
                  &lt;/Rectangle.Fill&gt;
                &lt;/Rectangle&gt;
              &lt;/Grid&gt;

              &lt;Image Source=&quot;{TemplateBinding IconImage}&quot; Width=&quot;64&quot; Height=&quot;64&quot; Margin=&quot;5&quot;/&gt;
              &lt;ContentPresenter Grid.Column=&quot;1&quot; HorizontalAlignment=&quot;Stretch&quot; VerticalAlignment=&quot;Center&quot; Margin=&quot;5&quot;/&gt;

              &lt;Grid.LayoutTransform&gt;
                &lt;ScaleTransform/&gt;
              &lt;/Grid.LayoutTransform&gt;
            &lt;/Grid&gt;
            
            &lt;Rectangle x:Name=&quot;TOP_IMG&quot; RenderTransformOrigin=&quot;0.5,0.5&quot; Opacity=&quot;0&quot;&gt;
              &lt;Rectangle.Fill&gt;
                &lt;VisualBrush Visual=&quot;{Binding ElementName=ICON_IMG}&quot;/&gt;
              &lt;/Rectangle.Fill&gt;
              &lt;Rectangle.RenderTransform&gt;
                &lt;ScaleTransform/&gt;
              &lt;/Rectangle.RenderTransform&gt;
            &lt;/Rectangle&gt;

            &lt;Rectangle Grid.Row=&quot;1&quot; Height=&quot;40&quot; Margin=&quot;0,2,0,0&quot;&gt;
              &lt;Rectangle.LayoutTransform&gt;
                &lt;ScaleTransform ScaleY=&quot;-1&quot;/&gt;
              &lt;/Rectangle.LayoutTransform&gt;
              &lt;Rectangle.Fill&gt;
                &lt;VisualBrush Visual=&quot;{Binding ElementName=ICON_IMG}&quot;/&gt;
              &lt;/Rectangle.Fill&gt;
              &lt;Rectangle.OpacityMask&gt;
                &lt;LinearGradientBrush StartPoint=&quot;0.5,0&quot; EndPoint=&quot;0.5,1&quot;&gt;
                  &lt;GradientStop Color=&quot;Transparent&quot; Offset=&quot;0.4&quot;/&gt;
                  &lt;GradientStop Color=&quot;White&quot; Offset=&quot;1&quot;/&gt;
                &lt;/LinearGradientBrush&gt;
              &lt;/Rectangle.OpacityMask&gt;
            &lt;/Rectangle&gt;
          &lt;/Grid&gt;
          &lt;ControlTemplate.Triggers&gt;
            &lt;Trigger Property=&quot;ButtonBase.IsMouseOver&quot; Value=&quot;True&quot;&gt;
              &lt;Setter TargetName=&quot;PART_BORDER&quot; Property=&quot;Opacity&quot; Value=&quot;1&quot;/&gt;
              &lt;Setter Property=&quot;Foreground&quot; Value=&quot;White&quot;/&gt;
              &lt;Trigger.EnterActions&gt;
                &lt;BeginStoryboard&gt;
                  &lt;Storyboard&gt;
                    &lt;DoubleAnimation Storyboard.TargetName=&quot;ICON_IMG&quot; 
                                     Storyboard.TargetProperty=&quot;LayoutTransform.ScaleX&quot; 
                                     To=&quot;1.5&quot;
                                     Duration=&quot;0:0:0.3&quot;/&gt;

                    &lt;DoubleAnimation Storyboard.TargetName=&quot;ICON_IMG&quot; 
                                     Storyboard.TargetProperty=&quot;LayoutTransform.ScaleY&quot; 
                                     To=&quot;1.5&quot;
                                     Duration=&quot;0:0:0.3&quot;/&gt;
                  &lt;/Storyboard&gt;
                &lt;/BeginStoryboard&gt;
              &lt;/Trigger.EnterActions&gt;
              &lt;Trigger.ExitActions&gt;
                &lt;BeginStoryboard&gt;
                  &lt;Storyboard&gt;
                    &lt;DoubleAnimation Storyboard.TargetName=&quot;ICON_IMG&quot; 
                                     Storyboard.TargetProperty=&quot;LayoutTransform.ScaleX&quot; 
                                     To=&quot;1&quot;
                                     Duration=&quot;0:0:0.3&quot;/&gt;

                    &lt;DoubleAnimation Storyboard.TargetName=&quot;ICON_IMG&quot; 
                                     Storyboard.TargetProperty=&quot;LayoutTransform.ScaleY&quot; 
                                     To=&quot;1&quot;
                                     Duration=&quot;0:0:0.3&quot;/&gt;
                  &lt;/Storyboard&gt;
                &lt;/BeginStoryboard&gt;
              &lt;/Trigger.ExitActions&gt;
            &lt;/Trigger&gt;

            &lt;Trigger Property=&quot;IsFocused&quot; Value=&quot;True&quot;&gt;
              &lt;Setter TargetName=&quot;PART_BORDER&quot; Property=&quot;Opacity&quot; Value=&quot;1&quot;/&gt;
              &lt;Setter Property=&quot;Foreground&quot; Value=&quot;White&quot;/&gt;
            &lt;/Trigger&gt;

            &lt;EventTrigger RoutedEvent=&quot;ButtonBase.PreviewMouseDown&quot;&gt;
              &lt;BeginStoryboard&gt;
                &lt;Storyboard&gt;
                  &lt;DoubleAnimation Storyboard.TargetName=&quot;TOP_IMG&quot;
                                   Storyboard.TargetProperty=&quot;Opacity&quot;
                                   From=&quot;1&quot; To=&quot;0&quot; Duration=&quot;0:0:0.5&quot;/&gt;
                  &lt;DoubleAnimation Storyboard.TargetName=&quot;TOP_IMG&quot;
                                   Storyboard.TargetProperty=&quot;RenderTransform.ScaleX&quot;
                                   From=&quot;1&quot; To=&quot;3&quot; FillBehavior=&quot;Stop&quot; Duration=&quot;0:0:0.5&quot;/&gt;
                  &lt;DoubleAnimation Storyboard.TargetName=&quot;TOP_IMG&quot;
                                   Storyboard.TargetProperty=&quot;RenderTransform.ScaleY&quot;
                                   From=&quot;1&quot; To=&quot;3&quot; FillBehavior=&quot;Stop&quot; Duration=&quot;0:0:0.5&quot;/&gt;
                &lt;/Storyboard&gt;
              &lt;/BeginStoryboard&gt;
            &lt;/EventTrigger&gt;
          &lt;/ControlTemplate.Triggers&gt;
        &lt;/ControlTemplate&gt;
      &lt;/Setter.Value&gt;
    &lt;/Setter&gt;
  &lt;/Style&gt;</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&lt;Style&nbsp;TargetType=<span class="js__string">&quot;{x:Type&nbsp;local:DynamicImageButton}&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;Foreground&quot;</span>&nbsp;Value=<span class="js__string">&quot;Black&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;Focusable&quot;</span>&nbsp;Value=<span class="js__string">&quot;True&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;Template&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter.Value&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ControlTemplate&nbsp;TargetType=<span class="js__string">&quot;{x:Type&nbsp;local:DynamicImageButton}&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;Height=<span class="js__string">&quot;Auto&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;Height=<span class="js__string">&quot;Auto&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;x:Name=<span class="js__string">&quot;ICON_IMG&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.ColumnDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ColumnDefinition&nbsp;Width=<span class="js__string">&quot;Auto&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ColumnDefinition&nbsp;Width=<span class="js__string">&quot;*&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.ColumnDefinitions&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;Grid.ColumnSpan=<span class="js__string">&quot;2&quot;</span>&nbsp;Background=<span class="js__string">&quot;Transparent&quot;</span>&nbsp;x:Name=<span class="js__string">&quot;PART_BORDER&quot;</span>&nbsp;Opacity=<span class="js__string">&quot;0&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;Height=<span class="js__string">&quot;*&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;Height=<span class="js__string">&quot;*&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle&nbsp;RadiusX=<span class="js__string">&quot;10&quot;</span>&nbsp;RadiusY=<span class="js__string">&quot;10&quot;</span>&nbsp;Grid.RowSpan=<span class="js__string">&quot;2&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle.Fill&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;LinearGradientBrush&nbsp;StartPoint=<span class="js__string">&quot;0.5,0&quot;</span>&nbsp;EndPoint=<span class="js__string">&quot;0.5,1&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;LinearGradientBrush.GradientStops&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GradientStop&nbsp;Color=<span class="js__string">&quot;#FF000000&quot;</span>&nbsp;Offset=<span class="js__string">&quot;0&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GradientStop&nbsp;Color=<span class="js__string">&quot;#FF000000&quot;</span>&nbsp;Offset=<span class="js__string">&quot;1&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/LinearGradientBrush.GradientStops&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/LinearGradientBrush&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle.Fill&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle&nbsp;Grid.Row=<span class="js__string">&quot;0&quot;</span>&nbsp;RadiusX=<span class="js__string">&quot;8&quot;</span>&nbsp;RadiusY=<span class="js__string">&quot;8&quot;</span>&nbsp;StrokeThickness=<span class="js__string">&quot;0&quot;</span>&nbsp;Margin=<span class="js__string">&quot;1&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle.Fill&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;LinearGradientBrush&nbsp;StartPoint=<span class="js__string">&quot;0.5,0&quot;</span>&nbsp;EndPoint=<span class="js__string">&quot;0.5,1&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;LinearGradientBrush.GradientStops&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GradientStop&nbsp;Color=<span class="js__string">&quot;#FFFFFFFF&quot;</span>&nbsp;Offset=<span class="js__string">&quot;0&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GradientStop&nbsp;Color=<span class="js__string">&quot;#00FFFFFF&quot;</span>&nbsp;Offset=<span class="js__string">&quot;0.9&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/LinearGradientBrush.GradientStops&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/LinearGradientBrush&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle.Fill&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle&nbsp;Grid.Row=<span class="js__string">&quot;1&quot;</span>&nbsp;RadiusX=<span class="js__string">&quot;8&quot;</span>&nbsp;RadiusY=<span class="js__string">&quot;8&quot;</span>&nbsp;StrokeThickness=<span class="js__string">&quot;0&quot;</span>&nbsp;Margin=<span class="js__string">&quot;1&quot;</span>&nbsp;Opacity=<span class="js__string">&quot;1&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle.Fill&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;LinearGradientBrush&nbsp;StartPoint=<span class="js__string">&quot;0.5,0&quot;</span>&nbsp;EndPoint=<span class="js__string">&quot;0.5,1&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;LinearGradientBrush.GradientStops&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GradientStop&nbsp;Color=<span class="js__string">&quot;#00FFFFFF&quot;</span>&nbsp;Offset=<span class="js__string">&quot;0.1&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GradientStop&nbsp;Color=<span class="js__string">&quot;#FFFFFFFF&quot;</span>&nbsp;Offset=<span class="js__string">&quot;1&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/LinearGradientBrush.GradientStops&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/LinearGradientBrush&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle.Fill&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Image&nbsp;Source=<span class="js__string">&quot;{TemplateBinding&nbsp;IconImage}&quot;</span>&nbsp;Width=<span class="js__string">&quot;64&quot;</span>&nbsp;Height=<span class="js__string">&quot;64&quot;</span>&nbsp;Margin=<span class="js__string">&quot;5&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ContentPresenter&nbsp;Grid.Column=<span class="js__string">&quot;1&quot;</span>&nbsp;HorizontalAlignment=<span class="js__string">&quot;Stretch&quot;</span>&nbsp;VerticalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;Margin=<span class="js__string">&quot;5&quot;</span>/&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.LayoutTransform&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ScaleTransform/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.LayoutTransform&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle&nbsp;x:Name=<span class="js__string">&quot;TOP_IMG&quot;</span>&nbsp;RenderTransformOrigin=<span class="js__string">&quot;0.5,0.5&quot;</span>&nbsp;Opacity=<span class="js__string">&quot;0&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle.Fill&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;VisualBrush&nbsp;Visual=<span class="js__string">&quot;{Binding&nbsp;ElementName=ICON_IMG}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle.Fill&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle.RenderTransform&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ScaleTransform/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle.RenderTransform&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle&nbsp;Grid.Row=<span class="js__string">&quot;1&quot;</span>&nbsp;Height=<span class="js__string">&quot;40&quot;</span>&nbsp;Margin=<span class="js__string">&quot;0,2,0,0&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle.LayoutTransform&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ScaleTransform&nbsp;ScaleY=<span class="js__string">&quot;-1&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle.LayoutTransform&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle.Fill&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;VisualBrush&nbsp;Visual=<span class="js__string">&quot;{Binding&nbsp;ElementName=ICON_IMG}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle.Fill&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle.OpacityMask&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;LinearGradientBrush&nbsp;StartPoint=<span class="js__string">&quot;0.5,0&quot;</span>&nbsp;EndPoint=<span class="js__string">&quot;0.5,1&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GradientStop&nbsp;Color=<span class="js__string">&quot;Transparent&quot;</span>&nbsp;Offset=<span class="js__string">&quot;0.4&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GradientStop&nbsp;Color=<span class="js__string">&quot;White&quot;</span>&nbsp;Offset=<span class="js__string">&quot;1&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/LinearGradientBrush&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle.OpacityMask&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Rectangle&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ControlTemplate.Triggers&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger&nbsp;Property=<span class="js__string">&quot;ButtonBase.IsMouseOver&quot;</span>&nbsp;Value=<span class="js__string">&quot;True&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;TargetName=<span class="js__string">&quot;PART_BORDER&quot;</span>&nbsp;Property=<span class="js__string">&quot;Opacity&quot;</span>&nbsp;Value=<span class="js__string">&quot;1&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;Foreground&quot;</span>&nbsp;Value=<span class="js__string">&quot;White&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger.EnterActions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;BeginStoryboard&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Storyboard&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DoubleAnimation&nbsp;Storyboard.TargetName=<span class="js__string">&quot;ICON_IMG&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.TargetProperty=<span class="js__string">&quot;LayoutTransform.ScaleX&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To=<span class="js__string">&quot;1.5&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Duration=<span class="js__string">&quot;0:0:0.3&quot;</span>/&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DoubleAnimation&nbsp;Storyboard.TargetName=<span class="js__string">&quot;ICON_IMG&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.TargetProperty=<span class="js__string">&quot;LayoutTransform.ScaleY&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To=<span class="js__string">&quot;1.5&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Duration=<span class="js__string">&quot;0:0:0.3&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Storyboard&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/BeginStoryboard&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger.EnterActions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger.ExitActions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;BeginStoryboard&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Storyboard&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DoubleAnimation&nbsp;Storyboard.TargetName=<span class="js__string">&quot;ICON_IMG&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.TargetProperty=<span class="js__string">&quot;LayoutTransform.ScaleX&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To=<span class="js__string">&quot;1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Duration=<span class="js__string">&quot;0:0:0.3&quot;</span>/&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DoubleAnimation&nbsp;Storyboard.TargetName=<span class="js__string">&quot;ICON_IMG&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.TargetProperty=<span class="js__string">&quot;LayoutTransform.ScaleY&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To=<span class="js__string">&quot;1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Duration=<span class="js__string">&quot;0:0:0.3&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Storyboard&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/BeginStoryboard&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger.ExitActions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger&nbsp;Property=<span class="js__string">&quot;IsFocused&quot;</span>&nbsp;Value=<span class="js__string">&quot;True&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;TargetName=<span class="js__string">&quot;PART_BORDER&quot;</span>&nbsp;Property=<span class="js__string">&quot;Opacity&quot;</span>&nbsp;Value=<span class="js__string">&quot;1&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;Foreground&quot;</span>&nbsp;Value=<span class="js__string">&quot;White&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;EventTrigger&nbsp;RoutedEvent=<span class="js__string">&quot;ButtonBase.PreviewMouseDown&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;BeginStoryboard&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Storyboard&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DoubleAnimation&nbsp;Storyboard.TargetName=<span class="js__string">&quot;TOP_IMG&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.TargetProperty=<span class="js__string">&quot;Opacity&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From=<span class="js__string">&quot;1&quot;</span>&nbsp;To=<span class="js__string">&quot;0&quot;</span>&nbsp;Duration=<span class="js__string">&quot;0:0:0.5&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DoubleAnimation&nbsp;Storyboard.TargetName=<span class="js__string">&quot;TOP_IMG&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.TargetProperty=<span class="js__string">&quot;RenderTransform.ScaleX&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From=<span class="js__string">&quot;1&quot;</span>&nbsp;To=<span class="js__string">&quot;3&quot;</span>&nbsp;FillBehavior=<span class="js__string">&quot;Stop&quot;</span>&nbsp;Duration=<span class="js__string">&quot;0:0:0.5&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DoubleAnimation&nbsp;Storyboard.TargetName=<span class="js__string">&quot;TOP_IMG&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Storyboard.TargetProperty=<span class="js__string">&quot;RenderTransform.ScaleY&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From=<span class="js__string">&quot;1&quot;</span>&nbsp;To=<span class="js__string">&quot;3&quot;</span>&nbsp;FillBehavior=<span class="js__string">&quot;Stop&quot;</span>&nbsp;Duration=<span class="js__string">&quot;0:0:0.5&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Storyboard&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/BeginStoryboard&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/EventTrigger&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ControlTemplate.Triggers&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ControlTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Setter.Value&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Setter&gt;&nbsp;
&nbsp;&nbsp;&lt;/Style&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>Code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">  public class DynamicImageButton : ButtonBase
  {
    static DynamicImageButton()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(DynamicImageButton), new FrameworkPropertyMetadata(typeof(DynamicImageButton)));
    }

    public string IconImageUri
    {
      get { return (string)GetValue(IconImageUriProperty); }
      set
      {
        SetValue(IconImageUriProperty, value);
      }
    }
    public static readonly DependencyProperty IconImageUriProperty =
        DependencyProperty.Register(&quot;IconImageUri&quot;, typeof(string), typeof(DynamicImageButton), new UIPropertyMetadata(string.Empty,
          (o, e) =&gt;
          {
            try
            {
              Uri uriSource = new Uri((string)e.NewValue, UriKind.RelativeOrAbsolute);
              if (uriSource != null)
              {
                DynamicImageButton button = o as DynamicImageButton;
                BitmapImage img = new BitmapImage(uriSource);
                button.SetValue(IconImageProperty, img);
              }
            }
            catch (Exception ex)
            {
              throw ex;
            }
          }));

    public BitmapImage IconImage
    {
      get { return (BitmapImage)GetValue(IconImageProperty); }
      set { SetValue(IconImageProperty, value); }
    }
    public static readonly DependencyProperty IconImageProperty =
        DependencyProperty.Register(&quot;IconImage&quot;, typeof(BitmapImage), typeof(DynamicImageButton), new UIPropertyMetadata(null));
  }</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;public&nbsp;class&nbsp;DynamicImageButton&nbsp;:&nbsp;ButtonBase&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;static&nbsp;DynamicImageButton()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DefaultStyleKeyProperty.OverrideMetadata(<span class="js__operator">typeof</span>(DynamicImageButton),&nbsp;<span class="js__operator">new</span>&nbsp;FrameworkPropertyMetadata(<span class="js__operator">typeof</span>(DynamicImageButton)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;IconImageUri&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;(string)GetValue(IconImageUriProperty);&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetValue(IconImageUriProperty,&nbsp;value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;readonly&nbsp;DependencyProperty&nbsp;IconImageUriProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(<span class="js__string">&quot;IconImageUri&quot;</span>,&nbsp;<span class="js__operator">typeof</span>(string),&nbsp;<span class="js__operator">typeof</span>(DynamicImageButton),&nbsp;<span class="js__operator">new</span>&nbsp;UIPropertyMetadata(string.Empty,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(o,&nbsp;e)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;uriSource&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Uri((string)e.NewValue,&nbsp;UriKind.RelativeOrAbsolute);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(uriSource&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DynamicImageButton&nbsp;button&nbsp;=&nbsp;o&nbsp;as&nbsp;DynamicImageButton;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BitmapImage&nbsp;img&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;BitmapImage(uriSource);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button.SetValue(IconImageProperty,&nbsp;img);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>&nbsp;ex;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;BitmapImage&nbsp;IconImage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;(BitmapImage)GetValue(IconImageProperty);&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set&nbsp;<span class="js__brace">{</span>&nbsp;SetValue(IconImageProperty,&nbsp;value);&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;readonly&nbsp;DependencyProperty&nbsp;IconImageProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(<span class="js__string">&quot;IconImage&quot;</span>,&nbsp;<span class="js__operator">typeof</span>(BitmapImage),&nbsp;<span class="js__operator">typeof</span>(DynamicImageButton),&nbsp;<span class="js__operator">new</span>&nbsp;UIPropertyMetadata(null));&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">Use it in a sample window:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<pre lang="x-c#" style="font-family:NSimSun; background:white; color:black; font-size:13px"><span style="color:#a31515">&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:blue">&lt;</span><span style="color:#a31515">local</span><span style="color:blue">:</span><span style="color:#a31515">DynamicImageButton</span><span style="color:red">&nbsp;IconImageUri</span><span style="color:blue">=</span><span style="color:blue">&quot;icons/CHAT.png&quot;</span><span style="color:red">&nbsp;Content</span><span style="color:blue">=</span><span style="color:blue">&quot;Chat&quot;</span><span style="color:blue">/&gt;</span>
<span style="color:#a31515">&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:blue">&lt;</span><span style="color:#a31515">local</span><span style="color:blue">:</span><span style="color:#a31515">DynamicImageButton</span><span style="color:red">&nbsp;Content</span><span style="color:blue">=</span><span style="color:blue">&quot;Help&quot;</span><span style="color:blue">&gt;</span>
<span style="color:#a31515">&nbsp;</span></pre>
<pre lang="x-c#" style="font-family:NSimSun; background:white; color:black; font-size:13px"><span style="background-color:#ffffff; color:#000000">OR</span></pre>
<pre lang="x-c#" style="font-family:NSimSun; background:white; color:black; font-size:13px"><span style="color:#a31515">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:blue">&lt;</span><span style="color:#a31515">local</span><span style="color:blue">:</span><span style="color:#a31515">DynamicImageButton.IconImage</span><span style="color:blue">&gt;</span>
<span style="color:#a31515">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:blue">&lt;</span><span style="color:#a31515">BitmapImage</span><span style="color:red">&nbsp;UriSource</span><span style="color:blue">=</span><span style="color:blue">&quot;icons/HELP.png&quot;</span><span style="color:blue">/&gt;</span>
<span style="color:#a31515">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:blue">&lt;/</span><span style="color:#a31515">local</span><span style="color:blue">:</span><span style="color:#a31515">DynamicImageButton.IconImage</span><span style="color:blue">&gt;</span>
<span style="color:#a31515">&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:blue">&lt;/</span><span style="color:#a31515">local</span><span style="color:blue">:</span><span style="color:#a31515">DynamicImageButton</span><span style="color:blue">&gt;</span></pre>
</div>
<h1>Source Code Files</h1>
<ul>
<li>DynamicImageButton.cs - the source code of this control. </li><li>Theme\Gerneic.xaml - the style of the controls, You could extend this content to define your own styles.
</li></ul>
<h1>More Information</h1>
<ul>
<li>WPF Image Button - <a href="http://www.c-sharpcorner.com/Resources/629/wpf-button-with-image.aspx">
http://www.c-sharpcorner.com/Resources/629/wpf-button-with-image.aspx</a> </li><li>Windows Presentations Foundation (WPF) 2D Transformations - <a href="http://www.codeguru.com/csharp/csharp/cs_misc/userinterface/article.php/c12221">
http://www.codeguru.com/csharp/csharp/cs_misc/userinterface/article.php/c12221</a>
</li></ul>
