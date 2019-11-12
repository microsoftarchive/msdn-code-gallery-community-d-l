using Microsoft.Maps.MapControl.WPF;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BingMapsWPF__DraggableRoutes
{
    public partial class DragPin : UserControl, INotifyPropertyChanged
    {
        #region Private Properties

        private Map _map;
        private bool isDragging = false;
        private Location _center;

        #endregion

        #region Constructor

        public DragPin(Map map)
        {
            InitializeComponent();

            this.DataContext = this;

            MapLayer.SetPositionOrigin(this, PositionOrigin.BottomCenter);

            _map = map;
        }

        #endregion

        #region Public Properties 

        private ImageSource _imageSource;

        public ImageSource ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }

        private Location _location;

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                MapLayer.SetPosition(this, value);
            }
        }

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

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (_map != null)
            {
                _center = _map.Center;

                _map.ViewChangeOnFrame += _map_ViewChangeOnFrame;
                _map.MouseUp += ParentMap_MouseLeftButtonUp;
                _map.MouseMove += ParentMap_MouseMove;
                _map.TouchMove += _map_TouchMove;
            }

            if (DragStart != null)
            {
                var mousePosition = e.GetPosition(_map);
                var location = _map.ViewportPointToLocation(mousePosition);
                DragStart(location);
            }

            // Enable Dragging
            this.isDragging = true;

            base.OnMouseLeftButtonDown(e);
        }

        void _map_TouchMove(object sender, TouchEventArgs e)
        {
            // Check if the user is currently dragging the Pushpin
            if (this.isDragging)
            {
                // If so, the Move the Pushpin to where the Mouse is.
                var mouseMapPosition = e.GetTouchPoint(_map);
                var location = _map.ViewportPointToLocation(mouseMapPosition.Position);
                this.Location = location;

                if (Drag != null)
                {
                    Drag(location);
                }
            }
        }

        void _map_ViewChangeOnFrame(object sender, MapEventArgs e)
        {
            if (isDragging)
            {
                _map.Center = _center;
            }
        }

        void ParentMap_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Left Mouse Button released, stop dragging the Pushpin
            if (_map != null)
            {
                _map.ViewChangeOnFrame -= _map_ViewChangeOnFrame;
                _map.MouseUp -= ParentMap_MouseLeftButtonUp;
                _map.MouseMove -= ParentMap_MouseMove;
                _map.TouchMove -= _map_TouchMove;
            }

            if (DragEnd != null)
            {
                var mousePosition = e.GetPosition(_map);
                var location = _map.ViewportPointToLocation(mousePosition);
                DragEnd(location);
            }

            this.isDragging = false;
        }

        void ParentMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isDragging)
            {
                var mouseMapPosition = e.GetPosition(_map);
                var location = _map.ViewportPointToLocation(mouseMapPosition);
                this.Location = location;

                if (Drag != null)
                {
                    Drag(location);
                }
            }
        }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
