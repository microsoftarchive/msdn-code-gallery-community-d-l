using System;
using System.Collections;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace IdentityMine.Avalon.Controls
{
    public partial class ChartRotator : ItemsControl
    {
        private Viewport3D _viewport3D;
        private Model3DGroup _modelGroup;
        private ChartPlanes _planes;
        private Trackball _trackball;

        static ChartRotator()
        {
            //This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
            //This style is defined in themes\generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChartRotator), new FrameworkPropertyMetadata(typeof(ChartRotator)));
        }

        public ChartRotator()
        {
            this.ApplyTemplate();

            ((INotifyCollectionChanged)this.Items).CollectionChanged += new NotifyCollectionChangedEventHandler(OnItemsCollectionChanged);
            this.Initialized += new EventHandler(OnInitialized);
            this.Loaded += new RoutedEventHandler(OnLoaded);
        }

        #region IsViewport3D attached property
        public static readonly DependencyProperty IsViewport3DProperty = DependencyProperty.RegisterAttached("IsViewport3D",
            typeof(bool), typeof(ChartRotator), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(IsViewport3DInvalidated)));

        public static bool GetIsViewport3D(DependencyObject d)
        {
            return (bool)(d.GetValue(ChartRotator.IsViewport3DProperty));
        }

        public static void SetIsViewport3D(DependencyObject d, bool value)
        {
            d.SetValue(ChartRotator.IsViewport3DProperty, value);
        }

        private Viewport3D ChartViewport3D
        {
            get
            {
                if (this._viewport3D == null)
                {
                    throw new InvalidOperationException("The visual tree of a ChartRotator should have a Viewport3D with the attached property IsViewport3D set to true");
                }
                return this._viewport3D;
            }
        }

        private static void IsViewport3DInvalidated(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            Viewport3D viewport3D = target as Viewport3D;
            if ((viewport3D != null) && ChartRotator.GetIsViewport3D(viewport3D))
            {
                ChartRotator parent = viewport3D.TemplatedParent as ChartRotator;
                if (parent != null)
                {
                    parent._viewport3D = viewport3D;
                }
            }
        }
        #endregion

        #region Initialization
        private void OnInitialized(object sender, EventArgs e)
        {
            //init the items collection
            _planes = new ChartPlanes();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Trackball setup
            _trackball = new Trackball();
            _trackball.Attach(this);
            _trackball.Slaves.Add(_viewport3D);
            _trackball.Enabled = true;

            if (this.ItemsSource is ChartPlanes)
                _planes = this.ItemsSource as ChartPlanes;
            else
                return;

            // Add 3D model Content
            _viewport3D.Children.Clear();

            _modelGroup = new Model3DGroup();

            ScaleTransform3D GroupScaleTransform = new ScaleTransform3D(new Vector3D(0.74, 1, 1));
            RotateTransform3D GroupRotateTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0), new Point3D(0, 0, 0));
            TranslateTransform3D GroupTranslateTransform = new TranslateTransform3D(new Vector3D(0, 0, 0));
            Transform3DCollection tcollection = new Transform3DCollection();
            tcollection.Add(GroupScaleTransform);
            tcollection.Add(GroupRotateTransform);
            tcollection.Add(GroupTranslateTransform);
            Transform3DGroup tGroupDefault = new Transform3DGroup();
            tGroupDefault.Children = tcollection;
            _modelGroup.Transform = tGroupDefault;


            Model3DGroup submodelGroup = new Model3DGroup();
            submodelGroup.Children.Add(new AmbientLight(Colors.White));
            _modelGroup.Children.Add(submodelGroup);

            ModelVisual3D mv3d = new ModelVisual3D();
            GroupScaleTransform = new ScaleTransform3D(new Vector3D(1, 1, 1));
            GroupRotateTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0), new Point3D(0, 0, 0));
            GroupTranslateTransform = new TranslateTransform3D(new Vector3D(0, 0, 0));
            tcollection = new Transform3DCollection();
            tcollection.Add(GroupScaleTransform);
            tcollection.Add(GroupRotateTransform);
            tcollection.Add(GroupTranslateTransform);
            tGroupDefault = new Transform3DGroup();
            tGroupDefault.Children = tcollection;
            mv3d.Transform = tGroupDefault;
            mv3d.Content = _modelGroup;

            _viewport3D.Children.Add(mv3d);

        }

        #endregion

        #region Items collection support
        private void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Add(sender, args);
                    break;

                //case NotifyCollectionChangedAction.Remove:
                //    Remove(sender, args);
                //    break;

                //case NotifyCollectionChangedAction.Reset:
                //    Reset(sender, args);
                //    break;
            }
        }

        private void Add(object sender, NotifyCollectionChangedEventArgs args)
        {
            if ((args.NewItems == null) || (args.NewItems.Count == 0))
                return;
        }
        #endregion

        public MeshGeometry3D GetMeshGeometry3D(string meshName)
        {
            // create plane mesh
            MeshGeometry3D planeMesh = new MeshGeometry3D();

            switch (meshName)
            {
                case "PlaneMeshFront":
                    //<MeshGeometry3D x:Key="PlaneMeshFront"
                    //    Positions="-1,-1,0 1,-1,0 -1,1,0 1,1,0"
                    //    Normals="0,0,1 0,0,1 0,0,1 0,0,1"
                    //    TextureCoordinates="0,1 1,1 0,0 1,0"
                    //    TriangleIndices="0 1 2 1 3 2" />

                    planeMesh.Positions.Add(new Point3D(-1, -1, 0));
                    planeMesh.Positions.Add(new Point3D(1, -1, 0));
                    planeMesh.Positions.Add(new Point3D(-1, 1, 0));
                    planeMesh.Positions.Add(new Point3D(1, 1, 0));

                    planeMesh.Normals.Add(new Vector3D(0, 0, 1));
                    planeMesh.Normals.Add(new Vector3D(0, 0, 1));
                    planeMesh.Normals.Add(new Vector3D(0, 0, 1));
                    planeMesh.Normals.Add(new Vector3D(0, 0, 1));

                    planeMesh.TextureCoordinates.Add(new Point(0, 1));
                    planeMesh.TextureCoordinates.Add(new Point(1, 1));
                    planeMesh.TextureCoordinates.Add(new Point(0, 0));
                    planeMesh.TextureCoordinates.Add(new Point(1, 0));

                    planeMesh.TriangleIndices.Add(0);
                    planeMesh.TriangleIndices.Add(1);
                    planeMesh.TriangleIndices.Add(2);
                    planeMesh.TriangleIndices.Add(1);
                    planeMesh.TriangleIndices.Add(3);
                    planeMesh.TriangleIndices.Add(2);
                    break;
                case "PlaneMeshBack":
                    //<MeshGeometry3D x:Key="PlaneMeshBack"
                    //           Positions="-1,1,0 1,1,0 1,-1,0 -1,-1,0"
                    //           Normals="0,0,-1 0,0,-1 0,0,-1 0,0,-1"
                    //           TextureCoordinates="0,0 1,0 1,1 0,1"
                    //           TriangleIndices="0 1 3 1 2 3" />

                    planeMesh.Positions.Add(new Point3D(-1, 1, 0));
                    planeMesh.Positions.Add(new Point3D(1, 1, 0));
                    planeMesh.Positions.Add(new Point3D(1, -1, 0));
                    planeMesh.Positions.Add(new Point3D(-1, -1, 0));

                    planeMesh.Normals.Add(new Vector3D(0, 0, -1));
                    planeMesh.Normals.Add(new Vector3D(0, 0, -1));
                    planeMesh.Normals.Add(new Vector3D(0, 0, -1));
                    planeMesh.Normals.Add(new Vector3D(0, 0, -1));

                    planeMesh.TextureCoordinates.Add(new Point(0, 0));
                    planeMesh.TextureCoordinates.Add(new Point(1, 0));
                    planeMesh.TextureCoordinates.Add(new Point(1, 1));
                    planeMesh.TextureCoordinates.Add(new Point(0, 1));

                    planeMesh.TriangleIndices.Add(0);
                    planeMesh.TriangleIndices.Add(1);
                    planeMesh.TriangleIndices.Add(3);
                    planeMesh.TriangleIndices.Add(1);
                    planeMesh.TriangleIndices.Add(2);
                    planeMesh.TriangleIndices.Add(3);
                    break;
            }

            return planeMesh;
        }

        public void Reset()
        {
            // clear the planes collection
            _planes.Clear();

            // update freezable
            ModelVisual3D mv3d = _viewport3D.Children[0] as ModelVisual3D;
            mv3d.Content = _modelGroup;
        }

        public void AddVisual(VisualBrush visualBrush)
        {
            Transform3DGroup transfromGroup = new Transform3DGroup();

            TranslateTransform3D ChartTranslate3d1 = new TranslateTransform3D(new Vector3D(0.0, 0.0, 0.0));
            TranslateTransform3D ChartTranslate3d2 = new TranslateTransform3D(new Vector3D(0.0, 0.0, 0.0));
            TranslateTransform3D ChartTranslate3d3 = new TranslateTransform3D();

            // set the offset between planes
            ChartTranslate3d3.OffsetX = 0.0;
            ChartTranslate3d3.OffsetY = 0.0;
            ChartTranslate3d3.OffsetZ = _planes.Count * 0.20;

            ScaleTransform3D scaleTransform = new ScaleTransform3D();
            RotateTransform3D rotateTransform = new RotateTransform3D();
            AxisAngleRotation3D ChartR3D = new AxisAngleRotation3D();

            // ScaleTransform3D
            scaleTransform.ScaleX = 1.5;
            scaleTransform.ScaleY = 0.625;
            scaleTransform.ScaleZ = 1.0;

            // RotateTransform3D
            rotateTransform.CenterX = 0.0;
            rotateTransform.CenterY = 0.0;
            rotateTransform.CenterZ = 0.0;

            // Rotation3D
            ChartR3D.Axis = new Vector3D(0.0, 1.0, 0.0);
            ChartR3D.Angle = 0.0;

            // RotateTransform3D
            rotateTransform.Rotation = ChartR3D;

            transfromGroup.Children.Add(ChartTranslate3d1);
            transfromGroup.Children.Add(scaleTransform);
            transfromGroup.Children.Add(rotateTransform);
            transfromGroup.Children.Add(ChartTranslate3d2);       // TranslateTransform3D
            transfromGroup.Children.Add(ChartTranslate3d3);       // TranslateTransform3D

            // create visual brush to be used as diffuse material
            DiffuseMaterial df1 = new DiffuseMaterial();
            df1.Brush = visualBrush;

            GeometryModel3D planeFront = new GeometryModel3D();
            planeFront.Geometry = GetMeshGeometry3D("PlaneMeshFront") as Geometry3D;
            planeFront.Material = df1;
            planeFront.Transform = transfromGroup;
            _planes.Add(planeFront);

            GeometryModel3D planeBack = new GeometryModel3D();
            planeBack.Geometry = GetMeshGeometry3D("PlaneMeshBack") as Geometry3D;
            planeBack.Material = df1;
            planeBack.Transform = transfromGroup;
            _planes.Add(planeBack);

            // get modifiable copy of model group
            ModelVisual3D mv3d = _viewport3D.Children[0] as ModelVisual3D;
            Model3DGroup modelGroup = (mv3d.Content as Model3DGroup).Clone(); 

            modelGroup.Children.Add(planeFront);
            modelGroup.Children.Add(planeBack);

            // update freezable
            ModelVisual3D mv3d2 = _viewport3D.Children[0] as ModelVisual3D;
            mv3d2.Content = modelGroup;

            //_trackball.Refresh();
        }
    }
}