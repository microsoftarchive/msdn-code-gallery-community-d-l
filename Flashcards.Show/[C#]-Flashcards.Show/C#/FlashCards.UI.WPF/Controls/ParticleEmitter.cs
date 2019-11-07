using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using Particles;

namespace FlashCards.UI.Controls
{
    public class ParticleEmitter : Control
    {   
        static ParticleEmitter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ParticleEmitter), new FrameworkPropertyMetadata(typeof(ParticleEmitter)));
        }

        public bool HasActiveParticles
        {
            get { return (bool)GetValue(HasActiveParticlesProperty); }
            private set { SetValue(HasActiveParticlesPropertyKey, value); }
        }

        // Using a DependencyProperty as the backing store for HasActiveParticles.  This enables animation, styling, binding, etc...
        public static readonly DependencyPropertyKey HasActiveParticlesPropertyKey =
            DependencyProperty.RegisterReadOnly("HasActiveParticles", typeof(bool), typeof(ParticleEmitter), new UIPropertyMetadata(false));

        public static readonly DependencyProperty HasActiveParticlesProperty = HasActiveParticlesPropertyKey.DependencyProperty;

        #region IsEmitting (DP)

        public bool IsEmitting
        {
            get { return (bool)GetValue(IsEmittingProperty); }
            set { SetValue(IsEmittingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsEmitting.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEmittingProperty =
            DependencyProperty.Register("IsEmitting", typeof(bool), typeof(ParticleEmitter), new UIPropertyMetadata(false,
                new PropertyChangedCallback((obj, args) => ((ParticleEmitter)obj).OnIsEmittingChanged())));

        void OnIsEmittingChanged()
        {
            if (IsEmitting)
            {
                if (_frameTimer.IsEnabled == false)
                {
                    HasActiveParticles = true;
                    _frameTimer.Start();
                }
            }
        }

        #endregion

        #region EmitLocation (DP)

        public Point EmitLocation
        {
            get { return (Point)GetValue(EmitLocationProperty); }
            set { SetValue(EmitLocationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EmitLocation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmitLocationProperty = 
            DependencyProperty.Register("EmitLocation", typeof(Point), typeof(ParticleEmitter), new UIPropertyMetadata(new Point(),
                new PropertyChangedCallback((obj, args) => ((ParticleEmitter)obj).OnEmitLocationChanged())));

        void OnEmitLocationChanged()
        {
            this._spawnPoint = Transform2DPointTo3D(EmitLocation);

            Point pos = TranslatePoint(EmitLocation, _world);
            _world.RenderTransform = new ScaleTransform(Zoom, Zoom, pos.X, pos.Y);
        }

        #endregion

        #region RelativeEmitLocation (DP)

        public Point RelativeEmitLocation
        {
            get { return (Point)GetValue(RelativeEmitLocationProperty); }
            set { SetValue(RelativeEmitLocationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RelativeEmitLocation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RelativeEmitLocationProperty =
            DependencyProperty.Register("RelativeEmitLocation", typeof(Point), typeof(ParticleEmitter), new UIPropertyMetadata(new Point(),
                new PropertyChangedCallback((obj, args) => ((ParticleEmitter)obj).OnRelativeEmitLocationChanged())));

        void OnRelativeEmitLocationChanged()
        {
            EmitLocation = new Point(RelativeEmitLocation.X* this.ActualWidth, RelativeEmitLocation.Y * this.ActualHeight);
        }

        #endregion



        public Uri ImageSource
        {
            get { return (Uri)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(Uri), typeof(ParticleEmitter), new UIPropertyMetadata(null));



        #region Zoom (DP)

        public double Zoom
        {
            get { return (double)GetValue(ZoomProperty); }
            set { SetValue(ZoomProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Zoom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZoomProperty =
            DependencyProperty.Register("Zoom", typeof(double), typeof(ParticleEmitter), new UIPropertyMetadata(1d,
                new PropertyChangedCallback((obj, args) => ((ParticleEmitter)obj).OnZoomChanged())));

        void OnZoomChanged()
        {
            Point pos = TranslatePoint(EmitLocation, _world);
            _world.RenderTransform = new ScaleTransform(Zoom, Zoom, pos.X, pos.Y);
        }

        #endregion

        #region overrides

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _worldModels = GetTemplateChild("PART_WorldModels") as Model3DGroup;
            _camera = GetTemplateChild("PART_Camera") as OrthographicCamera;
            _world = GetTemplateChild("PART_World") as Viewport3D;

            _frameTimer = new System.Windows.Threading.DispatcherTimer();
            _frameTimer.Tick += OnFrame;
            _frameTimer.Interval = TimeSpan.FromSeconds(1.0 / 45.0);
            _frameTimer.Start();

            this._lastTick = Environment.TickCount;

            _pm = new ParticleSystemManager();

            this._worldModels.Children.Add(_pm.CreateParticleSystem(1000, Colors.Gray, ImageSource));
            this._worldModels.Children.Add(_pm.CreateParticleSystem(1000, Colors.Red, ImageSource));
            this._worldModels.Children.Add(_pm.CreateParticleSystem(1000, Colors.Silver, ImageSource));
            this._worldModels.Children.Add(_pm.CreateParticleSystem(1000, Colors.OldLace, ImageSource));
            this._worldModels.Children.Add(_pm.CreateParticleSystem(1000, Colors.YellowGreen, ImageSource));
            this._worldModels.Children.Add(_pm.CreateParticleSystem(1000, Colors.Orange, ImageSource));

            _rand = new Random(this.GetHashCode());
        }

        #endregion

        #region private methods

        Point3D Transform2DPointTo3D(Point pt)
        {
            double cameraWidthRatio = _camera.Width / _world.ActualWidth;

            // Convert from 2D to XY plane coordinates
            Point pos3D = new Point(pt.X - (_world.ActualWidth / 2), -(pt.Y - (_world.ActualHeight / 2)));

            Point trans3Dpt = new Point();
            trans3Dpt.X = pos3D.X * cameraWidthRatio;
            trans3Dpt.Y = pos3D.Y * cameraWidthRatio;

            // Fudge the number a bit for the effect
            return new Point3D(trans3Dpt.X - .2, trans3Dpt.Y - .2, 0);
        }

        void OnFrame(object sender, EventArgs e)
        {
            // Calculate frame time;
            this._currentTick = Environment.TickCount;
            this._elapsed = (double)(this._currentTick - this._lastTick) / 1000.0;
            this._totalElapsed += this._elapsed;
            this._lastTick = this._currentTick;

            _frameCount++;
            _frameCountTime += _elapsed;

            _pm.Update((float)_elapsed);

            if (IsEmitting)
            {
                _pm.SpawnParticle(this._spawnPoint, 8.0, Colors.Red, _rand.NextDouble(), 1.5 * _rand.NextDouble());
                _pm.SpawnParticle(this._spawnPoint, 8.0, Colors.Red, _rand.NextDouble(), 1.5 * _rand.NextDouble());
                _pm.SpawnParticle(this._spawnPoint, 8.0, Colors.Orange, _rand.NextDouble(), 1.5 * _rand.NextDouble());
                _pm.SpawnParticle(this._spawnPoint, 8.0, Colors.Silver, _rand.NextDouble(), 1.5 * _rand.NextDouble());
                _pm.SpawnParticle(this._spawnPoint, 8.0, Colors.Gray, _rand.NextDouble(), 1.5 * _rand.NextDouble());
                _pm.SpawnParticle(this._spawnPoint, 8.0, Colors.Red, _rand.NextDouble(), 1.5 * _rand.NextDouble());
                _pm.SpawnParticle(this._spawnPoint, 8.0, Colors.Orange, _rand.NextDouble(), 1.5 * _rand.NextDouble());
                _pm.SpawnParticle(this._spawnPoint, 8.0, Colors.Silver, _rand.NextDouble(), 1.5 * _rand.NextDouble());
                _pm.SpawnParticle(this._spawnPoint, 8.0, Colors.Gray, _rand.NextDouble(), 1.5 * _rand.NextDouble());
                _pm.SpawnParticle(this._spawnPoint, 8.0, Colors.Red, _rand.NextDouble(), 1.5 * _rand.NextDouble());
                _pm.SpawnParticle(this._spawnPoint, 8.0, Colors.Yellow, _rand.NextDouble(), 1.5 * _rand.NextDouble());
                _pm.SpawnParticle(this._spawnPoint, 8.0, Colors.Silver, _rand.NextDouble(), 1.5 * _rand.NextDouble());
                _pm.SpawnParticle(this._spawnPoint, 8.0, Colors.Yellow, _rand.NextDouble(), 1.5 * _rand.NextDouble());
            }
            else if (_pm.ActiveParticleCount == 0)
            {
                HasActiveParticles = false;
                _frameTimer.Stop();
            }
        }

        #endregion

        #region fields

        DispatcherTimer _frameTimer;
        Point3D _spawnPoint;
        double _elapsed;
        double _totalElapsed;
        int _lastTick;
        int _currentTick;
        int _frameCount;
        double _frameCountTime;
        Model3DGroup _worldModels;
        OrthographicCamera _camera;
        Viewport3D _world;
        ParticleSystemManager _pm;
        Random _rand;
        #endregion
    }
}
