using Bing.Maps;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace DraggablePushpin
{
    public sealed partial class DraggablePin : UserControl
    {
        #region Private Properties

        private Map _map;
        private bool isDragging = false;
        Location _center;

        #endregion

        #region Constructor

        public DraggablePin(Map map)
        {
            this.InitializeComponent();

            _map = map;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// A boolean indicating whether the pushpin can be dragged.
        /// </summary>
        public bool Draggable { get; set; }

        #endregion

        #region  Public Events

        /// <summary>
        /// Occurs when the pushpin is being dragged.
        /// </summary>
        public Action<Location> Drag;

        /// <summary>
        /// Occurs when the pushpin starts being dragged.
        /// </summary>
        public Action<Location> DragStart;

        /// <summary>
        /// Occurs when the pushpin stops being dragged.
        /// </summary>
        public Action<Location> DragEnd;

        #endregion

        #region Private Methods

        protected override void OnPointerPressed(PointerRoutedEventArgs e)
        {
 	        base.OnPointerPressed(e);

            if (Draggable)
            {
                if (_map != null)
                {
                    //Store the center of the map
                    _center = _map.Center;

                    //Attach events to the map to track touch and movement events
                    _map.ViewChanged += Map_ViewChanged;
                    _map.PointerReleasedOverride += Map_PointerReleased;
                    _map.PointerMovedOverride += Map_PointerMoved;
                }

                var pointerPosition = e.GetCurrentPoint(_map);

                Location location = null;

                //Convert the point pixel to a Location coordinate
                if (_map.TryPixelToLocation(pointerPosition.Position, out location))
                {
                    MapLayer.SetPosition(this, location);
                }

                if (DragStart != null)
                {
                    DragStart(location);
                }

                //Enable Dragging
                this.isDragging = true;
            }
        }

        private void Map_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            //Check if the user is currently dragging the Pushpin
            if (this.isDragging)
            {
                //If so, move the Pushpin to where the pointer is.
                var pointerPosition = e.GetCurrentPoint(_map);

                Location location = null;

                //Convert the point pixel to a Location coordinate
                if (_map.TryPixelToLocation(pointerPosition.Position, out location))
                {
                    MapLayer.SetPosition(this, location);
                }

                if (Drag != null)
                {
                    Drag(location);
                }
            }
        }

        private void Map_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            //Pushpin released, remove dragging events
            if (_map != null)
            {
                _map.ViewChanged -= Map_ViewChanged;
                _map.PointerReleasedOverride -= Map_PointerReleased;
                _map.PointerMovedOverride -= Map_PointerMoved;
            }

            var pointerPosition = e.GetCurrentPoint(_map);

            Location location = null;

            //Convert the point pixel to a Location coordinate
            if (_map.TryPixelToLocation(pointerPosition.Position, out location))
            {
                MapLayer.SetPosition(this, location);
            }

            if (DragEnd != null)
            {
                DragEnd(location);
            }

            this.isDragging = false;
        }

        private void Map_ViewChanged(object sender, ViewChangedEventArgs e)
        {
            if (isDragging)
            {
                //Reset the map center to the stored center value.
                //This prevents the map from panning when we drag across it.
                _map.Center = _center;
            }
        }

        #endregion
    }
}
