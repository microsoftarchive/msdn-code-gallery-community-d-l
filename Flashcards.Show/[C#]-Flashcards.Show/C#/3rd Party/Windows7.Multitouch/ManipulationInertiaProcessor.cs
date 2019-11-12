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
    /// A manipulation processor that support Inertia processing
    /// </summary>
    public class ManipulationInertiaProcessor : ManipulationProcessor
    {
        private InertiaProcessor _inertiaProcessor;

        /// <summary>
        /// Create new manipulation processor
        /// </summary>
        /// <remarks>
        /// Call the <see cref="ManipulationProcessor.ProcessDown"/>, <see cref="ManipulationProcessor.ProcessMove"/>, <see cref="ManipulationProcessor.ProcessUp"/> to feed the processor.
        /// Register on <see cref="ManipulationProcessor.ManipulationStarted"/>, <see cref="ManipulationProcessor.ManipulationDelta"/> and <see cref="ManipulationProcessor.ManipulationCompleted"/>
        /// to handle manipulation events
        /// Set the <see cref="InertiaProcessor"/> properties to get the desired inertia behavior
        /// Register to the <see cref="BeforeInertia"/> event to set the inertia properties when inertia is starting/>
        /// </remarks>
        /// <param name="supportedManipulations">Activate specific manipulation (scale, translate, rotate)</param>
        /// <param name="timer">The GUI timer that will be used for inertia events</param>
        public ManipulationInertiaProcessor(ProcessorManipulations supportedManipulations, IGUITimer timer)
            : base(supportedManipulations)
        {
            _inertiaProcessor.SetTimer(timer);
            BeforeInertia += (s, e) => { };
        }

        /// <summary>
        /// Fired just before inertia is starting
        /// </summary>
        public event EventHandler<BeforeInertiaEventArgs> BeforeInertia;

        //Call by the base ctor
        internal override IManipulationEvents ManipulationEventHandler
        {
            get
            {
                if (_inertiaProcessor == null)
                    _inertiaProcessor = new InertiaProcessor(this);
               
                return _inertiaProcessor;
            }
        }

        /// <summary>
        /// Release the underline COM object
        /// </summary>
        /// <param name="dispose"></param>
        protected override void Dispose(bool dispose)
        {
            if (dispose)
            {
                _inertiaProcessor.Dispose();
                base.Dispose(dispose);
            }
        }

        /// <summary>
        /// The inertia processor that is associate with the Manipulation Processor
        /// </summary>
        public InertiaProcessor InertiaProcessor
        {
            get
            {
                return _inertiaProcessor;
            }
        }

        internal IManipulationEvents ManipulationEvents
        {
            get
            {
                return this as IManipulationEvents;
            }
        }

        internal bool OnBeforeInertia()
        {
            BeforeInertiaEventArgs args = new BeforeInertiaEventArgs();
            BeforeInertia(this, args);
            return args.CancelInertia;
        }
    }

    /// <summary>
    /// The Inertia Processor
    /// </summary>
    /// <remarks>Handles calculations regarding object motion for multitouch</remarks>
    public class InertiaProcessor : IManipulationEvents, IDisposable
    {
        private readonly IInertiaProcessor _comInertiaProcessor;
        private readonly ManipulationInertiaProcessor _manipulationProcessor;
        private readonly ManipulationEvents _comManipulationEvents;
        private int _inertiaCounter = 0;
        private bool _inInertia = false;
        private IGUITimer _timer;

        internal InertiaProcessor(ManipulationInertiaProcessor processor)
        {
            _comInertiaProcessor = new ManipulationInterop.InertiaProcessor();
            _manipulationProcessor = processor;
            _comManipulationEvents = new ManipulationEvents(_comInertiaProcessor, processor as IManipulationEvents);
            MaxInertiaSteps = 200;
            InertiaTimerInterval = 15;
        }

        private void ResetInertia()
        {
            _inertiaCounter = 0;
            _timer.Stop();
            _inInertia = false;
        }

        /// <summary>
        /// After this amount of timer ticks, the Inertia will stop
        /// </summary>
        public int MaxInertiaSteps
        {
            get;
            set;
        }

        /// <summary>
        /// The timer resolution for inertia events
        /// </summary>
        public int InertiaTimerInterval
        {
            get;
            set;
        }


        #region IManipulationEvents Members
        void IManipulationEvents.ManipulationStarted(float x, float y)
        {
            ResetInertia();
            _manipulationProcessor.ManipulationEvents.ManipulationStarted(x, y);
        }

        void IManipulationEvents.ManipulationDelta(float x, float y, float translationDeltaX, float translationDeltaY, float scaleDelta, float expansionDelta, float rotationDelta,
            float cumulativeTranslationX, float cumulativeTranslationY, float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
        {
            _manipulationProcessor.ManipulationEvents.ManipulationDelta(x, y, translationDeltaX, translationDeltaY, scaleDelta, expansionDelta, rotationDelta,
                cumulativeTranslationX, cumulativeTranslationY, cumulativeScale, cumulativeExpansion, cumulativeRotation);
        }

        void IManipulationEvents.ManipulationCompleted(float x, float y, float cumulativeTranslationX, float cumulativeTranslationY, float cumulativeScale, float cumulativeExpansion,
            float cumulativeRotation)
        {
            if (_inInertia == true)
            {
                ResetInertia();
                return;
            }
            //else
            
            if (_manipulationProcessor.OnBeforeInertia() == true)
                return;

            _inInertia = true;
            _timer.Interval = InertiaTimerInterval;
            _timer.Tick += (s, e) =>
            {
                ++_inertiaCounter;
                if (_inertiaCounter > MaxInertiaSteps)
                {
                    ResetInertia();
                    _comInertiaProcessor.Complete();
                }
                else
                {
                    _comInertiaProcessor.Process();
                }
            };

            _comInertiaProcessor.InitialOriginX = x;
            _comInertiaProcessor.InitialOriginY = y;
            _comInertiaProcessor.Reset();
            _timer.Start();
        }
        #endregion

        /// <summary>
        /// True when the inertia processor generate inertia motion events
        /// </summary>
        public bool InInertia
        {
            get
            {
                return _inInertia;
            }
        }

        /// <summary>
        /// Specifies the initial movement of the target object
        /// </summary>
        public VectorF InitialVelocity
        {
            get
            {
                return new VectorF(_comInertiaProcessor.InitialVelocityX, _comInertiaProcessor.InitialVelocityY);
            }
            set
            {
                _comInertiaProcessor.InitialVelocityX = value.X;
                _comInertiaProcessor.InitialVelocityY = value.Y;
            }
        }

        /// <summary>
        /// Specifies the rotation of the target when movement begins
        /// </summary>
        public float InitialAngularVelocity
        {
            get
            {
                return _comInertiaProcessor.InitialAngularVelocity;
            }
            set
            {
                _comInertiaProcessor.InitialAngularVelocity = value;
            }
        }

        /// <summary>
        /// Specifies the expention of the target when movement begins
        /// </summary>
        public float InitialExpansionVelocity
        {
            get
            {
                return _comInertiaProcessor.InitialExpansionVelocity;
            }
            set
            {
                _comInertiaProcessor.InitialExpansionVelocity = value;
            }
        }

        /// <summary>
        /// Specifies the distance from the edge of the target to its center before the object was changed
        /// </summary>
        public float InitialRadius
        {
            get
            {
                return _comInertiaProcessor.InitialRadius;
            }
            set
            {
                _comInertiaProcessor.InitialRadius = value;
            }
        }

        /// <summary>
        /// Limits how far towards the edge of the screen the target object can move
        /// </summary>
        public RectangleF Boundary
        {
            get
            {
                return new RectangleF(
                    _comInertiaProcessor.BoundaryLeft,
                    _comInertiaProcessor.BoundaryTop,
                    _comInertiaProcessor.BoundaryRight - _comInertiaProcessor.BoundaryLeft,
                    _comInertiaProcessor.BoundaryBottom - _comInertiaProcessor.BoundaryTop);
            }
            set
            {
                _comInertiaProcessor.BoundaryLeft = value.Left;
                _comInertiaProcessor.BoundaryRight = value.Right;
                _comInertiaProcessor.BoundaryTop = value.Top;
                _comInertiaProcessor.BoundaryBottom = value.Bottom;
            }
        }

        /// <summary>
        /// Specifies the rectangle region for bouncing the target objec
        /// </summary>
        public RectangleF ElasticMargin
        {
            get
            {
                return new RectangleF(
                    _comInertiaProcessor.ElasticMarginLeft,
                    _comInertiaProcessor.ElasticMarginTop,
                    _comInertiaProcessor.ElasticMarginRight - _comInertiaProcessor.ElasticMarginLeft,
                    _comInertiaProcessor.ElasticMarginBottom - _comInertiaProcessor.ElasticMarginTop);
            }
            set
            {
                _comInertiaProcessor.ElasticMarginLeft = value.Left;
                _comInertiaProcessor.ElasticMarginRight = value.Right;
                _comInertiaProcessor.ElasticMarginTop = value.Top;
                _comInertiaProcessor.ElasticMarginBottom = value.Bottom;
            }
        }

        /// <summary>
        /// Specifies the desired distance that the object will travel
        /// </summary>
        public float DesiredDisplacement
        {
            get
            {
                return _comInertiaProcessor.DesiredDisplacement;
            }
            set
            {
                _comInertiaProcessor.DesiredDisplacement = value;
            }
        }

        /// <summary>
        /// Specifies the desired radians that the object will rotate
        /// </summary>
        public float DesiredRotation
        {
            get
            {
                return _comInertiaProcessor.DesiredRotation;
            }
            set
            {
                _comInertiaProcessor.DesiredRotation = value;
            }
        }

        /// <summary>
        /// Specifies the desired change in the object's average radius
        /// </summary>
        public float DesiredExpansion
        {
            get
            {
                return _comInertiaProcessor.DesiredExpansion;
            }
            set
            {
                _comInertiaProcessor.DesiredExpansion = value;
            }
        }

        /// <summary>
        /// Specifies the desired rate at which translation operations will decelerate
        /// </summary>
        public float DesiredDeceleration
        {
            get
            {
                return _comInertiaProcessor.DesiredDeceleration;
            }
            set
            {
                _comInertiaProcessor.DesiredDeceleration = value;
            }
        }

        /// <summary>
        /// Specifies the desired rate that the target object will stop spinning in radians per msec
        /// </summary>
        public float DesiredAngularDeceleration
        {
            get
            {
                return _comInertiaProcessor.DesiredAngularDeceleration;
            }
            set
            {
                _comInertiaProcessor.DesiredAngularDeceleration = value;
            }
        }

        /// <summary>
        /// Specifies the rate at which the object will stop expanding
        /// </summary>
        public float DesiredExpansionDeceleration
        {
            get
            {
                return _comInertiaProcessor.DesiredExpansionDeceleration;
            }
            set
            {
                _comInertiaProcessor.DesiredExpansionDeceleration = value;
            }
        }
        

        #region IDisposable Members

        /// <summary>
        /// Dispose the object and release the underline COM object
        /// </summary>
        public void Dispose()
        {
            Marshal.ReleaseComObject(_comInertiaProcessor);
            _timer.Stop();
            _timer.Dispose();
        }

        #endregion

        internal void SetTimer(IGUITimer timer)
        {
            _timer = timer;
        }
    }

    /// <summary>
    /// Before Inertia phase is starting
    /// </summary>
    public class BeforeInertiaEventArgs : EventArgs
    {
        /// <summary>
        /// Cancel Inertia by setting this property to true
        /// </summary>
        public bool CancelInertia;
    }
}