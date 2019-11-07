//------------------------------------------------------------------------------
// <copyright file="KinectSkeleton.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.WpfViewers
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Microsoft.Kinect;

    /// <summary>
    /// This control is used to render a player's skeleton.
    /// If the ClipToBounds is set to "false", it will be allowed to overdraw
    /// it's bounds.
    /// </summary>
    public class KinectSkeleton : Control
    {
        public static readonly DependencyProperty ShowClippedEdgesProperty =
            DependencyProperty.Register("ShowClippedEdges", typeof(bool), typeof(KinectSkeleton), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ShowJointsProperty =
            DependencyProperty.Register("ShowJoints", typeof(bool), typeof(KinectSkeleton), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ShowBonesProperty =
            DependencyProperty.Register("ShowBones", typeof(bool), typeof(KinectSkeleton), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ShowCenterProperty =
            DependencyProperty.Register("ShowCenter", typeof(bool), typeof(KinectSkeleton), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));

        private const double JointThickness = 3;
        private const double BodyCenterThickness = 10;
        private const double TrackedBoneThickness = 6;
        private const double InferredBoneThickness = 1;
        private const double ClipBoundsThickness = 10;

        private readonly Brush centerPointBrush = Brushes.Blue;
        private readonly Brush trackedJointBrush = new SolidColorBrush(Color.FromArgb(255, 68, 192, 68));
        private readonly Brush inferredJointBrush = Brushes.Yellow;
        private readonly Pen trackedBonePen = new Pen(Brushes.Green, TrackedBoneThickness);
        private readonly Pen inferredBonePen = new Pen(Brushes.Gray, InferredBoneThickness);

        private readonly Brush bottomClipBrush = new LinearGradientBrush(
            Color.FromArgb(0, 255, 0, 0), Color.FromArgb(255, 255, 0, 0), new Point(0, 0), new Point(0, 1));

        private readonly Brush topClipBrush = new LinearGradientBrush(
            Color.FromArgb(0, 255, 0, 0), Color.FromArgb(255, 255, 0, 0), new Point(0, 1), new Point(0, 0));

        private readonly Brush leftClipBrush = new LinearGradientBrush(
            Color.FromArgb(0, 255, 0, 0), Color.FromArgb(255, 255, 0, 0), new Point(1, 0), new Point(0, 0));

        private readonly Brush rightClipBrush = new LinearGradientBrush(
            Color.FromArgb(0, 255, 0, 0), Color.FromArgb(255, 255, 0, 0), new Point(0, 0), new Point(1, 0));

        private Dictionary<JointType, JointMapping> jointMappings;
        private Point centerPoint;
        private Skeleton currentSkeleton;
        private double scale = 1.0;

        public bool ShowClippedEdges
        {
            get { return (bool)GetValue(ShowClippedEdgesProperty); }
            set { SetValue(ShowClippedEdgesProperty, value); }
        }

        public bool ShowJoints
        {
            get { return (bool)GetValue(ShowJointsProperty); }
            set { SetValue(ShowJointsProperty, value); }
        }

        public bool ShowBones
        {
            get { return (bool)GetValue(ShowBonesProperty); }
            set { SetValue(ShowBonesProperty, value); }
        }

        public bool ShowCenter
        {
            get { return (bool)GetValue(ShowCenterProperty); }
            set { SetValue(ShowCenterProperty, value); }
        }

        /// <summary>
        /// This method should be called every skeleton frame.  It will force the properties to update and 
        /// trigger the control to render.
        /// </summary>
        /// <param name="skeleton">This is the current frame's skeleton data.</param>
        /// <param name="mappings">This is a list of pre-mapped joints.  See KinectSkeletonViewerer.xaml.cs</param>
        /// <param name="center">This is a pre-mapped point to the skeleton's center position.</param>
        /// <param name="scaleFactor">1 will render the bones and joints at a good size for a 640x480 image.
        /// The method would expect 0.5 to render a 320x240 scaled image.</param>
        public void RefreshSkeleton(Skeleton skeleton, Dictionary<JointType, JointMapping> mappings, Point center, double scaleFactor)
        {
            this.centerPoint = center;
            this.jointMappings = mappings;
            this.scale = scaleFactor;
            this.currentSkeleton = skeleton;

            this.InvalidateVisual();
        }

        public void Reset()
        {
            this.currentSkeleton = null;
            this.InvalidateVisual();
        }

        protected override Size MeasureOverride(Size constraint)
        {
            return new Size();                   
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            return arrangeBounds;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            // Don't render if we don't have a skeleton, or it isn't tracked
            if (this.currentSkeleton == null || this.currentSkeleton.TrackingState == SkeletonTrackingState.NotTracked)
            {
                return;
            }

            // Displays a gradient near the edge of the display where the skeleton is leaving the screen
            this.RenderClippedEdges(drawingContext);

            switch (this.currentSkeleton.TrackingState)
            {
                case SkeletonTrackingState.PositionOnly:
                    if (this.ShowCenter)
                    {
                        drawingContext.DrawEllipse(
                            this.centerPointBrush,
                            null,
                            this.centerPoint,
                            BodyCenterThickness * this.scale,
                            BodyCenterThickness * this.scale);
                    }

                    break;
                case SkeletonTrackingState.Tracked:
                    this.DrawBonesAndJoints(drawingContext);
                break;
            }
        }

        private void RenderClippedEdges(DrawingContext drawingContext)
        {
            if (!this.ShowClippedEdges || 
                this.currentSkeleton.ClippedEdges.Equals(FrameEdges.None))
            {
                return;
            }

            double scaledThickness = ClipBoundsThickness * this.scale;
            if (this.currentSkeleton.ClippedEdges.HasFlag(FrameEdges.Bottom))
            {
                drawingContext.DrawRectangle(
                    this.bottomClipBrush,
                    null,
                    new Rect(0, this.RenderSize.Height - scaledThickness, this.RenderSize.Width, scaledThickness));
            }

            if (this.currentSkeleton.ClippedEdges.HasFlag(FrameEdges.Top))
            {
                drawingContext.DrawRectangle(
                    this.topClipBrush,
                    null,
                    new Rect(0, 0, this.RenderSize.Width, scaledThickness));
            }

            if (this.currentSkeleton.ClippedEdges.HasFlag(FrameEdges.Left))
            {
                drawingContext.DrawRectangle(
                    this.leftClipBrush,
                    null,
                    new Rect(0, 0, scaledThickness, this.RenderSize.Height));
            }

            if (this.currentSkeleton.ClippedEdges.HasFlag(FrameEdges.Right))
            {
                drawingContext.DrawRectangle(
                    this.rightClipBrush,
                    null,
                    new Rect(this.RenderSize.Width - scaledThickness, 0, scaledThickness, this.RenderSize.Height));
            }
        }

        private void DrawBonesAndJoints(DrawingContext drawingContext)
        {
            if (this.ShowBones)
            {
                // Render Torso
                this.DrawBone(drawingContext, JointType.Head, JointType.ShoulderCenter);
                this.DrawBone(drawingContext, JointType.ShoulderCenter, JointType.ShoulderLeft);
                this.DrawBone(drawingContext, JointType.ShoulderCenter, JointType.ShoulderRight);
                this.DrawBone(drawingContext, JointType.ShoulderCenter, JointType.Spine);
                this.DrawBone(drawingContext, JointType.Spine, JointType.HipCenter);
                this.DrawBone(drawingContext, JointType.HipCenter, JointType.HipLeft);
                this.DrawBone(drawingContext, JointType.HipCenter, JointType.HipRight);

                // Left Arm
                this.DrawBone(drawingContext, JointType.ShoulderLeft, JointType.ElbowLeft);
                this.DrawBone(drawingContext, JointType.ElbowLeft, JointType.WristLeft);
                this.DrawBone(drawingContext, JointType.WristLeft, JointType.HandLeft);

                // Right Arm
                this.DrawBone(drawingContext, JointType.ShoulderRight, JointType.ElbowRight);
                this.DrawBone(drawingContext, JointType.ElbowRight, JointType.WristRight);
                this.DrawBone(drawingContext, JointType.WristRight, JointType.HandRight);

                // Left Leg
                this.DrawBone(drawingContext, JointType.HipLeft, JointType.KneeLeft);
                this.DrawBone(drawingContext, JointType.KneeLeft, JointType.AnkleLeft);
                this.DrawBone(drawingContext, JointType.AnkleLeft, JointType.FootLeft);

                // Right Leg
                this.DrawBone(drawingContext, JointType.HipRight, JointType.KneeRight);
                this.DrawBone(drawingContext, JointType.KneeRight, JointType.AnkleRight);
                this.DrawBone(drawingContext, JointType.AnkleRight, JointType.FootRight);
            }

            if (this.ShowJoints)
            {
                // Render Joints
                foreach (JointMapping joint in this.jointMappings.Values)
                {
                    Brush drawBrush = null;
                    switch (joint.Joint.TrackingState)
                    {
                        case JointTrackingState.Tracked:
                            drawBrush = this.trackedJointBrush;
                            break;
                        case JointTrackingState.Inferred:
                            drawBrush = this.inferredJointBrush;
                            break;
                    }

                    if (drawBrush != null)
                    {
                        drawingContext.DrawEllipse(drawBrush, null, joint.MappedPoint, JointThickness * this.scale, JointThickness * this.scale);
                    }
                }
            }
        }

        private void DrawBone(DrawingContext drawingContext, JointType jointType1, JointType jointType2)
        {
            JointMapping joint1;
            JointMapping joint2;

            // If we can't find either of these joints, exit
            if (!this.jointMappings.TryGetValue(jointType1, out joint1) || 
                joint1.Joint.TrackingState == JointTrackingState.NotTracked ||
                !this.jointMappings.TryGetValue(jointType2, out joint2) || 
                joint2.Joint.TrackingState == JointTrackingState.NotTracked)
            {
                return;
            }

            // Don't draw if both points are inferred
            if (joint1.Joint.TrackingState == JointTrackingState.Inferred &&
                joint2.Joint.TrackingState == JointTrackingState.Inferred)
            {
                return;
            }
            
            // We assume all drawn bones are inferred unless BOTH joints are tracked
            Pen drawPen = this.inferredBonePen;
            drawPen.Thickness = InferredBoneThickness * this.scale;
            if (joint1.Joint.TrackingState == JointTrackingState.Tracked && joint2.Joint.TrackingState == JointTrackingState.Tracked)
            {
                drawPen = this.trackedBonePen;
                drawPen.Thickness = TrackedBoneThickness * this.scale;
            }

            drawingContext.DrawLine(drawPen, joint1.MappedPoint, joint2.MappedPoint);
        }
    }
}
