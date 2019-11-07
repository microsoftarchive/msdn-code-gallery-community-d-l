//-----------------------------------------------------------------------------
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace Windows7.Multitouch.ManipulationInterop
{
    [Flags]
    public enum MANIPULATION_PROCESSOR_MANIPULATIONS
    {
        MANIPULATION_NONE = 0,
        MANIPULATION_TRANSLATE_X = 0x1,
        MANIPULATION_TRANSLATE_Y = 0x2,
        MANIPULATION_SCALE = 0x4,
        MANIPULATION_ROTATE = 0x8,
        MANIPULATION_ALL = 0xf
    }

    public class IIDGuid
    {
        // IID GUID strings for relevant COM interfaces.
        public const string IManipulationEvents = "4f62c8da-9c53-4b22-93df-927a862bbb03";
        public const string IInertiaProcessor = "18b00c6d-c5ee-41b1-90a9-9d4a929095ad";
        public const string IManipulationProcessor = "A22AC519-8300-48a0-BEF4-F1BE8737DBA4";
    }

    public class ClassIDGuid
    {
        public const string InertiaProcessor = "abb27087-4ce0-4e58-a0cb-e24df96814be";
        public const string ManipulationProcessor = "597D4FB0-47FD-4aff-89B9-C6CFAE8CF08E";
    }

    public class ManipulationClassID
    {
        public const string InertiaProcessor = "abb27087-4ce0-4e58-a0cb-e24df96814be";
        public const string ManipulationProcessor = "597D4FB0-47FD-4aff-89B9-C6CFAE8CF08E";
    }

    [ComImport(),
    Guid(IIDGuid.IManipulationEvents),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IManipulationEvents : IDisposable
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ManipulationStarted([In] float x, [In] float y);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ManipulationDelta(
            [In] float x,
            [In] float y,
            [In] float translationDeltaX,
            [In] float translationDeltaY,
            [In] float scaleDelta,
            [In] float expansionDelta,
            [In] float rotationDelta,
            [In] float cumulativeTranslationX,
            [In] float cumulativeTranslationY,
            [In] float cumulativeScale,
            [In] float cumulativeExpansion,
            [In] float cumulativeRotation);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ManipulationCompleted(
            [In] float x,
            [In] float y,
            [In] float cumulativeTranslationX,
            [In] float cumulativeTranslationY,
            [In] float cumulativeScale,
            [In] float cumulativeExpansion,
            [In] float cumulativeRotation);
    }


    [ComImport(),
    Guid(IIDGuid.IInertiaProcessor),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInertiaProcessor : IConnectionPointContainer
    {
        float InitialOriginX
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        float InitialOriginY 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set; 
        }
            
        float InitialVelocityX
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set; 
        }
            
        float InitialVelocityY 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]    
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set; 
        } 

        float InitialAngularVelocity 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set; 
        }
        
        float InitialExpansionVelocity 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set; 
        }
        
        float InitialRadius 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set; 
        }
        
        float BoundaryLeft 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set; 
        }
        
        float BoundaryTop 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set; 
        }
        
        float BoundaryRight 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set; 
        }
        
        float BoundaryBottom 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set; 
        }
        
        
        float ElasticMarginLeft 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set; 
        }
        
        float ElasticMarginTop 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set; 
        }
         
       float ElasticMarginRight 
       {
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           get;
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           set; 
       }
        
       float ElasticMarginBottom 
       {
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           get;
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           set; 
       }

       float DesiredDisplacement 
       {
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           get;
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           set; 
       }

       float DesiredRotation 
       {
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           get;
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           set; 
       }

       float DesiredExpansion 
       {
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           get;
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           set; 
       }

       float DesiredDeceleration 
       {
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           get;
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           set; 
       }

       float DesiredAngularDeceleration 
       {
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           get;
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           set; 
       }
        
       float DesiredExpansionDeceleration 
       {
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           get;
           [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
           set; 
       }
        
         int InitialTimestamp 
         {
             [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
             get;
             [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
             set; 
         }
    
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Reset();
        
         [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
         bool Process(); 
            
         [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
         bool ProcessTime([In] int timestamp);
 
         [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
         void Complete();
        
         [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
         void CompleteTime([In] int timestamp);  
    }


    [ComImport(),
    Guid(IIDGuid.IManipulationProcessor),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IManipulationProcessor : IConnectionPointContainer
    {
        MANIPULATION_PROCESSOR_MANIPULATIONS SupportedManipulations
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }
            
        float PivotPointX 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        } 
        
        float PivotPointY 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        } 
            
        float PivotRadius 
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        } 
            
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]    
        void CompleteManipulation();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]    
        void ProcessDown([In] uint manipulationId, [In] float x, [In] float y);

        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]    
        void ProcessMove( 
            [In] uint manipulationId,
            [In] float x,
            [In] float y);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]    
        void ProcessUp( 
            [In] uint manipulationId,
            [In] float x,
            [In] float y);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]    
        void ProcessDownWithTime( 
            [In] uint manipulationId,
            [In] float x,
            [In] float y,
            [In] int timestamp);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]    
        void ProcessMoveWithTime( 
            [In] uint manipulationId,
            [In] float x,
            [In] float y,
            [In] int timestamp);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]    
        void ProcessUpWithTime( 
            [In] uint manipulationId,
            [In] float x,
            [In] float y,
            [In] int timestamp);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]    
        float GetVelocityX();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]    
        float GetVelocityY();
 
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]    
        float GetExpansionVelocity(); 
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]    
        float GetAngularVelocity();

        float MinimumScaleRotateRadius
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }  
    }

    public class ManipulationEvents : IManipulationEvents, IDisposable
    {
        private readonly IConnectionPoint _connectionPoint;
        private readonly IManipulationEvents _callBack;
        private int _cookie = -1;

        public ManipulationEvents(IConnectionPointContainer connectionPointContainer, IManipulationEvents callBack)
        {
            _callBack = callBack;

            Guid manipulationEventsId = new Guid(IIDGuid.IManipulationEvents);
            connectionPointContainer.FindConnectionPoint(ref manipulationEventsId, out _connectionPoint);
            _connectionPoint.Advise(this, out _cookie);
        }

        #region IManipulationEvents Members

        public void ManipulationStarted(float x, float y)
        {
            _callBack.ManipulationStarted(x, y);
        }

        public void ManipulationDelta(float x, float y, float translationDeltaX, float translationDeltaY, float scaleDelta, 
                    float expansionDelta, float rotationDelta, float cumulativeTranslationX, float cumulativeTranslationY, 
                                                    float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
        {
            _callBack.ManipulationDelta(x, y, translationDeltaX, translationDeltaY, scaleDelta, expansionDelta, rotationDelta,
                             cumulativeTranslationX, cumulativeTranslationY, cumulativeScale, cumulativeExpansion, cumulativeRotation);
        }

        public void ManipulationCompleted(float x, float y, float cumulativeTranslationX, float cumulativeTranslationY, float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
        {
            _callBack.ManipulationCompleted(x, y, cumulativeTranslationX, cumulativeTranslationY, cumulativeScale, cumulativeExpansion, cumulativeRotation);
        }

        #endregion

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                if (_cookie != -1)
                    _connectionPoint.Unadvise(_cookie);
                GC.SuppressFinalize(this);
            }
        }

        ~ManipulationEvents()
        {
            Dispose(false);
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }

    [ComImport, ClassInterface((short)0), Guid(ClassIDGuid.ManipulationProcessor)]
    public class ManipulationProcessor : IManipulationProcessor
    {
        #region IManipulationProcessor Members
        
        public virtual extern MANIPULATION_PROCESSOR_MANIPULATIONS SupportedManipulations
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        
        public virtual extern float PivotPointX
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float PivotPointY
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float PivotRadius
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void CompleteManipulation();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void ProcessDown(uint manipulationId, float x, float y);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void ProcessMove(uint manipulationId, float x, float y);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void ProcessUp(uint manipulationId, float x, float y);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void ProcessDownWithTime(uint manipulationId, float x, float y, int timestamp);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void ProcessMoveWithTime(uint manipulationId, float x, float y, int timestamp);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void ProcessUpWithTime(uint manipulationId, float x, float y, int timestamp);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern float GetVelocityX();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern float GetVelocityY();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern float GetExpansionVelocity();
    
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern float GetAngularVelocity();

        public virtual extern float MinimumScaleRotateRadius
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        #endregion

        #region IConnectionPointContainer Members

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void EnumConnectionPoints(out IEnumConnectionPoints ppEnum);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void FindConnectionPoint(ref Guid riid, out IConnectionPoint ppCP);

        #endregion
    }


    [ComImport, ClassInterface((short)0), Guid(ClassIDGuid.InertiaProcessor)]
    public class InertiaProcessor : IInertiaProcessor
    {
        #region IInertiaProcessor Members
        public virtual extern float InitialOriginX
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float InitialOriginY
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float InitialVelocityX
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float InitialVelocityY
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float InitialAngularVelocity
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float InitialExpansionVelocity
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float InitialRadius
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float BoundaryLeft
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float BoundaryTop
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float BoundaryRight
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float BoundaryBottom
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float ElasticMarginLeft
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float ElasticMarginTop
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float ElasticMarginRight
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float ElasticMarginBottom
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float DesiredDisplacement
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float DesiredRotation
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float DesiredExpansion
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float DesiredDeceleration
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float DesiredAngularDeceleration
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern float DesiredExpansionDeceleration
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        public virtual extern int InitialTimestamp
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            set;
        }

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Reset();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern bool Process();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern bool ProcessTime(int timestamp);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Complete();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void CompleteTime(int timestamp);

        #endregion

        #region IConnectionPointContainer Members

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void EnumConnectionPoints(out IEnumConnectionPoints ppEnum);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void FindConnectionPoint(ref Guid riid, out IConnectionPoint ppCP);

        #endregion
    }
}