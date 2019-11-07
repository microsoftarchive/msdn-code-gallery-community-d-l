namespace MSDN.FSharp.Charting
    
open System
open System.Drawing
open System.Windows.Forms.DataVisualization.Charting

open MSDN.FSharp.Charting.ChartTypes
open MSDN.FSharp.Charting.ChartStyles
open MSDN.FSharp.Charting.ChartFormUtilities


[<AutoOpen>]
module ChartStyleExtensions = 

    type AreaProperties() = 
        member area.AxisX<'T when 'T :> GenericChart>
          ( ?Enabled, ?LabelStyle, ?IsMarginVisible, ?Maximum, ?Minimum, ?MajorGrid, ?MinorGrid, ?MajorTickMark, ?MinorTickMark, ?Name,
            ?Title, ?TitleAlignment, ?TitleFont, ?TitleForeColor, ?ToolTip) = 
          fun (ch:'T) -> 
            //ch.Area.AxisX <- new Axis(null, AxisName.X)
            Enabled |> Option.iter ch.Area.AxisX.set_Enabled
            LabelStyle |> Option.iter ch.Area.AxisX.set_LabelStyle
            IsMarginVisible |> Option.iter ch.Area.AxisX.set_IsMarginVisible
            Maximum |> Option.iter ch.Area.AxisX.set_Maximum
            Minimum |> Option.iter ch.Area.AxisX.set_Minimum
            MajorGrid |> Option.iter ch.Area.AxisX.set_MajorGrid
            MinorGrid |> Option.iter ch.Area.AxisX.set_MinorGrid
            MajorTickMark |> Option.iter ch.Area.AxisX.set_MajorTickMark
            MinorTickMark |> Option.iter ch.Area.AxisX.set_MinorTickMark
            Name |> Option.iter ch.Area.AxisX.set_Name
            Title |> Option.iter ch.Area.AxisX.set_Title
            TitleAlignment |> Option.iter ch.Area.AxisX.set_TitleAlignment
            TitleFont |> Option.iter ch.Area.AxisX.set_TitleFont
            TitleForeColor |> Option.iter ch.Area.AxisX.set_TitleForeColor
            ToolTip |> Option.iter ch.Area.AxisX.set_ToolTip
            ch

        member area.AxisY<'T when 'T :> GenericChart>
          ( ?Enabled, ?LabelStyle, ?IsMarginVisible, ?Maximum, ?Minimum, ?MajorGrid, ?MinorGrid, ?MajorTickMark, ?MinorTickMark, ?Name,
            ?Title, ?TitleAlignment, ?TitleFont, ?TitleForeColor, ?ToolTip) =
          fun (ch:'T) -> 
            //ch.Area.AxisY <- new Axis(null, AxisName.Y)
            Enabled |> Option.iter ch.Area.AxisY.set_Enabled
            LabelStyle |> Option.iter ch.Area.AxisY.set_LabelStyle
            IsMarginVisible |> Option.iter ch.Area.AxisY.set_IsMarginVisible
            Maximum |> Option.iter ch.Area.AxisY.set_Maximum
            Minimum |> Option.iter ch.Area.AxisY.set_Minimum
            MajorGrid |> Option.iter ch.Area.AxisY.set_MajorGrid
            MinorGrid |> Option.iter ch.Area.AxisY.set_MinorGrid
            MajorTickMark |> Option.iter ch.Area.AxisY.set_MajorTickMark
            MinorTickMark |> Option.iter ch.Area.AxisY.set_MinorTickMark
            Name |> Option.iter ch.Area.AxisY.set_Name
            Title |> Option.iter ch.Area.AxisY.set_Title
            TitleAlignment |> Option.iter ch.Area.AxisY.set_TitleAlignment
            TitleFont |> Option.iter ch.Area.AxisY.set_TitleFont
            TitleForeColor |> Option.iter ch.Area.AxisY.set_TitleForeColor
            ToolTip |> Option.iter ch.Area.AxisY.set_ToolTip
            ch

        member area.AxisX2<'T when 'T :> GenericChart>
          ( ?Enabled, ?LabelStyle, ?IsMarginVisible, ?Maximum, ?Minimum, ?MajorGrid, ?MinorGrid, ?MajorTickMark, ?MinorTickMark, ?Name,
            ?Title, ?TitleAlignment, ?TitleFont, ?TitleForeColor, ?ToolTip) =
          fun (ch:'T) -> 
            //ch.Area.AxisX <- new Axis(null, AxisName.X)
            Enabled |> Option.iter ch.Area.AxisX2.set_Enabled
            LabelStyle |> Option.iter ch.Area.AxisX2.set_LabelStyle
            IsMarginVisible |> Option.iter ch.Area.AxisX2.set_IsMarginVisible
            Maximum |> Option.iter ch.Area.AxisX2.set_Maximum
            Minimum |> Option.iter ch.Area.AxisX2.set_Minimum
            MajorGrid |> Option.iter ch.Area.AxisX2.set_MajorGrid
            MinorGrid |> Option.iter ch.Area.AxisX2.set_MinorGrid
            MajorTickMark |> Option.iter ch.Area.AxisX2.set_MajorTickMark
            MinorTickMark |> Option.iter ch.Area.AxisX2.set_MinorTickMark
            Name |> Option.iter ch.Area.AxisX2.set_Name
            Title |> Option.iter ch.Area.AxisX2.set_Title
            TitleAlignment |> Option.iter ch.Area.AxisX2.set_TitleAlignment
            TitleFont |> Option.iter ch.Area.AxisX2.set_TitleFont
            TitleForeColor |> Option.iter ch.Area.AxisX2.set_TitleForeColor
            ToolTip |> Option.iter ch.Area.AxisX2.set_ToolTip
            ch

        member area.AxisY2<'T when 'T :> GenericChart>
          ( ?Enabled, ?LabelStyle, ?IsMarginVisible, ?Maximum, ?Minimum, ?MajorGrid, ?MinorGrid, ?MajorTickMark, ?MinorTickMark, ?Name,
            ?Title, ?TitleAlignment, ?TitleFont, ?TitleForeColor, ?ToolTip) =
          fun (ch:'T) -> 
            //ch.Area.AxisY <- new Axis(null, AxisName.Y)
            Enabled |> Option.iter ch.Area.AxisY2.set_Enabled
            LabelStyle |> Option.iter ch.Area.AxisY2.set_LabelStyle
            IsMarginVisible |> Option.iter ch.Area.AxisY2.set_IsMarginVisible
            Maximum |> Option.iter ch.Area.AxisY2.set_Maximum
            Minimum |> Option.iter ch.Area.AxisY2.set_Minimum
            MajorGrid |> Option.iter ch.Area.AxisY2.set_MajorGrid
            MinorGrid |> Option.iter ch.Area.AxisY2.set_MinorGrid
            MajorTickMark |> Option.iter ch.Area.AxisY2.set_MajorTickMark
            MinorTickMark |> Option.iter ch.Area.AxisY2.set_MinorTickMark
            Name |> Option.iter ch.Area.AxisY2.set_Name
            Title |> Option.iter ch.Area.AxisY2.set_Title
            TitleAlignment |> Option.iter ch.Area.AxisY2.set_TitleAlignment
            TitleFont |> Option.iter ch.Area.AxisY2.set_TitleFont
            TitleForeColor |> Option.iter ch.Area.AxisY2.set_TitleForeColor
            ToolTip |> Option.iter ch.Area.AxisY2.set_ToolTip
            ch

        member area.Style<'T when 'T :> GenericChart> (?Background) =
          fun (ch:'T) -> 
            Background |> Option.iter (applyBackground ch.Area)
            ch

        member area.Name<'T when 'T :> GenericChart> (?Name) =
          fun (ch:'T) -> 
            Name |> Option.iter ch.Area.set_Name
            ch

        member area.Align<'T when 'T :> GenericChart> (?Area, ?Orientation, ?Style) =
          fun (ch:'T) -> 
            Area |> Option.iter ch.Area.set_AlignWithChartArea
            Style |> Option.iter ch.Area.set_AlignmentStyle
            Orientation |> Option.iter ch.Area.set_AlignmentOrientation
            ch

        member area.Area3DStyle<'T when 'T :> GenericChart> (?Enable3D, ?Inclination, ?IsClustered, ?IsRightAngleAxes, ?LightStyle, ?Perspective, ?PointDepth, ?PointGapDepth, ?Rotation, ?WallWidth) =
          fun (ch:'T) ->
            Enable3D |> Option.iter ch.Area.Area3DStyle.set_Enable3D
            Inclination |> Option.iter ch.Area.Area3DStyle.set_Inclination
            IsClustered |> Option.iter ch.Area.Area3DStyle.set_IsClustered
            IsRightAngleAxes |> Option.iter ch.Area.Area3DStyle.set_IsRightAngleAxes
            LightStyle |> Option.iter ch.Area.Area3DStyle.set_LightStyle
            Perspective |> Option.iter ch.Area.Area3DStyle.set_Perspective
            PointDepth |> Option.iter ch.Area.Area3DStyle.set_PointDepth
            PointGapDepth |> Option.iter ch.Area.Area3DStyle.set_PointGapDepth
            Rotation |> Option.iter ch.Area.Area3DStyle.set_Rotation
            WallWidth |> Option.iter ch.Area.Area3DStyle.set_WallWidth
            ch


    type SeriesProperties() = 
  
          member series.AxisType<'T when 'T :> GenericChart> (?YAxisType, ?XAxisType) =
            fun (ch:'T) -> 
              YAxisType |> Option.iter ch.Series.set_YAxisType
              XAxisType |> Option.iter ch.Series.set_XAxisType
              ch
  
          member series.Style<'T when 'T :> GenericChart> (?Color, ?BorderColor, ?BorderWidth) =
            fun (ch:'T) -> 
              Color |> Option.iter ch.Series.set_Color
              BorderColor |> Option.iter ch.Series.set_BorderColor
              BorderWidth |> Option.iter ch.Series.set_BorderWidth
              ch

          member series.DataPoint<'T when 'T :> GenericChart> (?Label, ?LabelToolTip, ?ToolTip) =
            fun (ch:'T) ->               
              Label |> Option.iter ch.Series.set_Label
              LabelToolTip |> Option.iter ch.Series.set_LabelToolTip
              ToolTip |> Option.iter ch.Series.set_ToolTip
              ch

          member series.Marker<'T when 'T :> GenericChart> (?Color, ?Size, ?Step, ?Style, ?BorderColor, ?BorderWidth) =
            fun (ch:'T) -> 
              BorderColor |> Option.iter ch.Series.set_MarkerBorderColor
              BorderWidth |> Option.iter ch.Series.set_MarkerBorderWidth
              Color |> Option.iter ch.Series.set_MarkerColor
              Size |> Option.iter ch.Series.set_MarkerSize
              Step |> Option.iter ch.Series.set_MarkerStep
              Style |> Option.iter ch.Series.set_MarkerStyle
              ch

    type FSharpChart with 
        static member WithArea = AreaProperties()
        static member WithSeries = SeriesProperties()

        static member WithLegend<'T when 'T :> GenericChart>
            ( ?Title, ?Background, ?Font, ?Alignment, ?Docking, ?InsideArea,
              ?TitleAlignment, ?TitleFont, ?TitleForeColor, ?BorderColor, ?BorderWidth, ?BorderDashStyle) =
          fun (ch:'T) -> 
            let legend = new Legend()
            applyPropertyDefaults (ch.ChartType) legend
            InsideArea |> Option.iter legend.set_IsDockedInsideChartArea
            Background |> Option.iter (applyBackground legend)
            Font |> Option.iter legend.set_Font
            Alignment |> Option.iter legend.set_Alignment
            Docking |> Option.iter legend.set_Docking
            Title |> Option.iter legend.set_Title
            TitleAlignment |> Option.iter legend.set_TitleAlignment
            TitleFont |> Option.iter legend.set_TitleFont
            TitleForeColor |> Option.iter legend.set_TitleForeColor
            BorderColor |> Option.iter legend.set_BorderColor
            BorderDashStyle |> Option.iter legend.set_BorderDashStyle
            BorderWidth |> Option.iter legend.set_BorderWidth
            ch.Legends.Add legend
            ch
      
        static member WithMargin<'T when 'T :> GenericChart> (left, top, right, bottom) =
          fun (ch:'T) ->
            ch.Margin <- (left, top, right, bottom)
            ch

        static member WithStyle<'T when 'T :> GenericChart> (?Background) =
          fun (ch:'T) -> 
            Background |> Option.iter (applyBackground ch.Chart)
            ch

        static member WithTitle<'T when 'T :> GenericChart>
            ( ?Text, ?TextStyle, ?Font, ?Background, ?Color, ?BorderColor, ?BorderWidth, ?BorderDashStyle, 
              ?TextOrientation, ?Alignment, ?Docking, ?InsideArea) =
          fun (ch:'T) ->
              let title = new Title()
              applyPropertyDefaults (ch.ChartType) title
              Text |> Option.iter title.set_Text 
              Color |> Option.iter title.set_ForeColor
              BorderColor |> Option.iter title.set_BorderColor
              BorderDashStyle |> Option.iter title.set_BorderDashStyle
              BorderWidth |> Option.iter title.set_BorderWidth
              TextStyle |> Option.iter title.set_TextStyle
              TextOrientation |> Option.iter title.set_TextOrientation
              InsideArea |> Option.iter title.set_IsDockedInsideChartArea
              Background |> Option.iter (applyBackground title)
              Font |> Option.iter title.set_Font
              Alignment |> Option.iter title.set_Alignment
              Docking |> Option.iter title.set_Docking
              ch.Titles.Add title
              ch

    type StyleHelper =

        static member private FontCreate(fName:string option, fFamily:FontFamily option, fStyle:FontStyle option, fSize:float32 option) =
            let fontSize = 
                match fSize with
                | Some(size) -> size
                | None -> DefaultFont.Size
            let fontStyle = 
                match fStyle with
                | Some(style) -> style
                | None -> DefaultFont.Style
            let font =
                match (fFamily, fName) with
                | (Some(family), _) -> new Font(family, fontSize, fontStyle)
                | (_, Some(name)) -> new Font(name, fontSize, fontStyle)
                | (None, None) -> new Font(DefaultFont.FontFamily, fontSize, fontStyle)
            font

        static member LabelStyle
            ( ?Angle, ?Color, ?Format, ?Interval, ?IntervalOffset, ?IntervalOffsetType, ?IntervalType, ?IsEndLabelVisible, ?IsStaggered, ?TruncatedLabels,
              ?FontName:string, ?FontFamily:FontFamily, ?FontStyle:FontStyle, ?FontSize:float32) =
              let labelStyle = new System.Windows.Forms.DataVisualization.Charting.LabelStyle()
              Angle |> Option.iter labelStyle.set_Angle
              Color |> Option.iter labelStyle.set_ForeColor
              Format |> Option.iter labelStyle.set_Format
              Interval |> Option.iter labelStyle.set_Interval
              IntervalOffset |> Option.iter labelStyle.set_IntervalOffset
              IntervalOffsetType |> Option.iter labelStyle.set_IntervalOffsetType
              IntervalType |> Option.iter labelStyle.set_IntervalType
              IsStaggered |> Option.iter labelStyle.set_IsStaggered
              TruncatedLabels |> Option.iter labelStyle.set_TruncatedLabels
              if FontName.IsSome || FontFamily.IsSome || FontStyle.IsSome || FontSize.IsSome then
                 labelStyle.set_Font (StyleHelper.FontCreate(FontName, FontFamily, FontStyle, FontSize))
              labelStyle

        static member Legend
            ( ?Title, ?Background, ?Alignment, ?Docking, ?InsideArea,
              ?BorderColor, ?BorderWidth, ?BorderDashStyle, 
              ?FontName:string, ?FontFamily:FontFamily, ?FontStyle:FontStyle, ?FontSize:float32) =
              let legend = new Legend()
              InsideArea |> Option.iter legend.set_IsDockedInsideChartArea
              Background |> Option.iter (applyBackground legend)
              Alignment |> Option.iter legend.set_Alignment
              Docking |> Option.iter legend.set_Docking
              Title |> Option.iter legend.set_Title
              BorderColor |> Option.iter legend.set_BorderColor
              BorderDashStyle |> Option.iter legend.set_BorderDashStyle
              BorderWidth |> Option.iter legend.set_BorderWidth
              if FontName.IsSome || FontFamily.IsSome || FontStyle.IsSome || FontSize.IsSome then
                  legend.set_Font (StyleHelper.FontCreate(FontName, FontFamily, FontStyle, FontSize))
              legend

        static member Title
            ( ?Text, ?TextStyle, ?Background, ?Color, ?BorderColor, ?BorderWidth, ?BorderDashStyle, 
              ?TextOrientation, ?Alignment, ?Docking, ?InsideArea,
              ?FontName:string, ?FontFamily:FontFamily, ?FontStyle:FontStyle, ?FontSize:float32) =
              let title = new Title()
              Text |> Option.iter title.set_Text 
              Color |> Option.iter title.set_ForeColor
              BorderColor |> Option.iter title.set_BorderColor
              BorderDashStyle |> Option.iter title.set_BorderDashStyle
              BorderWidth |> Option.iter title.set_BorderWidth
              TextStyle |> Option.iter title.set_TextStyle
              TextOrientation |> Option.iter title.set_TextOrientation
              InsideArea |> Option.iter title.set_IsDockedInsideChartArea
              Background |> Option.iter (applyBackground title)
              Alignment |> Option.iter title.set_Alignment
              Docking |> Option.iter title.set_Docking
              if FontName.IsSome || FontFamily.IsSome || FontStyle.IsSome || FontSize.IsSome then
                  title.set_Font (StyleHelper.FontCreate(FontName, FontFamily, FontStyle, FontSize))
              title

        static member Font(?FamilyName:string, ?FontFamily:FontFamily, ?FontStyle:FontStyle, ?FontSize:float32) =
            StyleHelper.FontCreate(FamilyName, FontFamily, FontStyle, FontSize)

