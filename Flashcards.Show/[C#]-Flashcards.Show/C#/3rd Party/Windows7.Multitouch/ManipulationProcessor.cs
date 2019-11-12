//-----------------------------------------------------------------------------
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows7.Multitouch.ManipulationInterop;
using System.Runtime.InteropServices.ComTypes;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Windows7.Multitouch.Manipulation
{
    /// <summary>
    /// Manipulation Flags.
    /// Enables Manipulation Support
    /// </summary>
    [Flags]
    public enum ProcessorManipulations
    {
        /// <summary>
        /// Disable manipulation events
        /// </summary>
        NONE = 0,

        /// <summary>
        /// X axis translation events
        /// </summary>
        TRANSLATE_X = 0x1,

        /// <summary>
        /// Y Axis translation events
        /// </summary>
        TRANSLATE_Y = 0x2,

        /// <summary>
        /// Scaling events
        /// </summary>
        SCALE = 0x4,

        /// <summary>
        /// Rotation events
        /// </summary>
        ROTATE = 0x8,

        /// <summary>
        /// Fire all manipulation events
        /// </summary>
        ALL = 0xf
    }

    /// <summary>
    /// Utility class for vector manipulations
    /// </summary>
    public struct VectorF
    {
        private float _x;
        private float _y;

        /// <summary>
        /// Create new float vector
        /// </summary>
        /// <param name="x">X direction</param>
        /// <param name="y">Y Direction</param>
        public VectorF(float x, float y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// (x,y)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "(" + _x + ',' + _y + ')';
        }

        /// <summary>
        /// Check if two vectors are equal
        /// </summary>
        /// <param name="obj">the second vector</param>
        /// <returns>true if they are equal</returns>
        public override bool Equals(object obj)
        {
            VectorF other;

            try
            {
                other = (VectorF)obj;
            }
            catch
            {
                return false;
            }

            return obj != null && other._x == _x && other._y == _y;
        }

        /// <summary>
        /// Return the Vector hash code
        /// </summary>
        /// <returns>Hash Code</returns>
        public override int GetHashCode()
        {
            return _x.GetHashCode() ^ _y.GetHashCode();
        }

        /// <summary>
        /// The X direction
        /// </summary>
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// The Y Direction
        /// </summary>
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Convert vector to Size
        /// </summary>
        /// <param name="vector">The Vector</param>
        /// <returns>The vector as Size</returns>
        public static implicit operator Size(VectorF vector)
        {
            return new Size((int)vector.X, (int)vector.Y);
        }

        /// <summary>
        /// Convert Vector to SizeF
        /// </summary>
        /// <param name="vector">The Vector</param>
        /// <returns>The vector as SizeF</returns>
        public static implicit operator SizeF(VectorF vector)
        {
            return new SizeF(vector.X, vector.Y);
        }

        /// <summary>
        /// Convert Size to vector
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The size as vector</returns>
        public static implicit operator VectorF(Size size)
        {
            return new VectorF(size.Width, size.Height);
        }

        /// <summary>
        /// Convert SizeF to Vector
        /// </summary>
        /// <param name="size">The Size</param>
        /// <returns>The Size as Vector</returns>
        public static implicit operator VectorF(SizeF size)
        {
            return new VectorF(size.Width, size.Height);
        }

        /// <summary>
        /// Multiply the vector with scalar (float)
        /// </summary>
        /// <param name="vector">The source vector</param>
        /// <param name="value">The floating point scalar</param>
        /// <returns>New vector</returns>
        public static VectorF operator*(VectorF vector, float value)
        {
            return new VectorF(vector._x * value, vector._y * value);
        }

        /// <summary>
        /// Divide Vector with scalar (float)
        /// </summary>
        /// <param name="vector">The Vector</param>
        /// <param name="value">The scalar</param>
        /// <returns>New Vector</returns>
        public static VectorF operator /(VectorF vector, float value)
        {
            return vector * (1 / value); 
        }

        /// <summary>
        /// Add scalar to a vector
        /// </summary>
        /// <param name="vector">The Vector</param>
        /// <param name="value">The scalar</param>
        /// <returns>New vector</returns>
        public static VectorF operator +(VectorF vector, float value)
        {
            return new VectorF(vector._x + value, vector._y + value);
        }

        /// <summary>
        /// Substruct Scalar from vector
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <param name="value">The scalar</param>
        /// <returns>New vector</returns>
        public static VectorF operator -(VectorF vector, float value)
        {
            return vector + (-value);
        }

        /// <summary>
        /// Add two vectors
        /// </summary>
        /// <param name="v1">V1</param>
        /// <param name="v2">V2</param>
        /// <returns>New Vector</returns>
        public static VectorF operator +(VectorF v1, VectorF v2)
        {
            return new VectorF(v1._x + v2._x, v1._y + v2._y);
        }

        /// <summary>
        /// Substruct two vectors
        /// </summary>
        /// <param name="v1">V1</param>
        /// <param name="v2">V2</param>
        /// <returns>New Vector</returns>
        public static VectorF operator -(VectorF v1, VectorF v2)
        {
            return new VectorF(v1._x - v2._x, v1._y - v2._y);
        }

        /// <summary>
        /// Return the magnitude (normal) of a vector
        /// </summary>
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(_x * _x + _y * _y);
            }
        }

        /// <summary>
        /// Return the unit vector
        /// </summary>
        public VectorF Direction
        {
            get
            {
                return new VectorF(Math.Sign(_x), Math.Sign(_y));
            }
        }
    }

    /// <summary>
    /// Argument for manipulatiuon start event
    /// </summary>
    public class ManipulationStartedEventArgs : EventArgs
    {
        /// <summary>
        /// Argument for touch event location
        /// </summary>
        /// <param name="x">The x Axis</param>
        /// <param name="y">The y Axis</param>
        public ManipulationStartedEventArgs(float x, float y)
        {
            Location = new PointF(x, y);
        }

        /// <summary>
        /// This location is usually the center point
        /// </summary>
        public PointF Location { get; private set; }
    }

    /// <summary>
    /// The argument for manipulation complete event
    /// </summary>
    public class ManipulationCompletedEventArgs : ManipulationStartedEventArgs
    {
        /// <summary>
        /// Create new ManipulationCompletedEventArgs
        /// </summary>
        /// <param name="x">x Axis</param>
        /// <param name="y">y Axis</param>
        /// <param name="cumulativeTranslationX">Cumulative Translation in the X Axis since starting manipulation</param>
        /// <param name="cumulativeTranslationY">Cumulative Translation in the Y Axis since starting manipulation</param>
        /// <param name="cumulativeScale">Cumulative scaling since starting manipulation</param>
        /// <param name="cumulativeExpansion">Cumulative Expension since starting manipulation</param>
        /// <param name="cumulativeRotation">Cumulative rotation in radians since starting manipulation</param>
        public ManipulationCompletedEventArgs(float x, float y, float cumulativeTranslationX, float cumulativeTranslationY,
                                                    float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
            : base(x, y)
        {
            CumulativeTranslation = new SizeF(cumulativeTranslationX, cumulativeTranslationY);
            CumulativeScale = cumulativeScale;
            CumulativeExpansion = cumulativeExpansion;
            CumulativeRotation = cumulativeRotation;
        }

        /// <summary>
        /// Total translation
        /// </summary>
        public SizeF CumulativeTranslation { get; private set; }

        /// <summary>
        /// Total Scaling
        /// </summary>
        public float CumulativeScale { get; private set; }

        /// <summary>
        /// Total Extension
        /// </summary>
        public float CumulativeExpansion { get; private set; }

        /// <summary>
        /// Total Rotation
        /// </summary>
        public float CumulativeRotation { get; private set; }
    }

    /// <summary>
    /// The argument for manipulation delta
    /// </summary>
    public class ManipulationDeltaEventArgs : ManipulationCompletedEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">x Axis</param>
        /// <param name="y">y Axis</param>
        /// <param name="translationDeltaX">The amount of translation since the last event</param>
        /// <param name="translationDeltaY">The amount of translation since the last event</param>
        /// <param name="scaleDelta">The amount of scaling since the last event</param>
        /// <param name="expansionDelta">The amount of expension since the last event</param>
        /// <param name="rotationDelta">The amount of rotation in radians since the last event</param>
        /// <param name="cumulativeTranslationX">Cumulative Translation in the X Axis since starting manipulation</param>
        /// <param name="cumulativeTranslationY">Cumulative Translation in the Y Axis since starting manipulation</param>
        /// <param name="cumulativeScale">Cumulative scaling since starting manipulation</param>
        /// <param name="cumulativeExpansion">Cumulative Expension since starting manipulation</param>
        /// <param name="cumulativeRotation">Cumulative rotation in radians since starting manipulation</param>
        public ManipulationDeltaEventArgs(float x, float y, float translationDeltaX, float translationDeltaY, float scaleDelta, float expansionDelta,
            float rotationDelta, float cumulativeTranslationX, float cumulativeTranslationY, float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
            : base(x, y, cumulativeTranslationX, cumulativeTranslationY, cumulativeScale, cumulativeExpansion, cumulativeRotation)
        {
            TranslationDelta = new SizeF(translationDeltaX, translationDeltaY);
            ScaleDelta = scaleDelta;
            ExpansionDelta = expansionDelta;
            RotationDelta = rotationDelta;

        }

        /// <summary>
        /// The amount of translation since the last event
        /// </summary>
        public SizeF TranslationDelta { get; private set; }

        /// <summary>
        /// The amount of scaling since the last event
        /// </summary>
        public float ScaleDelta { get; private set; }
        
        /// <summary>
        /// The amount of expension since the last event
        /// </summary>
        public float ExpansionDelta { get; private set; }

        /// <summary>
        /// The amount of rotation since the last event
        /// </summary>
        public float RotationDelta { get; private set; }

    }

    /// <summary>
    /// A .NET wrapper for touch manipulation processing
    /// </summary>
    public class ManipulationProcessor : IManipulationEvents, IDisposable
    {

        private readonly IManipulationProcessor _comManipulationProcessor;
        private readonly IManipulationEvents _comManipulationEvents;

        /// <summary>
        /// Create new manipulation processor
        /// </summary>
        /// <remarks>
        /// Call the <see cref="ProcessDown"/>, <see cref="ProcessMove"/>, <see cref="ProcessUp"/> to feed the processor.
        /// Register on <see cref="ManipulationStarted"/>, <see cref="ManipulationDelta"/> and <see cref="ManipulationCompleted"/>
        /// to handle manipulation events
        /// </remarks>
        /// <param name="supportedManipulations">Activate specific manipulation (scale, translate, rotate)</param>
        public ManipulationProcessor(ProcessorManipulations supportedManipulations)
        {
            _comManipulationProcessor = new ManipulationInterop.ManipulationProcessor();
            _comManipulationEvents = new ManipulationEvents(_comManipulationProcessor, ManipulationEventHandler);

            SupportedManipulations = supportedManipulations;
        }

        internal virtual IManipulationEvents ManipulationEventHandler
        {
            get
            {
                return this;
            }
        }
                
        /// <summary>
        /// Fired when manipulation is started
        /// </summary>
        public event EventHandler<ManipulationStartedEventArgs> ManipulationStarted = (s, e) => { };
        
        /// <summary>
        /// Fired each time the processor had figured a change in one or more of the required manipulations
        /// </summary>
        public event EventHandler<ManipulationDeltaEventArgs> ManipulationDelta = (s, e) => { };

        /// <summary>
        /// Fired on manipulation end
        /// </summary>
        public event EventHandler<ManipulationCompletedEventArgs> ManipulationCompleted = (s, e) => { };

        #region IManipulationEvents Members
        void IManipulationEvents.ManipulationStarted(float x, float y)
        {
            ManipulationStarted(this, new ManipulationStartedEventArgs(x, y));
        }

        void IManipulationEvents.ManipulationDelta(float x, float y, float translationDeltaX, float translationDeltaY, float scaleDelta, float expansionDelta, float rotationDelta,
            float cumulativeTranslationX, float cumulativeTranslationY, float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
        {
            ManipulationDelta(this, new ManipulationDeltaEventArgs(x, y, translationDeltaX, translationDeltaY, scaleDelta, expansionDelta, rotationDelta,
                cumulativeTranslationX, cumulativeTranslationY, cumulativeScale, cumulativeExpansion, cumulativeRotation));
        }

        void IManipulationEvents.ManipulationCompleted(float x, float y, float cumulativeTranslationX, float cumulativeTranslationY, float cumulativeScale, float cumulativeExpansion,
            float cumulativeRotation)
        {
            ManipulationCompleted(this, new ManipulationCompletedEventArgs(x, y, cumulativeTranslationX, cumulativeTranslationY, cumulativeScale,
                cumulativeExpansion, cumulativeRotation));
        }

        #endregion

        /// <summary>
        /// Get or Set the required manipulation
        /// </summary>
        public ProcessorManipulations SupportedManipulations
        {
            get
            {
                return (ProcessorManipulations)_comManipulationProcessor.SupportedManipulations;
            }
            set
            {
                _comManipulationProcessor.SupportedManipulations = (MANIPULATION_PROCESSOR_MANIPULATIONS)value;
            }
        }

        /// <summary>
        /// The Center of the object
        /// </summary>
        public PointF PivotPoint
        {
            get
            {
                return new PointF(_comManipulationProcessor.PivotPointX, _comManipulationProcessor.PivotPointY);
            }
            set
            {
                _comManipulationProcessor.PivotPointX = value.X;
                _comManipulationProcessor.PivotPointY = value.Y;
            }
        }

        /// <summary>
        /// The PivotRadius property is used to determine how much rotation is used in single finger manipulation
        /// </summary>
        public float PivotRadius
        {
            get { return _comManipulationProcessor.PivotRadius; }
            set { _comManipulationProcessor.PivotRadius = value; }
        }

        /// <summary>
        /// This method raises the ManipulationCompleted() event in response
        /// </summary>
        public void CompleteManipulation()
        {
            _comManipulationProcessor.CompleteManipulation();
        }

        /// <summary>
        /// The ProcessDown method feeds data to the manipulation processor associated with a target
        /// </summary>
        /// <param name="manipulationId">The identifier for the manipulation that you want to process</param>
        /// <param name="location">The coordinates associated with the target</param>
        public void ProcessDown(uint manipulationId, PointF location)
        {
            _comManipulationProcessor.ProcessDown(manipulationId, location.X, location.Y);
        }

        /// <summary>
        /// The ProcessMove method feeds movement data for the target object to its manipulation processor
        /// </summary>
        /// <param name="manipulationId">The identifier for the manipulation that you want to process</param>
        /// <param name="location">The coordinates associated with the target</param>
        public void ProcessMove(uint manipulationId, PointF location)
        {
            _comManipulationProcessor.ProcessMove(manipulationId, location.X, location.Y);
        }

        /// <summary>
        /// The ProcessUp method feeds data to a target's manipulation processor for touch up sequences
        /// </summary>
        /// <param name="manipulationId">The identifier for the manipulation that you want to process</param>
        /// <param name="location">The coordinates associated with the target</param>
        public void ProcessUp(uint manipulationId, PointF location)
        {
            _comManipulationProcessor.ProcessUp(manipulationId, location.X, location.Y);
        }

        /// <summary>
        /// Feds data to the manipulation processor associated with a target and a timestamp
        /// </summary>
        /// <param name="manipulationId">The identifier for the manipulation that you want to process</param>
        /// <param name="location">The coordinates associated with the target</param>
        /// <param name="timestamp">The timestamp of the event</param>
        public void ProcessDownWithTime(uint manipulationId, PointF location, int timestamp)
        {
            _comManipulationProcessor.ProcessDownWithTime(manipulationId, location.X, location.Y, timestamp);
        }

        /// <summary>
        /// Feds data to the manipulation processor associated with a target and a timestamp
        /// </summary>
        /// <param name="manipulationId">The identifier for the manipulation that you want to process</param>
        /// <param name="location">The coordinates associated with the target</param>
        /// <param name="timestamp">The timestamp of the event</param>
        public void ProcessMoveWithTime(uint manipulationId, PointF location, int timestamp)
        {
            _comManipulationProcessor.ProcessMoveWithTime(manipulationId, location.X, location.Y, timestamp);
        }

        /// <summary>
        /// Feds data to the manipulation processor associated with a target and a timestamp
        /// </summary>
        /// <param name="manipulationId">The identifier for the manipulation that you want to process</param>
        /// <param name="location">The coordinates associated with the target</param>
        /// <param name="timestamp">The timestamp of the event</param>
        public void ProcessUpWithTime(uint manipulationId, PointF location, int timestamp)
        {
            _comManipulationProcessor.ProcessUpWithTime(manipulationId, location.X, location.Y, timestamp);
        }

        /// <summary>
        /// Calculates and returns the velocity for the target object
        /// </summary>
        public VectorF Velocity
        {
            get
            {
                return new VectorF(_comManipulationProcessor.GetVelocityX(), _comManipulationProcessor.GetVelocityY());
            }
        }

        /// <summary>
        /// Calculates the rate that the target object is expanding at
        /// </summary>
        public float ExpansionVelocity
        {
            get
            {
                return _comManipulationProcessor.GetExpansionVelocity();
            }
        }

        /// <summary>
        /// Calculates the rotational velocity that the target object is moving at
        /// </summary>
        public float AngularVelocity
        {
            get
            {
                return _comManipulationProcessor.GetAngularVelocity();
            }
        }

        /// <summary>
        /// Specifies the minimum scale and rotate radius
        /// </summary>
        public float MinimumScaleRotateRadius
        {
            get
            {
                return _comManipulationProcessor.MinimumScaleRotateRadius;
            }
            set
            {
                _comManipulationProcessor.MinimumScaleRotateRadius = value;
            }
        }

        /// <summary>
        /// Release the underlined COM Object
        /// </summary>
        /// <param name="dispose"></param>
        protected virtual void Dispose(bool dispose)
        {
            if (dispose)
            {
                GC.SuppressFinalize(this);
                Marshal.ReleaseComObject(_comManipulationProcessor);
                _comManipulationEvents.Dispose();
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Dispose the object, free the underline COM object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}